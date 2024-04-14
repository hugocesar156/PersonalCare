using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
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

            var permissoes = new Dictionary<string, List<string>>();

            foreach (var grupo in usuario.Permissoes.GroupBy(up => up.Entidade))
            {
                permissoes.Add(grupo.Key.Nome, grupo.Select(p => p.Acao.Nome).ToList());
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(PersonalCareClaims.ID_USUARIO, usuario.Id.ToString()),
                    new Claim(PersonalCareClaims.ID_EMPRESA, idEmpresa),
                    new Claim(PersonalCareClaims.PERMISSOES, JsonConvert.SerializeObject(permissoes))
                }),
                Expires = DateTime.Now.AddDays(1), 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
