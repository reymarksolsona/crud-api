using CRUDApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApi.Interface
{
    public interface IProfileRepository
    {
        Task<List<ProfileResponse>> GetProfiles();
        Task<bool> InsertProfile(ProfileResponse profile);
        Task<ProfileResponse> UpdateProfile(ProfileResponse profile);
        Task<bool> DeleteProfile(int id);
    }
}
