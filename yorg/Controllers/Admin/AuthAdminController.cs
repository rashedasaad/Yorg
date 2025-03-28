using Microsoft.AspNetCore.Mvc;
using yorg.DTOs;
using yorg.Repository.Interface;

namespace yorg.Controllers.Admin;

[Route("api/[controller]")]
[ApiController]
public class AuthAdminController : ControllerBase
{
    private readonly IAdminRepository adminRepository;

    public AuthAdminController(IAdminRepository adminRepository)
    {
        this.adminRepository = adminRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAdmins()
    {
        var admins = await adminRepository.GetAdmins();
        return Ok(admins);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAdminById(Guid id)
    {
        var admin = await adminRepository.GetAdminById(id);
        if (admin == null)
        {
            return NotFound();
        }
        return Ok(admin);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AddAdmin(Guid id)
    {
        var admin = await adminRepository.GetAdminById(id);
        if (admin == null)
        {
            return NotFound();
        }
        var newAdmin = await adminRepository.AddAdmin(id);
        return CreatedAtAction(nameof(GetAdminById), new { id = newAdmin.Id }, newAdmin);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAdmin(Guid id)
    {
        var admin = await adminRepository.GetAdminById(id);
        if (admin == null)
        {
            return NotFound();
        }
        await adminRepository.RemoveAdmin(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAdmin(Guid id, [FromBody] User admin)
    {

        admin.Id = id; 

        var existingAdmin = await adminRepository.GetAdminById(id);
        if (existingAdmin == null)
        {
            return NotFound();
        }

        await adminRepository.UpdateAdmin(admin);

        return NoContent();
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteAdmin(Guid id)
    {
        var admin = await adminRepository.GetAdminById(id);
        if (admin == null)
        {
            return NotFound();
        }
        await adminRepository.DeleteAdmin(admin);
        return NoContent();
    }



}
