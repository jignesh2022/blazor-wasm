using JWT.Algorithms;
using JWT.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    
    public class Utility
    {        

        public static string GenerateAccessToken(int userid, string role, string name, string secret)
        {
            /*
             * https://medium.com/swlh/a-secure-implementation-of-json-web-tokens-jwt-in-c-710d06ea243
               https://github.com/jwt-dotnet/jwt
             */
            string token = null;
            try
            {
                token = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(Encoding.ASCII.GetBytes(secret))
                .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(2).ToUnixTimeSeconds())
                .AddClaim("claim1", userid)
                .AddClaim("claim2", name)
                .AddClaim("claim3", role)
                .Encode();
            }
            catch (Exception)
            {
                throw;
            }

            return token;
            
        }
        
        /// <summary>
        /// verify token from user
        /// </summary>
        /// <param name="token">token from user</param>
        /// <param name="secret">secret for token from config</param>
        /// <returns>status, message, dictionary object with userid, name, role</returns>
        public static Tuple<string,string,IDictionary<string, object>> VerifyToken(string token, string secret)
        {
            IDictionary<string, object> dict = null;
            try
            { 
                dict = new JwtBuilder()
                 .WithAlgorithm(new HMACSHA256Algorithm())
                 .WithSecret(secret)
                 .MustVerifySignature()
                 .Decode<IDictionary<string, object>>(token);

                return Tuple.Create<string, string, IDictionary<string, object>>
                    ("", "", dict);
            }
            catch(JWT.Exceptions.TokenExpiredException)
            {
                return Tuple.Create<string,string, IDictionary<string, object>>
                    ("403","Access token has expired, please login again.",null);
            }
            catch (JWT.Exceptions.SignatureVerificationException)
            {
                return Tuple.Create<string, string, IDictionary<string, object>>
                    ("403","Access token has invalid signature.",null);
            }

            
        }
    }
}
