using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Services.Roles;

namespace FinalProject.Services.Userss
{
    public class UserssService
    {
        private readonly IUserssRepository _userRepo;
        private readonly IRolesRepository _roleRepo;

        public UserssService(IUserssRepository userRepo, IRolesRepository roleRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;

        }

        public async Task<List<Models.Userss>> GetAllUsers()
        {
            return await _userRepo.GetAll();
        }

        public async Task<List<Models.Roles>> GetAllRoles()
        {
            return await _roleRepo.GetAll();
        }

        public async Task<Models.Userss> GetById(int Id)
        {
            return await _userRepo.GetByID(Id);
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

        public async Task DeleteAndSave(int Id)
        {
            _userRepo.Delete(Id);
            await _userRepo.Save();
        }

        public bool UserExists(int id)
        {
            return _userRepo.UserExists(id);
        }
    }
}
