using DAL.Interfaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SessionRepositorySQL : IRepository<Session> //репозиторий сеансов
    {
        private FilmContext db; //контекст базы данных 

        public SessionRepositorySQL(FilmContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Session> GetList() //получение списка сеансов
        {
            return db.Session.ToList();
        }

        public Session GetItem(int id) //получение сеанса по id
        {
            return db.Session.Find(id);
        }

        public void Create(Session s) //добавление нового сеанса
        {
            db.Session.Add(s);
        }

        public void Update(Session s) //обновление сеанса
        {
            db.Entry(s).State = EntityState.Modified;
        }

        public void Delete(int id) //удаление сеанса
        {
            Session s = db.Session.Find(id);
            if (s != null)
                db.Session.Remove(s);
        }
    }
}

