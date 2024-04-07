using PersonalCare.DAL.Context.Data;
using PersonalCare.DAL.Models.Data;
using PersonalCare.Domain.Entities;
using PersonalCare.Domain.Interfaces;

namespace PersonalCare.DAL.Repositories
{
    public class TreinoRepository : ITreinoRepository
    {
        private readonly DataContext _data;
        public TreinoRepository(DataContext data)
        {
            _data = data;
        }

        public bool Atualizar(Treino request)
        {
            throw new NotImplementedException();
        }

        public Treino Buscar(int idTreino)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(int idTreino)
        {
            throw new NotImplementedException();
        }

        public int Inserir(Treino request)
        {
            var entity = new TREINO
            {
                NOME = request.Nome,
                DESCRICAO = request.Descricao,
                ID_CATEGORIA_TREINO = request.Categoria.Id
            };

            _data.Add(entity);
            _data.SaveChanges();

            return entity.ID;
        }

        public List<Treino> Listar(int idCategoria = 0)
        {
            throw new NotImplementedException();
        }
    }
}
