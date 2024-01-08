using CMCapital.Server.Data;
using CMCapital.Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CMCapital.Server.Services
{
    public class TokenService
    {
        private DataContext _db;

        public TokenService(DataContext db)
        {
            _db = db;
        }

        public TokenService() { }

        public object GenerateToken(Login login)
        {
            try
            {
                string resultToken = string.Empty;

                if (login.ID != null)
                {
                    byte[] key = Encoding.ASCII.GetBytes(TokenKey.Secret);
                    var tokenConfig = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("userID", value: login.ID.ToString()),
                        }),
                        Expires = DateTime.UtcNow.AddHours(3),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenConfig);
                    var tokenString = tokenHandler.WriteToken(token);
                    resultToken = tokenString;
                }

                return new
                {
                    result = resultToken
                };
            }
            catch
            {
                return new
                {
                    resultToken = "Error generating token"
                };
            }
        }
    }
}
