using Microsoft.EntityFrameworkCore;
using PersonalCare.DAL.Context;

namespace PersonalCare.DAL.Repositories
{
    public class BaseRepository
    {
        protected static void SetConnectionString(DataContextBase data, string idEmpresa)
        {
            data.Database.SetConnectionString(data.Database.GetConnectionString()?.Replace("db_personalcare_base", $"db_personalcare_-{idEmpresa}"));
        }
    }
}
