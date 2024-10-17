using IdentityApi.Dtos;
using IdentityApi.Types;

namespace IdentityApi.Services
{
    public interface IUserServices
    {
        Task<ServicesMessages> AddUser(AddUserDto user);
    }
}
