using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace EchoBlog.Api.Controllers
{
    /// <summary>
    /// Jwt 颁发控制器
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class JwtController : ControllerBase
    {
        /// <summary>
        /// 获取 Jwt Token
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string Post()
        {
            // 声明
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // 颁发时间
                new Claim(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                // 生效时间
                new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                // 过期时间
                new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.Now.AddSeconds(300)).ToUnixTimeSeconds()}"),
                // 角色
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User")
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ericchoiericchoi"));
            var securityToken = new JwtSecurityToken(
                // 颁发者
                issuer: "EchoBlog.Api",
                // 订阅者
                audience: "EchoBlog.Ui",
                claims: claims,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );

            // 最终生成的 jwt token
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return jwtToken;
        }
    }
}
