using PersonalCare.DAL.Context;
using PersonalCare.DAL.Models.Base;
using PersonalCare.Domain.Entities;
using PersonalCare.Domain.Interfaces;

namespace PersonalCare.DAL.Repositories
{
    public class HorarioTreinoContaRepository : IHorarioTreinoContaRepository
    {
        private readonly DataContextBase _data;

        public HorarioTreinoContaRepository(DataContextBase data)
        {
            _data = data;
        }

        public bool Atualizar(HorarioContaTreino request)
        {
            var entity = _data.HORARIO_CONTA_TREINOs.FirstOrDefault(h => h.ID == request.Id);

            if (entity is not null)
            {
                entity.HORA_INICIO = request.HoraInicio;
                entity.HORA_FIM = request.HoraFim;
                entity.ID_USUARIO = request.IdUsuario;

                _data.Update(entity);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public HorarioContaTreino? Buscar(int idConta)
        {
            var entity = _data.HORARIO_CONTA_TREINOs.FirstOrDefault(h => h.ID_CONTA == idConta);

            if (entity is not null)
            {
                return new HorarioContaTreino(entity.ID, entity.HORA_INICIO, entity.HORA_FIM, entity.ID_CONTA, entity.ID_USUARIO);
            }

            return null;
        }

        public bool Deletar(int idHorarioTreino)
        {
            var entity = _data.HORARIO_CONTA_TREINOs.FirstOrDefault(h => h.ID == idHorarioTreino);

            if (entity is not null)
            {
                _data.Remove(entity);
                return _data.SaveChanges() > 0;
            }

            return false;
        }

        public bool Inserir(HorarioContaTreino request)
        {
            var entity = new HORARIO_CONTA_TREINO
            {
                HORA_INICIO = request.HoraInicio,
                HORA_FIM = request.HoraFim,
                ID_CONTA = request.IdConta,
                ID_USUARIO = request.IdUsuario
            };

            _data.Add(entity);
            return _data.SaveChanges() > 0;
        }

        public HorarioContaTreino? VerificaDisponibilidade(int idConta)
        {
            var entity = _data.HORARIO_CONTA_TREINOs.FirstOrDefault(h => h.ID_CONTA == idConta);

            if (entity is not null)
            {
                return new HorarioContaTreino(entity.ID, entity.HORA_INICIO, entity.HORA_FIM, entity.ID_CONTA, entity.ID_USUARIO);
            }

            return null;
        }

        public HorarioContaTreino? VerificaDisponibilidade(TimeSpan horaInicio, TimeSpan horaFim, int idUsuario)
        {
            var entity = _data.HORARIO_CONTA_TREINOs.FirstOrDefault(h => h.ID_USUARIO == idUsuario &&
            ((h.HORA_INICIO >= horaInicio && h.HORA_FIM <= horaInicio) || (h.HORA_INICIO >= horaFim && h.HORA_FIM <= horaFim)));

            if (entity is not null)
            {
                return new HorarioContaTreino(entity.ID, entity.HORA_INICIO, entity.HORA_FIM, entity.ID_CONTA, entity.ID_USUARIO);
            }

            return null;
        }
    }
}
