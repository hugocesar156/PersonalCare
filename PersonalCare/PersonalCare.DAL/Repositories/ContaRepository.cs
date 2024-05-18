using Microsoft.EntityFrameworkCore;
using PersonalCare.DAL.Context;
using PersonalCare.DAL.Models.Base;
using PersonalCare.DAL.Repositories;
using PersonalCare.Domain.Entities;
using PersonalCare.Domain.Interfaces;

namespace PersonalCare.Domain.Repositories
{
    public class ContaRepository : BaseRepository, IContaRepository
    {
        private readonly DataContextBase _data;

        public ContaRepository(DataContextBase data)
        {
            _data = data;
        }

        public bool Atualizar(Conta request)
        {
            var entity = _data.CONTAs.FirstOrDefault(c => c.ID == request.Id);

            if (entity is not null)
            {
                entity.NOME = request.Nome;
                entity.EMAIL = request.Email;
                entity.CPF = request.Cpf;
                entity.ALTURA = request.Altura;
                entity.BIOTIPO = request.Biotipo;
                entity.DATA_NASCIMENTO = request.DataNascimento;
                entity.DATA_ATUALIZACAO = DateTime.Now;

                _data.Update(entity);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public bool AtualizarContato(ContatoConta request)
        {
            var entity = _data.CONTATO_CONTAs.FirstOrDefault(c => c.ID == request.Id);

            if (entity is not null)
            {
                entity.NOME = request.Nome;
                entity.NUMERO = request.Numero;
                entity.DDD = request.Ddd;
                entity.DDI = request.Ddi;

                _data.Update(entity);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public Conta? Buscar(int idConta)
        {
            var entity = _data.CONTAs.Include(c => c.CONTATO_CONTa).FirstOrDefault(c => c.ID == idConta);

            if (entity is not null)
            {
                return new Conta(
                    entity.ID,
                    entity.NOME,
                    entity.EMAIL,
                    entity.CPF,
                    entity.ALTURA,
                    entity.BIOTIPO,
                    entity.DATA_NASCIMENTO,
                    entity.DATA_CADASTRO,
                    entity.DATA_ATUALIZACAO,
                    entity.ID_USUARIO_CADASTRO,
                    entity.CONTATO_CONTa.Select(c =>
                    new ContatoConta(
                        c.ID,
                        c.NOME,
                        c.NUMERO,
                        c.DDD,
                        c.DDI,
                        c.ID_CONTA)).ToList());
            }

            return null;
        }

        public (string cpf, string email) BuscarDadosExistentes(string cpf, string email, int idConta = 0)
        {
            var entity = _data.CONTAs.FirstOrDefault(c => (idConta == 0 || c.ID != idConta) && (c.CPF == cpf || c.EMAIL == email));

            if (entity is not null)
            {
                return (entity.CPF, entity.EMAIL);
            }

            return (string.Empty, string.Empty);
        }

        public Conta? BuscarPorEmail(string email, string idEmpresa)
        {
            SetConnectionString(_data, idEmpresa);

            var entity = _data.CONTAs.FirstOrDefault(c => c.EMAIL == email);

            if (entity is not null)
            {
                return new Conta(entity.ID, entity.NOME, entity.EMAIL, entity.CPF, entity.ALTURA, entity.BIOTIPO, entity.DATA_NASCIMENTO, entity.SENHA, entity.SALT);
            }

            return null;
        }

        public bool Deletar(int idConta)
        {
            var entity = _data.CONTAs.Include(c => c.CONTATO_CONTa).FirstOrDefault(c => c.ID == idConta);

            if (entity is not null)
            {
                _data.RemoveRange(entity.CONTATO_CONTa);
                _data.Remove(entity);

                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public bool DeletarContato(int idContato)
        {
            var entity = _data.CONTATO_CONTAs.FirstOrDefault(c => c.ID == idContato);

            if (entity is not null)
            {
                _data.Remove(entity);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public int Inserir(Conta request)
        {
            var entity = new CONTum
            {
                NOME = request.Nome,
                EMAIL = request.Email,
                CPF = request.Cpf,
                ALTURA = request.Altura,
                BIOTIPO = request.Biotipo,
                DATA_NASCIMENTO = request.DataNascimento,
                DATA_CADASTRO = DateTime.Now,
                DATA_ATUALIZACAO = DateTime.Now,
                ID_USUARIO_CADASTRO = request.IdUsuarioCadastro
            };

            _data.CONTAs.Add(entity);
            _data.SaveChanges();

            return entity.ID;
        }

        public bool InserirContato(ContatoConta request)
        {
            var conta = _data.CONTAs.FirstOrDefault(c => c.ID == request.IdConta);

            if (conta is not null)
            {
                var entity = new CONTATO_CONTum
                {
                    NOME = request.Nome,
                    NUMERO = request.Numero,
                    DDD = request.Ddd,
                    DDI = request.Ddi,
                    ID_CONTA = request.IdConta
                };

                _data.CONTATO_CONTAs.Add(entity);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public bool InserirContato(List<ContatoConta> request)
        {
            var entities = new List<CONTATO_CONTum>();

            foreach (var contato in request)
            {
                entities.Add(new CONTATO_CONTum
                {
                    NOME = contato.Nome,
                    NUMERO = contato.Numero,
                    DDD = contato.Ddd,
                    DDI = contato.Ddi,
                    ID_CONTA = contato.IdConta
                });
            }

            _data.CONTATO_CONTAs.AddRange(entities);
           return _data.SaveChanges() > 0;
        }

        public List<Conta> Listar()
        {
            var entities = _data.CONTAs.ToList();

            return entities.Select(c =>
                new Conta(
                    c.ID,
                    c.NOME,
                    c.EMAIL,
                    c.CPF,
                    c.ALTURA,
                    c.BIOTIPO,
                    c.DATA_NASCIMENTO,
                    c.DATA_CADASTRO,
                    c.DATA_ATUALIZACAO,
                    c.ID_USUARIO_CADASTRO,
                    new List<ContatoConta>())).ToList();
        }
    }
}
