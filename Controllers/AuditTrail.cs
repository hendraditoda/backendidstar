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
public class AuditTrailController : ControllerBase
{

    private readonly BackendidstarContext _DBContext;


    public AuditTrailController(BackendidstarContext dBContext)
    {
        this._DBContext = dBContext;
    }

    [HttpPost("create")]
    public IActionResult CreateAudittrail([FromBody] Audittrail _audittrail)
    {
        // Update parameter konfigurasi di database

        // Tambahkan log audit
        var auditLog = new Audittrail
        {
            Action = "Update",
            TableName = "AuditTrail",
            Id = _audittrail.Id, // Ubah sesuai dengan primary key yang sesuai
            Datetime = DateTime.Now,
            // UserId = User.Identity.Name // Jika Anda telah mengintegrasikan otentikasi dengan benar
        };

        this._DBContext.Audittrails.Add(auditLog);
        this._DBContext.SaveChangesAsync();

        return Ok();
    }

}