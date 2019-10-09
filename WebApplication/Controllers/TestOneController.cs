using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class TestOneController : ControllerBase
    {
        public class Membership
        {
            public Guid groupid { get; set; }
            public Guid memberid { get; set; }
        }

        // GET: api/TestOne
        [HttpGet]
        // public List<Dictionary<string, string>> Get()
        public List<Dictionary<string, string>> Get()
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("USER ID = postgres;Password=hotdog;Server=localhost;Port=5432;Database=customer;Integrated Security=true;Pooling=true;");
                conn.Open();

                // to get data
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM membership", conn);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // int fieldCount = reader.GetValues(values);
                    Dictionary<string, string> row = new Dictionary<string, string>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row.Add(reader.GetName(i), reader[i].ToString());
                    }
                    list.Add(row);
                }


                // to get count
                // long count = new long();
                //NpgsqlCommand command = new NpgsqlCommand("SELECT count(*) FROM membership", conn);
                //count = (long)command.ExecuteScalar();

                conn.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/TestOne/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "test";
        }

        // POST: api/TestOne
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/TestOne/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
