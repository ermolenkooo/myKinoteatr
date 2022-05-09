using DAL.Interfaces;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class HallRepositorySQL : IRepository<Hall> //репозиторий залов
    {
        private FilmContext db; //контекст базы данных

        public HallRepositorySQL(FilmContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Hall> GetList() //получение списка залов
        {
            return db.Hall.ToList();
        }

        public Hall GetItem(int id) //получение зала по id
        {
            return db.Hall.Find(id);
        }

        public void Create(Hall h) //добавление нового зала
        {
            db.Hall.Add(h);
        }

        public void Update(Hall h) //обновление зала
        {
            db.Entry(h).State = EntityState.Modified;
        }

        public void Delete(int id) //удаление зала
        {
            Hall h = db.Hall.Find(id);
            if (h != null)
                db.Hall.Remove(h);
        }
    }
}

