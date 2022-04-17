using PersonAPI.Repository.Entities;
using DAL;
using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.Models;

namespace BLL
{
    public class PersonBLL
    {
        private DAL.PersonDAL _DAL;
        private Mapper _PersonMapper;

        public PersonBLL()
        {
            _DAL = new DAL.PersonDAL();
            var _configPerson = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonModel>().ReverseMap());

            _PersonMapper = new Mapper(_configPerson);
        }

        public List<PersonModel> GetAllPeople()
        {
            List<Person> peopleFromDB = _DAL.GetAllPeople();
            List<PersonModel> peopleModel = _PersonMapper.Map<List<Person>, List<PersonModel>>(peopleFromDB);

            return peopleModel;
        }

        public PersonModel GetPersonById(int id)
        {
            var personEntity = _DAL.GetPersonById(id);

            if (personEntity == null)
            {
                throw new Exception("Invalid ID");
            }

            PersonModel personModel = _PersonMapper.Map<Person, PersonModel>(personEntity);
            
            return personModel;
        }

        public void PostPerson(PersonModel personModel)
        {
            Person personEntity = _PersonMapper.Map<PersonModel, Person>(personModel);
            _DAL.PostPerson(personEntity);
        }

        public void DeletePerson(int id)
        {
            var personEntity = _DAL.GetPersonById(id);

            if (personEntity == null)
            {
                throw new Exception("Invalid ID");
            }

            _DAL.DeletePerson(id);
        }

        public void PutPerson(int id)
        {
            var personEntity = _DAL.GetPersonById(id);

            if (personEntity == null)
            {
                throw new Exception("Invalid ID");
            }

            _DAL.PutPerson(id);
        }
    }
}
