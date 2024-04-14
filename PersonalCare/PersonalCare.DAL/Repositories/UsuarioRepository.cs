using PersonalCare.DAL.Context;
using PersonalCare.DAL.Models.Acesso;
using PersonalCare.DAL.Models.Empresarial;
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

        public Usuario? BuscarPorEmail(string email, string idEmpresa)
        {
            var entity = _data.USUARIOs.FirstOrDefault(u => u.EMAIL == email && u.ID_EMPRESA == idEmpresa);

            if (entity is not null)
            {
                return new Usuario(entity.ID, entity.NOME, entity.EMAIL, entity.SENHA, entity.SALT, entity.ATIVO, entity.ID_EMPRESA, entity.DATA_CADASTRO, entity.DATA_ATUALIZACAO, entity.DATA_ULTIMO_ACESSO);
            }

            return null;
        }

        public bool EmailCadastrado(string email, string idEmpresa)
        {
            var entity = _data.USUARIOs.FirstOrDefault(u => u.EMAIL == email && u.ID_EMPRESA == idEmpresa);
            return entity is not null;
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
                ID_EMPRESA = request.IdEmpresa,
                DATA_CADASTRO = DateTime.Now,
                DATA_ATUALIZACAO = DateTime.Now
            };

            _data.Add(entity);
            _data.SaveChanges();

            return entity.ID;
        }
    }
}
