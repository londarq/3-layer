using PersonAPI.Repository;
using PersonAPI.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class PersonDAL
    {
        public List<Person> GetAllPeople()
        {
            var db = new PersonDbContext();
            return db.Person.ToList();
        }

        public Person GetPersonById(int id)
        {
            var db = new PersonDbContext();
            Person person = new Person();

            person = db.Person.FirstOrDefault(x => x.Id == id);

            return person;
        }

        public void PostPerson(Person person)
        {
            var db = new PersonDbContext();
            db.Add(person);
            db.SaveChanges();
        }

        public void DeletePerson(int id)
        {
            var db = new PersonDbContext();
            Person person = new Person();

            person = db.Person.FirstOrDefault(x => x.Id == id);

            db.Person.Remove(person);
            db.SaveChanges();
        }

        public void PutPerson(Person person)
        {
            var db = new PersonDbContext();
            db.Update(person);
            db.SaveChanges();
        }
    }
}
