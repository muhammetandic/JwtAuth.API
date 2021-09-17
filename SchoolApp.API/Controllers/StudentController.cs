using JwtAuth.API.Data.Models;
using JwtAuth.API.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolApp.API.Data;
using SchoolApp.API.Data.Helpers;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SchoolApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = UserRoles.Student)]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<StudentController> _logger;

        public StudentController(AppDbContext dbContext, ILogger<StudentController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        //[CustomExceptionFilter]
        public IActionResult Get()
        {
            //_logger.LogInformation("Get called");
            //_logger.LogError("Şimdi bir hata fırlatılacak");
            throw new Exception("Middleware çalışıyormu");
            try
            {
                var allStudents = _dbContext.Students.ToList();
                return Ok(allStudents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        [CustomExceptionFilter]
        public IActionResult Get(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(n => n.Id == id);
            return Ok($"Student name : {student.FullName}");
        }

        [HttpPost]
        [CustomExceptionFilter]
        public IActionResult Create([FromBody] Student payload)
        {
            try
            {
                if(Regex.IsMatch(payload.FullName, @"^\d"))
                {
                    throw new StudentNameException("İsim harfle başlamalı", payload.FullName);
                }
                if(payload.DateOfBirth>DateTime.UtcNow.AddYears(-20))
                {
                    throw new StudentAgeException("Yaş en az yirmi olmalı");
                }
                _dbContext.Students.Add(payload);
                _dbContext.SaveChanges();
                return Created("", null);
            }
            catch (StudentNameException)
            {
                return BadRequest($"{payload.FullName} rakam ile başlayamaz.");
            }
            catch (StudentAgeException)
            {
                return BadRequest("En az 20 yaşında olmalı");
            }

        }
    }
}
