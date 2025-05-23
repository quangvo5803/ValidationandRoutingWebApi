﻿using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interface;
using ValidationRouting.DTOs;

namespace ValidationRouting.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public EmployeesController(
            IRepositoryManager repository,
            ILoggerManager loggerManager,
            IMapper mapper
        )
        {
            _repository = repository;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEmployeesForCompany(Guid companyId)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges: false);
            if (company == null)
            {
                _loggerManager.LogInfo(
                    $"Company with id: {companyId} doesn't exist in the database."
                );
                return NotFound();
            }
            var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackChanges: false);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
            return Ok(employeesDto);
        }

        [HttpGet("{id}", Name = "GetEmployeeForCompany")]
        public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges: false);
            if (company == null)
            {
                _loggerManager.LogInfo(
                    $"Company with id: {companyId} doesn't exist in the database."
                );
                return NotFound();
            }
            var employeeDb = _repository.Employee.GetEmployee(companyId, trackChanges: false);
            if (employeeDb == null)
            {
                _loggerManager.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var employeeDto = _mapper.Map<EmployeeDto>(employeeDb);
            return Ok(employeeDto);
        }

        [HttpPost]
        public IActionResult CreateEmployeeForCompany(
            Guid companyId,
            [FromBody] EmployeeForCreationDto employee
        )
        {
            if (employee == null)
            {
                _loggerManager.LogError("EmployeeForCreationDto object sent from client is null");
                return BadRequest("EmployeeForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _loggerManager.LogError(
                    "Invalid model state for the EmployeeForCreationDto object"
                );
                return UnprocessableEntity(ModelState);
            }
            var company = _repository.Company.GetCompany(companyId, trackChanges: false);
            if (company == null)
            {
                _loggerManager.LogInfo(
                    $"Company with id: {companyId} doesn't exist in the database."
                );
                return NotFound();
            }
            var employeeEntity = _mapper.Map<Employee>(employee);
            _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            _repository.Save();
            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
            return CreatedAtRoute(
                "GetEmployeeForCompany",
                new { companyId, id = employeeToReturn.Id },
                employeeToReturn
            );
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid id)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges: false);
            if (company == null)
            {
                _loggerManager.LogInfo(
                    $"Company with id: {companyId} doesn't exist in the database."
                );
                return NotFound();
            }
            var employeeForCompany = _repository.Employee.GetEmployee(id, trackChanges: false);
            if (employeeForCompany == null)
            {
                _loggerManager.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Employee.DeleteEmployee(employeeForCompany);
            _repository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployeeForCompany(
            Guid companyId,
            Guid id,
            [FromBody] EmployeeForUpdateDto employee
        )
        {
            if (employee == null)
            {
                _loggerManager.LogError("EmployeeForUpdateDto object sent from client is null");
                return BadRequest("EmployeeForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _loggerManager.LogError("Invalid model state for the EmployeeForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var company = _repository.Company.GetCompany(companyId, trackChanges: false);
            if (company == null)
            {
                _loggerManager.LogInfo(
                    $"Company with id: {companyId} doesn't exist in the database."
                );
                return NotFound();
            }
            var employeeEntity = _repository.Employee.GetEmployee(id, trackChanges: true);
            if (employeeEntity == null)
            {
                _loggerManager.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(employee, employeeEntity);
            _repository.Save();
            return NoContent();
        }
    }
}
