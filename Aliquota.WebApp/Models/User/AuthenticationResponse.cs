namespace Aliquota.WebApp.Models {
    public class AuthenticationResponse {
        public string Token { get; set; }
        public UserModel User { get; set; }
    }
}