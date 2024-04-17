using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser User);
        Task<bool> SaveAllAync();

        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int Id);
        Task<AppUser> GetUserByUserNameAsync(string UserName);

        Task<MemberDto> GetmemberByUsernameAsync(string UserName);
        Task<IEnumerable<MemberDto>> GetmembersAsyc();

    }
}