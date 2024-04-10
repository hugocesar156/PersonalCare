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

        public int Inserir(Ficha request)
        {
            var entity = new FICHA
            {
                DATA_CRIACAO = request.DataCriacao,
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
                    ID_TREINO = item.IdTreino,
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
                ID_TREINO = request.IdTreino,
                ID_FICHA = request.IdFicha
            };

            _data.Add(entity);
            _data.SaveChanges();

            return entity.ID;
        }
    }
}
