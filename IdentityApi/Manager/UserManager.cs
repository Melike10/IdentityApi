using IdentityApi.Context;
using IdentityApi.Dtos;
using IdentityApi.Entities;
using IdentityApi.Services;
using IdentityApi.Types;

namespace IdentityApi.Manager
{
    public class UserManager : IUserServices
    {
        private readonly UserIdentityContext _db;
        public UserManager(UserIdentityContext db)
        {
            _db = db;
        }
        public async Task<ServicesMessages> AddUser(AddUserDto user)
        {
            var newUser = new UserEntitiy
            {
                Email = user.Email,
                Password = user.Password,
                IsDeleted = false
            };
            _db.Users.Add(newUser);
            _db.SaveChanges();
            return new ServicesMessages
            {
                IsSucceed = true,
                Message = "Kayıt Başarılı"
            };
        }
    }
}
