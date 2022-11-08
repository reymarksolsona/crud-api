using CRUDApi.Interface;
using CRUDApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRUDApi.Service
{
    public class ProfileService: IProfileService
    {
        public IProfileRepository _profileRepo;

        public ProfileService(IProfileRepository repo)
        {
            _profileRepo = repo;
        }

        public async Task<List<ProfileResponse>> GetProfiles()
        {
            var result = new List<ProfileResponse>();
            var profiles = await _profileRepo.GetProfiles();
            result.AddRange(profiles);
            return result;
        }

        public async Task<string> AddProfile(ProfileResponse profile)
        {
            bool isProfileAdded = await _profileRepo.InsertProfile(profile);
            return isProfileAdded ? "Profile added successfully." : "Error occured.";
        }

        public async Task<ProfileResponse> UpdateProfile(ProfileResponse profile)
        {
            var result = new ProfileResponse();
            var profileResult = await _profileRepo.UpdateProfile(profile);
            result = profileResult;
            return result;
        }

        public async Task<string> DeleteProfile(int id)
        {
            bool isProfileDeleted = await _profileRepo.DeleteProfile(id);
            return isProfileDeleted ? "Profile deleted successfully." : "Error occured.";
        }
    }
}