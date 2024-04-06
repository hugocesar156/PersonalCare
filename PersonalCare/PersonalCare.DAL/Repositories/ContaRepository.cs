using Microsoft.EntityFrameworkCore;
using PersonalCare.DAL.Context.Data;
using PersonalCare.DAL.Models.Data;
using PersonalCare.Domain.Entities;
using PersonalCare.Domain.Interfaces;

namespace PersonalCare.Domain.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly DataContext _data;

        public ContaRepository(DataContext data)
        {
            _data = data;
        }

        public Conta? Atualizar(Conta request)
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
                entity.DATA_ATUALIZACAO = request.DataAtualizacao;

                _data.Update(entity);
                _data.SaveChanges();

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
                    new List<ContatoConta>());
            }

            return null;
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

        public Conta? Buscar(string cpf)
        {
            var entity = _data.CONTAs.FirstOrDefault(c => c.CPF == cpf);

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
                    new List<ContatoConta>());
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
                DATA_CADASTRO = request.DataCadastro,
                DATA_ATUALIZACAO = request.DataAtualizacao,
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

        public void InserirContato(List<ContatoConta> request)
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
            _data.SaveChanges();
        }

        public List<Conta>? Listar()
        {
            var entities = _data.CONTAs.ToList();

            if (entities is not null && entities.Count > 0)
            {
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

            return null;
        }
    }
}
