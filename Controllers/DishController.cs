using Microsoft.AspNetCore.Mvc;
using restaurant174.Data;
using Restaurant174.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace restaurant174.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public DishController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: api/<DishController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var preparedStatement = "SELECT * FROM DISHES";
                return new OkObjectResult(_db.Dishes.FromSqlRaw(preparedStatement));
            }
            catch(Exception e)
            {
                throw e;
            }
        }



        // POST api/<DishController>
        [HttpPost("name/{name}/calories/{calories}/type/{type}")]
        public IActionResult Post(string name, int calories, string type)
        {
            System.FormattableString preparedStatement = $@"INSERT INTO DISHES VALUES ({name},{calories},{type});";

            try
            {
                //  return new NotFoundObjectResult("NO");
                _db.Database.ExecuteSqlInterpolated(preparedStatement);
                _db.SaveChanges();
               // _db.Dishes.Add(new Dish() { name = name, calories = calories, type = type });
               // _db.SaveChanges();
                return Ok();
               
            }
            catch(Exception e)
            {
                throw new Exception("the prepared statement was " + preparedStatement+e.ToString());
            }
        }

    }
}
