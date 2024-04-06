﻿using Microsoft.EntityFrameworkCore;
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
