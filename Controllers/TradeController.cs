using communitradeRestServer.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace communitradeRestServer.Controllers
{
    // need to add base controller name before controller executes
    [Route("[controller]")]
    [ApiController] // characteristics: what kind of controller
    public class TradeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TradeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet] // the GetAllStudents API is going to generate a get request
        [Route("GetAllItems")] // give api name

        public Response GetAllItems()
        {
            Response response = new Response();

            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("tradeConnection"));

            DBApplication dBApplication = new DBApplication();

            response = dBApplication.GetAllItems(con);

            return response;// returning response to client
        }

        [HttpPost]
        [Route("AddUser")]

        public Response AddUser(User user)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("tradeConnection"));
            DBApplication dba = new DBApplication();

            response = dba.AddUser(con, user);
            return response;
        }

        [HttpGet] // the GetAllStudents API is going to generate a get request
        [Route("GetUser")]

        public Response GetUser(User user)
        {
            Response response = new Response();
            return response;
        }
    }
    }
