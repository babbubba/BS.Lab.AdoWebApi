using BS.Lab.AdoWebApi.Domain.Models;
using BS.Lab.AdoWebApi.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Lab.AdoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly Repository repository;

        public EmployeesController(Repository repository)
        {
            this.repository = repository;
        }

        public IActionResult GetEmployees()
        {
            var employees = repository.GetEmployees();

            var result = employees.Select(e=> new
            {
                name = e.Name,
                surname = e.Surname,
                hireDate = e.HireDate.ToString("dd/MMM/yyyy"),
                serviceTime = e.ServiceTime,
                isCurrentlyEmployed = e.IsCurrentlyEmployed ? "Yes" : "No",
                dismissalDate = e.DismissalDate?.ToString("dd/MMM/yyyy") ?? "-",
                roomName = e.Room?.Name ?? "- no room -"
            });

            return Ok(result);
        }
    }
}
