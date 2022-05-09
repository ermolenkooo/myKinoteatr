using DAL.Interfaces;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class CountryRepositorySQL : IRepository<Country> //репозиторий стран
    {
        private FilmContext db; //контекст базы данных

        public CountryRepositorySQL(FilmContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Country> GetList() //получение списка стран
        {
            List<Country> countries = db.Country.ToList();
            db.Dispose();
            return countries;
        }

        public Country GetItem(int id) //получение страны по id
        {
            return db.Country.Find(id);
        }

        public void Create(Country C) //добавление новой страны
        {
            db.Country.Add(C);
        }

        public void Update(Country C) //обновление страны
        {
            db.Entry(C).State = EntityState.Modified;
        }

        public void Delete(int id) //удаление страны
        {
            Country C = db.Country.Find(id);
            if (C != null)
                db.Country.Remove(C);
        }
    }
}

