using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Services.Userss
{
    public class UserssService
    {
        private readonly IUserssRepository _userRepo;
        //private readonly IRolesRepository _roleRepo;

        public UserssService(IUserssRepository userRepo)
        {
            _userRepo = userRepo;
            //_roleRepo = roleRepo;

        }

        public async Task<List<Models.Userss>> GetAll()
        {
            return await _userRepo.GetAll();
        }

        //public async Task<List<Models.Roles>> GetAllRoles()
        //{
        //    return await _roleRepo.GetAll();
        //}

        public async Task<Models.Userss> GetById(string Id)
        {
            return await _userRepo.GetByID(Id);
        }

        public async Task<Models.Userss>GetByEmail(string Email)
        {
            return await _userRepo.GetByEmail(Email);
        }

        public async Task AddAndSave(Models.Userss user)
        {
            _userRepo.Add(user);
            await _userRepo.Save();
        }

        public async Task UpdateAndSave(Models.Userss user)
        {
            _userRepo.Update(user);
            await _userRepo.Save();
        }

        public async Task DeleteAndSave(string Id)
        {
            _userRepo.Delete(Id);
            await _userRepo.Save();
        }

        public bool UserExists(string id)
        {
            return _userRepo.UserExists(id);
        }
    }
}
