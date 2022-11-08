using CRUDApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApi
{
    public interface IProfileService
    {
        Task<List<ProfileResponse>> GetProfiles();
        Task<string> AddProfile(ProfileResponse profile);
        Task<ProfileResponse> UpdateProfile(ProfileResponse profile);
        Task<string> DeleteProfile(int id);
    }
}
