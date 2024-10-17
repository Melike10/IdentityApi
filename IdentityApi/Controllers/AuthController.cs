using IdentityApi.Dtos;
using IdentityApi.Models;
using IdentityApi.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IDataProtector _dataProtector;

        public AuthController(IUserServices userServices, IDataProtectionProvider dataProtectionProvider)
        {
           _userServices = userServices;
            _dataProtector = dataProtectionProvider.CreateProtector("security");

        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
           // şifreyi encrpt ediyoruz
            string encryptedPassword = _dataProtector.Protect(request.Password);
            // modeldeki registerrequest in amacı sadece clientten verileri almak , bunu içerde işlem yapabilmek için DTO sınıfına aktarıyoruz.
            var addUserDto = new AddUserDto
            {
                Email = request.Email,
                Password = encryptedPassword
            };
            var result = await _userServices.AddUser(addUserDto);
            if (result.IsSucceed)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

       
    }
}
