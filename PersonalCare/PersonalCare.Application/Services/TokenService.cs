using Microsoft.IdentityModel.Tokens;
using PersonalCare.Domain.Entities;
using PersonalCare.Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PersonalCare.Application.Services
{
    public class TokenService
    {
        public static string GerarToken(Usuario usuario, string idEmpresa, string signingKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(signingKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(PersonalCareClaims.ID_USUARIO, usuario.Id.ToString()),
                    new Claim(PersonalCareClaims.ID_EMPRESA, idEmpresa)
                }),
                Expires = DateTime.Now.AddDays(1), 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
