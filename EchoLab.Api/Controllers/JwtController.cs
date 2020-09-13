using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EchoLab.Infrastructures.Core.Snowflake;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace EchoLab.Api.Controllers
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
        public async Task<IActionResult> Post()
        {
            var passed = true;
            // 从数据库读取用户名密码，进行验证
            // 验证不通过，则返回 Unauthorized
            if (!passed)
                return await Task.FromResult(Unauthorized("用户名或密码不正确"));
            else
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
                    issuer: "EchoLab.Api",
                    // 订阅者
                    audience: "EchoLab.Ui",
                    claims: claims,
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

                // 最终生成的 jwt token
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(securityToken);

                return await Task.FromResult(Ok(jwtToken));
            }
        }
    }
}
