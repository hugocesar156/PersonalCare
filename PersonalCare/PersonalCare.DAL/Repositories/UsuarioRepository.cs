using PersonalCare.DAL.Context.Data;
using PersonalCare.DAL.Models.Data;
using PersonalCare.Domain.Entities;
using PersonalCare.Domain.Interfaces;

namespace PersonalCare.DAL.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _data;
        public UsuarioRepository(DataContext data)
        {
            _data = data;
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
