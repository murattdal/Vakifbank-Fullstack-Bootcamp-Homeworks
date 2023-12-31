﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.CustomerOperations.Commands.CreateToken;
using WebApi.Application.CustomerOperations.Commands.DeleteCustomer;
using WebApi.Application.CustomerOperations.Commands.RefreshToken;
using WebApi.Application.TokenOperations.Models;
using WebApi.DbOprations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CustomerController(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        // GET İsteği - Yeni bir RefreshToken oluşturmak için kullanılır.
        [HttpGet("refreshToken")] 
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {

            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefrehToken = token;
            var result = command.Handle();
            return result;

        }

        // POST İsteği - Yeni bir müşteri oluşturur.
        [HttpPost("create")] 
        public IActionResult CreateCustomer([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = newCustomer;
            command.Handle();

            return Ok();
        }

        // POST İsteği - Token oluşturur.
        [HttpPost("connect/token")] 
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {

            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();
            return token;

        }


        // DELETE İsteği - Belirtilen ID'ye sahip müşteriyi siler.
        [HttpDelete("{id}")] 
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = id;

            command.Handle();

            return Ok();
           
        }
    }
}
