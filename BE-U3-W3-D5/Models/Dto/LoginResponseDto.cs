namespace BE_U3_W3_D5.Models.Dto
{

        public class LoginResponseDto
        {
            public string Token { get; set; }
            public DateTime Expiration { get; set; }
        }
    }