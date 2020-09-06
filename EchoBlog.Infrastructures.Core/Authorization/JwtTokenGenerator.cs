using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EchoBlog.Infrastructures.Core.Authorization
{
    /// <summary>
    /// jwtToken 生成
    /// </summary>
    public class JwtTokenGenerator
    {
        /// <summary>
        /// 生成 Jwt Token
        /// </summary>
        /// <param name="privateKey">密钥</param>
        /// <param name="expireSeconds">过期时间（秒）</param>
        /// <param name="roles">生成当前 token 所对应的角色</param>
        /// <returns></returns>
        public async Task<string> GenerateToken(string privateKey, double expireSeconds, params string[] roles)
        {
            // 声明
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // 颁发时间
                new Claim(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                // 生效时间
                new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                // 过期时间
                new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.Now.AddSeconds(expireSeconds)).ToUnixTimeSeconds()}"),
                // 角色
                /*new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User")*/
            };

            var roleClaims = new List<Claim>();

            // 生成当前 token 所对应的角色
            if (roles != null && roles.Any())
            {
                Array.ForEach(roles, role =>
                {
                    if (!string.IsNullOrWhiteSpace(role)) roleClaims.Add(new Claim(ClaimTypes.Role, role));
                });
            }
            // 如果没有任何角色，则赋予最基本的 User 角色
            if (!roleClaims.Any())
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, "User"));
            }
            claims.AddRange(roleClaims);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));
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

            return await Task.FromResult(jwtToken);
        }
    }
}
