using PersonalCare.DAL.Context;
using PersonalCare.DAL.Models.Base;
using PersonalCare.Domain.Entities;
using PersonalCare.Domain.Interfaces;

namespace PersonalCare.DAL.Repositories
{
    public class CategoriaTreinoRepository : ICategoriaTreinoRepository
    {
        private readonly DataContextBase _data;

        public CategoriaTreinoRepository(DataContextBase data)
        {
            _data = data;
        }

        public bool Atualizar(CategoriaTreino request)
        {
            var entity = _data.CATEGORIA_TREINOs.FirstOrDefault(c => c.ID == request.Id);

            if (entity is not null)
            {
                entity.NOME = request.Nome;

                _data.Update(entity);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public CategoriaTreino? Buscar(int idCategoriaTreino)
        {
            var entity = _data.CATEGORIA_TREINOs.FirstOrDefault(c => c.ID == idCategoriaTreino);

            if (entity is not null)
            {
                return new CategoriaTreino(entity.ID, entity.NOME);
            }

            return null;
        }

        public bool Deletar(int idCategoriaTreino)
        {
            var entity = _data.CATEGORIA_TREINOs.FirstOrDefault(c => c.ID == idCategoriaTreino);

            if (entity is not null)
            {
                _data.Remove(entity);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public int Inserir(CategoriaTreino request)
        {
            var entity = new CATEGORIA_TREINO
            {
                NOME = request.Nome
            };

            _data.Add(entity);
            _data.SaveChanges();

            return entity.ID;
        }

        public List<CategoriaTreino> Listar()
        {
            var entities = _data.CATEGORIA_TREINOs.ToList();
            return entities.Select(c => new CategoriaTreino(c.ID, c.NOME)).ToList();
        }
    }
}
