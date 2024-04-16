using Microsoft.EntityFrameworkCore;
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

        public bool AdicionarPermissoes(List<PermissaoUsuario> request)
        {
            var usuario = _data.USUARIOs.FirstOrDefault(u => u.ID == request[0].IdUsuario);

            if (usuario is not null)
            {
                var entities = new List<USUARIO_PERMISSAO>();

                foreach (var item in request)
                {
                    entities.Add(new USUARIO_PERMISSAO
                    {
                        ID_USUARIO = item.IdUsuario,
                        ID_ENTIDADE = item.Entidade.Id,
                        ID_ACAO = item.Acao.Id
                    });
                }

                _data.AddRange(entities);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public Usuario? Buscar(int idUsuario, string idEmpresa)
        {
            var entity = _data.USUARIOs
                .Include(u => u.USUARIO_PERMISSAOs).ThenInclude(u => u.ID_ENTIDADENavigation)
                .Include(u => u.USUARIO_PERMISSAOs).ThenInclude(u => u.ID_ACAONavigation)
                .FirstOrDefault(u => u.ID == idUsuario && u.ID_EMPRESA == idEmpresa);

            if (entity is not null)
            {
                return new Usuario(
                    entity.ID,
                    entity.NOME, 
                    entity.EMAIL, 
                    entity.SENHA, 
                    entity.SALT, 
                    entity.ATIVO, 
                    entity.ID_EMPRESA, 
                    entity.DATA_CADASTRO,
                    entity.DATA_ATUALIZACAO, 
                    entity.DATA_ULTIMO_ACESSO,
                    entity.USUARIO_PERMISSAOs.Select(u => new PermissaoUsuario(
                        u.ID, entity.ID,
                        new Entidade((byte)u.ID_ENTIDADE, u.ID_ENTIDADENavigation.NOME),
                        new Acao((byte)u.ID_ACAO, u.ID_ACAONavigation.NOME))).ToList());
            }

            return null;
        }

        public Usuario? BuscarPorEmail(string email, string idEmpresa)
        {
            var entity = _data.USUARIOs
                .Include(u => u.USUARIO_PERMISSAOs).ThenInclude(u => u.ID_ENTIDADENavigation)
                .Include(u => u.USUARIO_PERMISSAOs).ThenInclude(u => u.ID_ACAONavigation)
                .FirstOrDefault(u => u.EMAIL == email && u.ID_EMPRESA == idEmpresa);

            if (entity is not null)
            {
                return new Usuario(
                    entity.ID,
                    entity.NOME, 
                    entity.EMAIL,
                    entity.SENHA, 
                    entity.SALT, 
                    entity.ATIVO, 
                    entity.ID_EMPRESA,
                    entity.DATA_CADASTRO,
                    entity.DATA_ATUALIZACAO, 
                    entity.DATA_ULTIMO_ACESSO,
                    entity.USUARIO_PERMISSAOs.Select(u => new PermissaoUsuario(
                        u.ID, entity.ID,
                        new Entidade((byte)u.ID_ENTIDADE, u.ID_ENTIDADENavigation.NOME),
                        new Acao((byte)u.ID_ACAO, u.ID_ACAONavigation.NOME))).ToList());
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

        public bool RemoverPermissoes(List<int> permissoes)
        {
            var entities = _data.USUARIO_PERMISSAOs.Where(up => permissoes.Contains(up.ID));

            if (entities.Any())
            {
                _data.RemoveRange(entities);
                return _data.SaveChanges() > 0;
            }

            return false;
        }
    }
}
