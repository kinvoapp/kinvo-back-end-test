namespace Aliquota.WebApp.Models {
    public class AuthenticationResponse {
        public bool Success { get; set; }
        public string Token { get; set; }
        public UserModel User { get; set; }
    }
}