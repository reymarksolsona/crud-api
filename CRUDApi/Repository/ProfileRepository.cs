using CRUDApi.Context;
using CRUDApi.Interface;
using CRUDApi.Models.Domain;
using CRUDApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRUDApi.Repository
{
    public class ProfileRepository: IProfileRepository
    {
        public async Task<List<ProfileResponse>> GetProfiles()
        {
            using (CRUDDBContext context = new CRUDDBContext())
            {
                var query = from u in context.Profiles
                            select new ProfileResponse { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName } ;

                return await query.ToListAsync();
            }
        }

        public async Task<bool> InsertProfile(ProfileResponse profile)
        {
            try
            {
                using (CRUDDBContext context = new CRUDDBContext())
                {
                    var user = new Profile()
                    {
                        FirstName = profile.FirstName,
                        LastName = profile.LastName
                    };

                    context.Profiles.Add(user);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProfileResponse> UpdateProfile(ProfileResponse profile)
        {
            using (CRUDDBContext context = new CRUDDBContext())
            {
                var result = new ProfileResponse();
                var user = await context.Profiles.Where(x => x.Id == profile.Id).FirstOrDefaultAsync();

                user.FirstName = profile.FirstName;
                user.LastName = profile.LastName;

                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();

                result = new ProfileResponse { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName };

                return result;
            }
        }

        public async Task<bool> DeleteProfile(int id)
        {
            try
            {
                using (CRUDDBContext context = new CRUDDBContext())
                {
                    var user = await context.Profiles.Where(x => x.Id == id).FirstOrDefaultAsync();
                    context.Profiles.Remove(user);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}