using Microsoft.AspNetCore.Mvc;
using backendidstar.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
// using backendidstar.Container;
// using backendidstar.Entity;

namespace backendidstar.Controllers;

///[Authorize(Roles ="admin,user")]
[ApiController]
[Route("[controller]")]
public class ParameterController : ControllerBase
{

    private readonly BackendidstarContext _DBContext;


    public ParameterController(BackendidstarContext dBContext)
    {
        this._DBContext = dBContext;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var parameter = this._DBContext.Parameters.ToList();
        return Ok(parameter);
    }

    [HttpGet("GetParameter/{id}")]
    public IActionResult GetParameter(int id)
    {
        var parameter = this._DBContext.Parameters.FirstOrDefault(o => o.Id == id);
        return Ok(parameter);
    }

    [HttpDelete("Remove/{id}")]
    public IActionResult DeleteParameter(int id)
    {
        var parameter = this._DBContext.Parameters.FirstOrDefault(o => o.Id == id);
        if (parameter != null)
        {
            this._DBContext.Parameters.Remove(parameter);
            return Ok(true);
        }
        return Ok(false);

    }

    [HttpPost("create")]
    public IActionResult CreateParameter([FromBody] Parameter _parameter)
    {
        // Membuat parameter baru
        var parameter = this._DBContext.Parameters.FirstOrDefault(o => o.Id == _parameter.Id);
        if (parameter != null)
        {
            parameter.Name = _parameter.Name;
            parameter.Value = _parameter.Value;
            this._DBContext.SaveChanges();
        }
        else
        {
            this._DBContext.Parameters.Add(_parameter);
            this._DBContext.SaveChanges();
        }
        return Ok(true);
    }

    [HttpPut("Update/{id}")]
    public IActionResult UpdateParameter(int id, Parameter _parameter)
    {
        var existingParameter = this._DBContext.Parameters.FirstOrDefault(p => p.Id == id);

        if (existingParameter == null)
        {
            return NotFound();
        }

        existingParameter.Name = _parameter.Name;
        existingParameter.Value = _parameter.Value;
        this._DBContext.SaveChanges();

        return Ok(existingParameter);
    }
}