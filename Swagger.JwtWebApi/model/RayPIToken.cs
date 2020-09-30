using Microsoft.IdentityModel.Tokens;
using Swagger.JwtRepostory.ModelToken;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Swagger.JwtWebApi.model
{
    /// <summary>
    /// 令牌类
    /// </summary>
    public class RayPIToken
    {
        public RayPIToken() 
        {
        
        }

        /// <summary>
        /// 获取JWT字符串并存入缓存
        /// </summary>
        /// <param name=""></param>
        /// <param name="expiressSlidiing"></param>
        /// <param name="expiressAbsolute"></param>
        /// <returns></returns>
        public static string IssueJWT(TokenModel model, TimeSpan expiressSlidiing, TimeSpan expiressAbsolute) 
        {
            DateTime utc = DateTime.UtcNow;
            Claim[] claims = new Claim[]
            {
             new Claim(JwtRegisteredClaimNames.Sub,model.Sub),
             new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),  //jwt 唯一标识符
             new Claim(JwtRegisteredClaimNames.Iat,utc.ToString(),ClaimValueTypes.Integer64) //JWT颁发的时间，采用标准unix时间，用于验证过期
            };

            JwtSecurityToken jwtSecurity = new JwtSecurityToken
                (
                  issuer:"PayPI", //jwt 签发者非必须
                  audience:model.Uname,//jwt 接收者 非必须
                  claims:claims, //声明集合
                  expires:utc.AddHours(12), //指定token的生命周期，unix事件戳格式，非必需
                  signingCredentials: new Microsoft.IdentityModel.Tokens.
                  SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("RayPI's Secret Key")), SecurityAlgorithms.HmacSha256)) //使用私钥进行签名加密
                );
        }
    }
}
