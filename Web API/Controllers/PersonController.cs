using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonAPI.Repository;
using PersonAPI.Repository.Entities;
using BLL.Models;

namespace PersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly BLL.PersonBLL _BLL;

        public PersonController()
        {
            _BLL = new BLL.PersonBLL();
        }

        // GET: api/Person
        [HttpGet]
        public List<PersonModel> GetAllPeople()
        {
            return _BLL.GetAllPeople();
        }

        // GET: api/Person/get?id=5
        [HttpGet]
        [Route("get")]
        public PersonModel GetPersonById(int id)
        {
            return _BLL.GetPersonById(id);
        }

        // POST: api/Person/post
        [HttpPost]
        [Route("post")]
        public void PostPerson([FromBody] PersonModel personModel)
        {
            _BLL.PostPerson(personModel);
        }

        // DELETE: api/Person/delete
        [HttpDelete]
        [Route("delete")]
        public void DeletePerson(int id)
        {
            _BLL.DeletePerson(id);
        }

        // PUT: api/Person/5
        [HttpPut]
        [Route("put")]
        public void PutPerson(int id, [FromBody] PersonModel personModel)
        {
            personModel.Id = id;
            _BLL.PutPerson(personModel);
        }
    }
}
