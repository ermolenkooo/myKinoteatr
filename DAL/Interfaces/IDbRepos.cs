using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IDbRepos //интерфейс для взаимодействия с репозиториями
    {
        IRepository<Country> Countries { get; }
        IRepository<Film> Films { get; }
        IRepository<Genre> Genres { get; }
        IRepository<Hall> Halls { get; }
        IRepository<Session> Sessions { get; }
        IRepository<Ticket> Tickets { get; }
        int Save();
    }
}
