using Microsoft.EntityFrameworkCore;
using PersonalCare.DAL.Context;

namespace PersonalCare.DAL.Repositories
{
    public class BaseRepository
    {
        protected static void SetConnectionString(DataContextBase data, string idEmpresa)
        {
            data.Database.SetConnectionString(string.Format(data.Database.GetConnectionString() ?? string.Empty, idEmpresa));
        }
    }
}
