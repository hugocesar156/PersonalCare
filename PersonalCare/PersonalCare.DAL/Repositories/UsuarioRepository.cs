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
                        ID_PERMISSAO = item.Permissao.Id
                    });
                }

                _data.AddRange(entities);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public bool AlterarSenha(Usuario request)
        {
            var entity = _data.USUARIOs.FirstOrDefault(u => u.ID == request.Id && u.ID_EMPRESA == request.IdEmpresa);

            if (entity is not null)
            {
                entity.SENHA = request.Senha;
                entity.SALT = request.Salt;
                entity.DATA_ATUALIZACAO = DateTime.Now;

                _data.Update(entity);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public bool Atualizar(Usuario request)
        {
            var entity = _data.USUARIOs.FirstOrDefault(u => u.ID == request.Id && u.ID_EMPRESA == request.IdEmpresa);

            if (entity is not null)
            {
                entity.NOME = request.Nome;
                entity.EMAIL = request.Email;
                entity.ATIVO = request.Ativo;
                entity.DATA_ATUALIZACAO = DateTime.Now;

                _data.Update(entity);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public Usuario? Buscar(int idUsuario, string idEmpresa)
        {
            var entity = _data.USUARIOs
                .Include(u => u.USUARIO_PERMISSAOs)
                    .ThenInclude(up => up.ID_PERMISSAONavigation)
                        .ThenInclude(p => p.ID_ENTIDADENavigation)
                .Include(u => u.USUARIO_PERMISSAOs)
                    .ThenInclude(up => up.ID_PERMISSAONavigation)
                        .ThenInclude(p => p.ID_ACAONavigation)
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
                    entity.USUARIO_PERMISSAOs.Select(up => new PermissaoUsuario(up.ID, entity.ID, new Permissao(
                        up.ID_PERMISSAONavigation.ID,
                        up.ID_PERMISSAONavigation.NOME,
                        up.ID_PERMISSAONavigation.DESCRICAO,
                        new Entidade((byte)up.ID_PERMISSAONavigation.ID_ENTIDADENavigation.ID, up.ID_PERMISSAONavigation.ID_ENTIDADENavigation.NOME),
                        new Acao((byte)up.ID_PERMISSAONavigation.ID_ACAONavigation.ID, up.ID_PERMISSAONavigation.ID_ACAONavigation.NOME)))).ToList());
            }

            return null;
        }

        public Usuario? BuscarPorEmail(string email, string idEmpresa)
        {
            var entity = _data.USUARIOs
                .Include(u => u.USUARIO_PERMISSAOs)
                    .ThenInclude(up => up.ID_PERMISSAONavigation)
                        .ThenInclude(p => p.ID_ENTIDADENavigation)
                .Include(u => u.USUARIO_PERMISSAOs)
                    .ThenInclude(up => up.ID_PERMISSAONavigation)
                        .ThenInclude(p => p.ID_ACAONavigation)
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
                    entity.USUARIO_PERMISSAOs.Select(up => new PermissaoUsuario(up.ID, entity.ID, new Permissao(
                        up.ID_PERMISSAONavigation.ID,
                        up.ID_PERMISSAONavigation.NOME,
                        up.ID_PERMISSAONavigation.DESCRICAO,
                        new Entidade((byte)up.ID_PERMISSAONavigation.ID_ENTIDADENavigation.ID, up.ID_PERMISSAONavigation.ID_ENTIDADENavigation.NOME),
                        new Acao((byte)up.ID_PERMISSAONavigation.ID_ACAONavigation.ID, up.ID_PERMISSAONavigation.ID_ACAONavigation.NOME)))).ToList());
            }

            return null;
        }

        public bool EmailCadastrado(string email, string idEmpresa, int idUsuario = 0)
        {
            var entity = _data.USUARIOs.FirstOrDefault(u => ((idUsuario == 0 && u.EMAIL == email) || (u.EMAIL == email && u.ID != idUsuario)) && u.ID_EMPRESA == idEmpresa);
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

        public bool Deletar(int idUsuario, string idEmpresa)
        {
            var entity = _data.USUARIOs.Include(u => u.USUARIO_PERMISSAOs).FirstOrDefault(u => u.ID == idUsuario && u.ID_EMPRESA == idEmpresa);

            if (entity is not null)
            {
                _data.RemoveRange(entity.USUARIO_PERMISSAOs);
                _data.Remove(entity);

                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public List<Usuario> Listar(string idEmpresa)
        {
            var entities = _data.USUARIOs.Where(u => u.ID_EMPRESA == idEmpresa).ToList();
            return entities.Select(u => new Usuario(u.ID, u.NOME, u.EMAIL, u.ATIVO, u.DATA_CADASTRO, u.DATA_ATUALIZACAO, u.DATA_ULTIMO_ACESSO)).ToList();
        }

        public List<Permissao> ListarPermissoes()
        {
            var entities = _data.PERMISSAOs
                .Include(p => p.ID_ENTIDADENavigation)
                .Include(p => p.ID_ACAONavigation)
                .OrderBy(p => p.NOME).ToList();

            return entities.Select(p => new Permissao(p.ID, p.NOME, p.DESCRICAO,
                new Entidade((byte)p.ID_ENTIDADENavigation.ID, p.ID_ENTIDADENavigation.NOME),
                new Acao((byte)p.ID_ACAONavigation.ID, p.ID_ACAONavigation.NOME))).ToList();
        }

        public void RegistrarAcesso(int idUsuario)
        {
            var entity = _data.USUARIOs.FirstOrDefault(u => u.ID == idUsuario);

            if (entity is not null)
            {
                entity.DATA_ULTIMO_ACESSO = DateTime.Now;

                _data.Update(entity);
                _data.SaveChanges();
            }
        }

        public void RegistrarEnvioRedeficicaoSenha(RedefinicaoSenhaUsuario request)
        {
            var entity = new USUARIO_REDEFINICAO_SENHA
            {
                ID_USUARIO = request.IdUsuario,
                CODIGO = request.Codigo,
                DATA_PEDIDO = DateTime.Now
            };

            _data.Add(entity);  
            _data.SaveChanges();
        }

        public bool RemoverPermissoes(int idUsuario, List<int> permissoes)
        {
            var entities = _data.USUARIO_PERMISSAOs.Where(up => idUsuario == up.ID_USUARIO && permissoes.Contains(up.ID_PERMISSAO));

            if (entities.Any())
            {
                _data.RemoveRange(entities);
                return _data.SaveChanges() > 0;
            }

            return false;
        }
    }
}
