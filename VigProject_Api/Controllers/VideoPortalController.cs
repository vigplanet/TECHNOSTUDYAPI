using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VigProject_Api.Global;
using VigProject_Api.Model;
using VigProject_Api.Repository;

namespace VigProject_Api.Controllers
{
    [Route("api/video")]
    [ApiController]
    public class VideoPortalController : Controller
    {
        Video_Repository objCitiRepo = new Video_Repository();

        [HttpPost]
        [Route("getStudentLogin")]
        public async Task<IActionResult> getStudentLogin(Exam_Inputs_login deserializedProduct)
        {
            try
            {
                //string key = CryptorEngine.GenerateSHA512String("Vigplanet@123", 16);
                //byte[] bytes = Convert.FromBase64String(model.value2);
                //string decrypted = CryptorEngine.DecryptAES(bytes, Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(model.value1));
                //Casting_Inputs deserializedProduct = JsonConvert.DeserializeObject<Casting_Inputs>(decrypted);
                //string Password = converter.Encrypt(deserializedProduct.password);
                Student_video_login_model objRetModel = new Student_video_login_model();
                objRetModel.Student_login_model_list = await objCitiRepo.repo_Student_login(deserializedProduct.username, deserializedProduct.password, "video");
                if (objRetModel.Student_login_model_list.Count > 0)
                    objRetModel.status = ResponseStatus.SUCCESS;
                else
                {
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
        [Route("getVideoCategory")]
     //   [Authorize(Roles = "Student")]
        public async Task<IActionResult> getVideoCategory(student_input deserializedProduct)
        {
            try
            {
                Student_video_category_model objRetModel = new Student_video_category_model();
                objRetModel.Student_category_model_list = await objCitiRepo.repo_Student_category(deserializedProduct.msrno, "video");
                if (objRetModel.Student_category_model_list.Count > 0)
                    objRetModel.status = ResponseStatus.SUCCESS;
                else
                {
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
        [Route("getVideoList")]
       // [Authorize(Roles = "Student")]
        public async Task<IActionResult> getVideoList(student_input deserializedProduct)
        {
            try
            {
                //User.GetMsrno(),
                Student_video_model objRetModel = new Student_video_model();
                objRetModel.Student_video_model_list = await objCitiRepo.repo_Student_videolist(deserializedProduct.msrno, deserializedProduct.categoryid, "video");
                if (objRetModel.Student_video_model_list.Count > 0)
                    objRetModel.status = ResponseStatus.SUCCESS;
                else
                {
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
        [Route("getVideoStart")]
        //[Authorize(Roles = "Student")]
        public async Task<IActionResult> getVideoStart(student_input deserializedProduct)
        {
            try
            {
                Student_video_model_play objRetModel = new Student_video_model_play();
                objRetModel.Student_video_model_playlist = await objCitiRepo.repo_Student_videoStart(deserializedProduct.msrno, deserializedProduct.videoid, "video");
                if (objRetModel.Student_video_model_playlist.Count > 0)
                    objRetModel.status = ResponseStatus.SUCCESS;
                else
                {
                    objRetModel.status = ResponseStatus.FAILED;
                }
                return Ok(new { results = objRetModel });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }
    }
}
