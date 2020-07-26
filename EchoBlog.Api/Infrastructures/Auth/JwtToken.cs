using EchoBlog.Infrastructures.Core.Authorization;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Infrastructures.Auth
{
    public class JwtToken
    {
        readonly JwtTokenGenerator _jwtTokenGenerator;
        readonly IConfiguration _configuration;

        public JwtToken(JwtTokenGenerator jwtTokenGenerator, IConfiguration configuration)
        {
            this._jwtTokenGenerator = jwtTokenGenerator;
            this._configuration = configuration;
        }


        public async Task<string> GetJwtToken()
        {
            var token = "";
            var privateKey = _configuration.GetSection("JwtSetting")["PrivateKey"];
            var expireTime = _configuration.GetSection("JwtSetting")["ExpireTime"];
            if (double.TryParse(expireTime, out var seconds))
                token = await _jwtTokenGenerator.GenerateToken(privateKey, seconds);
            return token;
        }
    }
}
