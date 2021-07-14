using System;
using System.Text;
using System.Text.Json.Serialization;

namespace Aliquota.WebApp.Configuration
{
    public class AppConfig
    {
        #region  Authentication
        public string TokenSecretKeyBase64 { get; set; }
        public byte[] TokenSecretKey
            => Convert.FromBase64String(TokenSecretKeyBase64);
        public int TokenValidityTimeMinutes { get; set; }
        public TimeSpan TokenValidityTime
            => TimeSpan.FromMinutes(TokenValidityTimeMinutes);
        #endregion

    }
}