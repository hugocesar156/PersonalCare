using PersonalCare.DAL.Context.Data;
using PersonalCare.DAL.Models.Data;
using PersonalCare.Domain.Entities;
using PersonalCare.Domain.Interfaces;

namespace PersonalCare.DAL.Repositories
{
    public class CategoriaTreinoRepository : ICategoriaTreinoRepository
    {
        private readonly DataContext _data;

        public CategoriaTreinoRepository(DataContext data)
        {
            _data = data;
        }

        public void Inserir(CategoriaTreino request)
        {
            var entity = new CATEGORIA_TREINO
            {
                NOME = request.Nome
            };

            _data.Add(entity);
            _data.SaveChanges();
        }
    }
}
