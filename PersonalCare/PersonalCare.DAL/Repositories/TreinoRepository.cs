using Microsoft.EntityFrameworkCore;
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
            var entity = _data.TREINOs.FirstOrDefault(t => t.ID == request.IdTreino);

            if (entity is not null)
            {
                entity.NOME = request.Nome;
                entity.DESCRICAO = request.Descricao;
                entity.ID_CATEGORIA_TREINO = request.Categoria.Id;

                _data.Update(entity);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public Treino? Buscar(int idTreino)
        {
            var entity = _data.TREINOs.Include(t => t.ID_CATEGORIA_TREINONavigation).FirstOrDefault(t => t.ID == idTreino);

            if (entity is not null)
            {
                return new Treino(entity.ID, entity.NOME, entity.DESCRICAO, new CategoriaTreino(entity.ID_CATEGORIA_TREINONavigation.ID, entity.ID_CATEGORIA_TREINONavigation.NOME));
            }

            return null;
        }

        public bool Deletar(int idTreino)
        {
            var entity = _data.TREINOs.FirstOrDefault(t => t.ID == idTreino);

            if (entity is not null)
            {
                _data.Remove(entity);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public bool ExisteTreinoPorCategoria(int idCategoria)
        {
            var entity = _data.TREINOs.FirstOrDefault(t => t.ID_CATEGORIA_TREINO == idCategoria);
            return entity is not null;
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
            var entities = _data.TREINOs
                .Include(t => t.ID_CATEGORIA_TREINONavigation)
                .Where(t => idCategoria == 0 || t.ID_CATEGORIA_TREINO == idCategoria)
                .OrderBy(t => t.NOME).ToList();

            return entities.Select(t => new Treino(t.ID, t.NOME, t.DESCRICAO, new CategoriaTreino(t.ID_CATEGORIA_TREINONavigation.ID, t.ID_CATEGORIA_TREINONavigation.NOME))).ToList();
        }
    }
}
