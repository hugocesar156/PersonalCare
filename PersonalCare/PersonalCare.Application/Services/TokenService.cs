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
        public static string GerarTokenAutenticacao(Usuario usuario, string idEmpresa, string signingKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(signingKey);

            var permissoes = new Dictionary<string, List<string>>();

            foreach (var entidade in usuario.Permissoes.Select(up => up.Permissao).GroupBy(p => p.Entidade.Nome))
            {
                permissoes.Add(entidade.Key, entidade.Select(p => p.Acao.Nome).ToList());
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

        public static string GerarTokenRedefinicaoSenha(int idUsuario, string idEmpresa, string signingKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(signingKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(PersonalCareClaims.ID_USUARIO, idUsuario.ToString()),
                    new Claim(PersonalCareClaims.ID_EMPRESA, idEmpresa)
                }),
                Expires = DateTime.Now.AddMinutes(10),
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
