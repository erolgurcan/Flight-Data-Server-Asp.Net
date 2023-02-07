﻿using flight_data_server.Interface;
using flight_data_server.Models;
using flight_data_server.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace flight_data_server.Controllers
    {


    [Route("api/UsersAuth")]
    [ApiController]

    public class UsersController : Controller
        {

        private readonly IUserRepository _userRepo;
        protected APIResponse _response;

        public UsersController(IUserRepository userRepo)
            {
            _userRepo = userRepo;
            this._response = new();
            }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
            {

            var loginResponse = await _userRepo.Login(model);

            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
                {

                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessage.Add("Username or password is incorrect");
                return BadRequest(_response);
                }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
            }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
            {
            bool ifUserNameUnique = _userRepo.IsUniqueUser(model.UserName);
            if (!ifUserNameUnique)
                {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessage.Add("Username already exists");
                return BadRequest(_response);
                }

            var user = await _userRepo.Register(model);
            if (user == null)
                {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessage.Add("Error while registering");
                return BadRequest(_response);
                }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
            }

        }
    }
