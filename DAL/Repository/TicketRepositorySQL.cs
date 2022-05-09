using DAL.Interfaces;
using DAL.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repository
{
    public class TicketRepositorySQL : IRepository<Ticket> //репозиторий билетов
    {
        private FilmContext db; //контекст базы данных

        public TicketRepositorySQL(FilmContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Ticket> GetList() //получение списка билетов
        {
            return db.Ticket.ToList();
        }

        public Ticket GetItem(int id) //получение билета по id
        {
            return db.Ticket.Find(id);
        }

        public void Create(Ticket t) //добавление нового билета
        {
            db.Ticket.Add(t);
        }

        public void Update(Ticket t) //обновление билета
        {
            db.Entry(t).State = EntityState.Modified;
        }

        public void Delete(int id) //удаление билета
        {
            Ticket t = db.Ticket.Find(id);
            if (t != null)
                db.Ticket.Remove(t);
        }
    }
}

