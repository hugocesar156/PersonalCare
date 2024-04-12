using Microsoft.EntityFrameworkCore;
using PersonalCare.DAL.Context.Data;
using PersonalCare.DAL.Models.Data;
using PersonalCare.Domain.Entities;
using PersonalCare.Domain.Interfaces;

namespace PersonalCare.DAL.Repositories
{
    public class FichaRepository : IFichaRepository
    {
        private readonly DataContext _data;

        public FichaRepository(DataContext data)
        {
            _data = data;
        }

        public Ficha? BuscarPorConta(int idConta)
        {
            var entity = _data.FICHAs
                .Include(f => f.ITEM_FICHAs)
                .ThenInclude(i => i.ID_TREINONavigation.ID_CATEGORIA_TREINONavigation)
                .OrderByDescending(f => f.DATA_CRIACAO)
                .FirstOrDefault(f => f.ID_CONTA == idConta);

            if (entity is not null)
            {
                return new Ficha(
                    entity.ID, entity.DATA_CRIACAO, entity.DATA_CRIACAO, entity.ID_CONTA, entity.ID_USUARIO_CADASTRO,
                    entity.ITEM_FICHAs.Select(i => new ItemFicha(i.ID, i.GRUPO, (byte)i.SERIES, (byte)i.REPETICOES, i.ID_FICHA,
                    new Treino(
                        i.ID_TREINONavigation.ID, 
                        i.ID_TREINONavigation.NOME, 
                        i.ID_TREINONavigation.DESCRICAO,
                        new CategoriaTreino(
                            i.ID_TREINONavigation.ID_CATEGORIA_TREINONavigation.ID,
                            i.ID_TREINONavigation.ID_CATEGORIA_TREINONavigation.NOME)))).ToList());
            }

            return null;
        }

        public bool DeletarItemFicha(int idItemFicha)
        {
            var entity = _data.ITEM_FICHAs.FirstOrDefault(i => i.ID == idItemFicha);

            if (entity is not null)
            {
                _data.Remove(entity);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public int Inserir(Ficha request)
        {
            var entity = new FICHA
            {
                DATA_CRIACAO = DateTime.Now,
                DATA_VALIDADE = request.DataValidade,
                ID_CONTA = request.IdConta,
                ID_USUARIO_CADASTRO = request.IdUsuarioCadastro
            };

            _data.Add(entity);
            _data.SaveChanges();

            var entities = new List<ITEM_FICHA>();

            foreach (var item in request.ItemFicha)
            {
                var itemFicha = new ITEM_FICHA
                {
                    GRUPO = item.Grupo,
                    SERIES = item.Series,
                    REPETICOES = item.Repeticoes,
                    ID_TREINO = item.Id,
                    ID_FICHA = entity.ID
                };

                entities.Add(itemFicha);
            }

            _data.AddRange(entities);
            _data.SaveChanges();

            return entity.ID;
        }

        public int InserirItemFicha(ItemFicha request)
        {
            var entity = new ITEM_FICHA
            {
                GRUPO = request.Grupo,
                SERIES = request.Series,
                REPETICOES = request.Repeticoes,
                ID_TREINO = request.Treino.Id,
                ID_FICHA = request.IdFicha
            };

            _data.Add(entity);
            _data.SaveChanges();

            return entity.ID;
        }
    }
}
