using Azure.Identity;
using BE_U3_W3_D5.Models.Entities;
using BE_U3_W3_D5.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BE_U3_W3_D5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetUserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        //costruttore
        public AspNetUserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto registerRequestDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser user = new ApplicationUser()
                    {
                        UserName = registerRequestDto.UserName,
                        Email = registerRequestDto.Email,
                        Name = registerRequestDto.Name,
                        Surname = registerRequestDto.Surname,
                        PhoneNumber = registerRequestDto.PhoneNumber,
                        Birthday = registerRequestDto.Birthday,
                        CreateAt = DateTime.UtcNow,
                        Id = Guid.NewGuid().ToString(),
                        IsDeleted = false,
                        EmailConfirmed = true,
                        LockoutEnabled = false,


                    };

                    IdentityResult result = await _userManager.CreateAsync(user, registerRequestDto.Password);
                    if (result.Succeeded)
                    {
                        ApplicationRole role = new ApplicationRole()
                        {
                            Name = registerRequestDto.Role != null ? registerRequestDto.Role : "User",
                            Role = registerRequestDto.Role != null ? registerRequestDto.Role : "User",
                            Id = Guid.NewGuid().ToString(),
                            NormalizedName = registerRequestDto.Role != null ? registerRequestDto.Role.ToUpper() : "USER",
                        };
                        var roleExist = await this._roleManager.RoleExistsAsync(role.Name);
                        if (!roleExist)
                        {
                            await this._roleManager.CreateAsync(role);
                        }
                        await this._userManager.AddToRoleAsync(user,role.Name);
                        return Ok();
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByNameAsync(loginRequestDto.UserName);
                if (user is null)
                {
                    return BadRequest();
                }

                Microsoft.AspNetCore.Identity.SignInResult result = await this._signInManager.PasswordSignInAsync(user, loginRequestDto.Password, false, false);
                if (!result.Succeeded)
                {
                    return BadRequest();

                }
                List<string> roles = (await this._userManager.GetRolesAsync(user)).ToList();

                List<Claim> userClaims = new List<Claim>();
                foreach (string roleName in roles)
                {
                    userClaims.Add(new Claim("role", roleName));

                }


                var key = System.Text.Encoding.UTF8.GetBytes("11b57b25e1c4a98e5a1b51e9bc3a480c9d03bcb8a3b98662fd00183f684d37a1");

                SigningCredentials cred = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256);


                var tokenExpiration = DateTime.Now.AddMinutes(30);

                JwtSecurityToken jwt = new JwtSecurityToken(
                    "https://",
                    "https://",
                     claims: userClaims,
                      expires: tokenExpiration,
                    signingCredentials: cred

                    );

                string token = new JwtSecurityTokenHandler().WriteToken(jwt);
                return Ok(new LoginResponseDto()
                {
                    Token = token,
                    Expiration = tokenExpiration

                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }
    }
}
