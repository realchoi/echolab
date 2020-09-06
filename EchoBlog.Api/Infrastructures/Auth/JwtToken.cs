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


        /// <summary>
        /// 获取 jwt token
        /// </summary>
        /// <param name="roles">生成当前 token 所对应的角色</param>
        /// <returns></returns>
        public async Task<string> GetJwtToken(params string[] roles)
        {
            var token = "";
            var privateKey = _configuration.GetSection("JwtSetting")["PrivateKey"];
            var expireTime = _configuration.GetSection("JwtSetting")["ExpireTime"];
            if (double.TryParse(expireTime, out var expireSeconds))
                token = await _jwtTokenGenerator.GenerateToken(privateKey, expireSeconds, roles);
            return token;
        }
    }
}
