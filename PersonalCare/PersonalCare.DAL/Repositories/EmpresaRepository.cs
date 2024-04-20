using Microsoft.EntityFrameworkCore;
using PersonalCare.DAL.Context;
using PersonalCare.Domain.Entities;
using PersonalCare.Domain.Interfaces;

namespace PersonalCare.DAL.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DataContextEmpresarial _data;

        public EmpresaRepository(DataContextEmpresarial data)
        {
            _data = data;
        }

        public Empresa? Buscar(string idEmpresa)
        {
            var entity = _data.EMPRESAs.Include(e => e.EMPRESA_EMAILs).FirstOrDefault(e => e.GUID == idEmpresa);

            if (entity is not null && entity.EMPRESA_EMAILs.Any())
            {
                return new Empresa(entity.ID, entity.NOME_FANTASIA, entity.EMPRESA_EMAILs.Select(e => new EmailEmpresa(e.ID, e.EMAIL, e.SENHA, e.SMTP, e.PORTA, e.SSL, e.ID_EMPRESA)).FirstOrDefault());
            }

            return null;
        }
    }
}
