using PersonalCare.DAL.Context;
using PersonalCare.DAL.Models.Acesso;
using PersonalCare.Domain.Entities;
using PersonalCare.Domain.Interfaces;

namespace PersonalCare.DAL.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContextAcesso _data;
        public UsuarioRepository(DataContextAcesso data)
        {
            _data = data;
        }

        public Usuario? BuscarPorEmail(string email)
        {
            var entity = _data.USUARIOs.FirstOrDefault(u => u.EMAIL == email);

            if (entity is not null)
            {
                return new Usuario(entity.ID, entity.NOME, entity.EMAIL, entity.SENHA, entity.SALT, entity.ATIVO, entity.DATA_CADASTRO, entity.DATA_ATUALIZACAO, entity.DATA_ULTIMO_ACESSO);
            }

            return null;
        }

        public bool EmailCadastrado(string email)
        {
            var emailExistente = _data.USUARIOs.Select(u => u.EMAIL).FirstOrDefault(u => u == email);
            return !string.IsNullOrEmpty(emailExistente);
        }

        public int Cadastrar(Usuario request)
        {
            var entity = new USUARIO
            {
                NOME = request.Nome,
                EMAIL = request.Email,
                SENHA = request.Senha,
                SALT = request.Salt,
                ATIVO = true,
                DATA_CADASTRO = DateTime.Now,
                DATA_ATUALIZACAO = DateTime.Now
            };

            _data.Add(entity);
            _data.SaveChanges();

            return entity.ID;
        }
    }
}
