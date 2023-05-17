using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VigProject_Api.Global;
using VigProject_Api.Model_Gym;
using VigProject_Api.Repository;

namespace VigProject_Api.Controllers
{
    [Route("api/Gym")]
    [ApiController]
    public class GymController : Controller
    {
        Gym_Repository objCitiRepo = new Gym_Repository();

        [HttpPost]
        [Route("getOrgLoginStatus")]
        public async Task<IActionResult> getOrgLoginStatus(gym_Inputs deserializedProduct)
        {
            try
            {
                //string key = CryptorEngine.GenerateSHA512String("Vigplanet@123", 16);
                //byte[] bytes = Convert.FromBase64String(model.value2);
                //string decrypted = CryptorEngine.DecryptAES(bytes, Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(model.value1));
                //Casting_Inputs deserializedProduct = JsonConvert.DeserializeObject<Casting_Inputs>(decrypted);

                orgLogin_Model objRetModel = new orgLogin_Model();
                objRetModel.Userloginlist = await objCitiRepo.repo_getOrgLoginStatus(deserializedProduct.username, deserializedProduct.password, deserializedProduct.orgcode, deserializedProduct.orgtype, "gym");
                if (objRetModel.Userloginlist.Count > 0)
                    objRetModel.status = ResponseStatus.SUCCESS;
                else
                {
                    objRetModel.status_msg = "Reason";
                    objRetModel.status = ResponseStatus.FAILED;
                }
                return Ok(new { results = objRetModel });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }


        [HttpPost]
        [Route("setOrgSignUp")]
        public async Task<IActionResult> setOrgSignUp(gym_signupInputs deserializedProduct)
        {
            try
            {
                string _Result = await objCitiRepo.repo_setOrgSignUp(deserializedProduct.org_id,
         deserializedProduct.org_name,
         deserializedProduct.contactno,
         deserializedProduct.emailId,
         deserializedProduct.website,
         deserializedProduct.ownername,
         deserializedProduct.ownerno,
         deserializedProduct.address,
         deserializedProduct.status,
         deserializedProduct.createip,
         deserializedProduct.username,
         deserializedProduct.password, "gym");
                return Ok(new { results = _Result });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

        [HttpPost]
        [Route("setMemberRegistration")]
        public async Task<IActionResult> setMemberRegistration(gym_membersignup deserializedProduct)
        {
            try
            {
                string _Result = await objCitiRepo.repo_setMemberRegistration(deserializedProduct.org_id,
        deserializedProduct.memberid,
      deserializedProduct.membername,
       deserializedProduct.contactno,
      deserializedProduct.emailId,
      deserializedProduct.address,
     deserializedProduct.age,
      deserializedProduct.dob,
      deserializedProduct.createip, "gym");
                return Ok(new { results = _Result });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }
    }
}
