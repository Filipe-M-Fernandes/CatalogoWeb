﻿namespace CatalogoWeb.Api.Authorization
{
    public sealed class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
    }
}
