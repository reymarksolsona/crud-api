using CRUDApi.Models.Response;
using CRUDApi.Repository;
using CRUDApi.Service;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRUDApi.Controllers
{
    [RoutePrefix("api/v1/profile")]
    public class ProfileController : ApiController
    {
        private IProfileService _profileService;

        private void InitDependency()
        {
            var repo = new ProfileRepository();
            _profileService = new ProfileService(repo);
        }

        [HttpGet]
        [Route("get-profiles")]
        public async Task<IHttpActionResult> GetProfiles()
        {
            try
            {
                InitDependency();
                var result = await _profileService.GetProfiles();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occured. " + ex.Message));
            }
        }

        [HttpPost]
        [Route("add-profile")]
        public async Task<IHttpActionResult> AddProfile([FromBody] ProfileResponse profile)
        {
            try
            {
                InitDependency();
                var result = await _profileService.AddProfile(profile);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occured. " + ex.Message));
            }
        }

        [HttpPost]
        [Route("update-profile")]
        public async Task<IHttpActionResult> UpdateProfile([FromBody] ProfileResponse profile)
        {
            try
            {
                InitDependency();
                var result = await _profileService.UpdateProfile(profile);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occured. " + ex.Message));
            }
        }

        [HttpGet]
        [Route("delete-profile")]
        public async Task<IHttpActionResult> DeleteProfile([FromUri] int id)
        {
            try
            {
                InitDependency();
                var result = await _profileService.DeleteProfile(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occured. " + ex.Message));
            }
        }
    }
}
