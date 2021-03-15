using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accoutService;

        public AccountController(IAccountService accoutService)
        {
            _accoutService = accoutService;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDto dto)
        {
            _accoutService.RegisterUser(dto);
            return Ok();
        }
    }
}
