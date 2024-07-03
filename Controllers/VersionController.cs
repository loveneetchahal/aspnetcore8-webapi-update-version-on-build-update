using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace aspnetcore8_webapi_update_version_on_build_update.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private readonly string _versionFilePath = Path.Combine(Directory.GetCurrentDirectory(), "version.txt");

        [HttpGet]
        public async Task<IActionResult> GetVersion()
        { 
            try
            {
                // Read the current version from version.txt
                string version = System.IO.File.ReadAllText(_versionFilePath).Trim(); 
                if (string.IsNullOrEmpty(version))
                {
                    return StatusCode(500, "Version number is empty or not found.");
                } 
                return Ok(new { Version = version });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error reading version file: {ex.Message}");
            }
        }
    }
}
