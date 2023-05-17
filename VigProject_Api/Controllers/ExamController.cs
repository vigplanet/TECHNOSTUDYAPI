using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VigProject_Api.Global;
using VigProject_Api.Model;
using VigProject_Api.Repository;

namespace VigProject_Api.Controllers
{
    [Route("api/exam")]
    [ApiController]
    public class ExamController : Controller
    {
        Exam_Repository objCitiRepo = new Exam_Repository();

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
                Student_login_model objRetModel = new Student_login_model();
                objRetModel.Student_login_model_list = await objCitiRepo.repo_Student_login(deserializedProduct.username, deserializedProduct.password, "exam");
                if (objRetModel.Student_login_model_list.Count > 0)
                {
                    objRetModel.status = ResponseStatus.SUCCESS;
                    objRetModel.token = await objCitiRepo.GenerateStudentToken(objRetModel);
                    Response.Headers.Add("X-Auth", objRetModel.token);
                }
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
        [Route("getStudentSurveylist")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> getStudentSurveylist(student_input deserializedProduct)
        {
            try
            {
                //string key = CryptorEngine.GenerateSHA512String("Vigplanet@123", 16);
                //byte[] bytes = Convert.FromBase64String(model.value2);
                //string decrypted = CryptorEngine.DecryptAES(bytes, Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(model.value1));
                //Casting_Inputs deserializedProduct = JsonConvert.DeserializeObject<Casting_Inputs>(decrypted);
                //string Password = converter.Encrypt(deserializedProduct.password);
                survey_exam_model objRetModel = new survey_exam_model();
                objRetModel.survey_exam_model_list = await objCitiRepo.repo_Student_survey_list(User.GetMsrno(), deserializedProduct.action, "exam");
                if (objRetModel.survey_exam_model_list.Count > 0)
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
        [Route("getStudentSurveyDetails")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> getStudentSurveyDetails(studentexam_input deserializedProduct)
        {
            try
            {
                //string key = CryptorEngine.GenerateSHA512String("Vigplanet@123", 16);
                //byte[] bytes = Convert.FromBase64String(model.value2);
                //string decrypted = CryptorEngine.DecryptAES(bytes, Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(model.value1));
                //Casting_Inputs deserializedProduct = JsonConvert.DeserializeObject<Casting_Inputs>(decrypted);
                //string Password = converter.Encstarrypt(deserializedProduct.password);
                survey_exam_model objRetModel = new survey_exam_model();
                objRetModel.survey_exam_model_list = await objCitiRepo.repo_student_exam_details(User.GetMsrno(), deserializedProduct.surveyid, deserializedProduct.action, "exam");
                if (objRetModel.survey_exam_model_list.Count > 0)
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
        [Route("setStudentSurveyStart")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> setStudentSurveyStart(int surveyid)
        {
            try
            {
                string sreResult;
                sreResult = await objCitiRepo.repo_student_survey_exam_start(User.GetMsrno(), surveyid, "start", "exam");
                if (sreResult.Length <= 0)
                {

                    sreResult = ResponseStatus.FAILED;
                }
                return Ok(new { results = sreResult });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

        [HttpPost]
        [Route("getSurveyQuestionList")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> getSurveyQuestionList(survey_input deserializedProduct)
        {
            try
            {
                survey_paper objRetModel = new survey_paper();
                objRetModel.survey_list = await objCitiRepo.repo_survey_question_list(deserializedProduct.surveyid, User.GetMsrno(), "exam");
                if (objRetModel.survey_list.Count > 0)
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
        [Route("setQuesAnsSave")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> setQuesAnsSave(ques_submit_input deserializedProduct)
        {
            try
            {
                int sreResult;
                sreResult = await objCitiRepo.repo_setQuesAnsSave(User.GetMsrno(), deserializedProduct.surveyid, deserializedProduct.questionid, deserializedProduct.ansid, deserializedProduct.ishindi, deserializedProduct.anstype, "save", "exam");



                return Ok(new { results = sreResult });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }


        [HttpPost]
        [Route("setQuesAnsDelete")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> setQuesAnsDelete(quesDelete_input deserializedProduct)
        {
            try
            {
                int sreResult;
                sreResult = await objCitiRepo.repo_setQuesAnsDelete(User.GetMsrno(), deserializedProduct.surveyid, deserializedProduct.questionid, "save", "exam");



                return Ok(new { results = sreResult });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

        [HttpPost]
        [Route("setStudentSurveySubmit")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> setStudentSurveySubmit(survey_input deserializedProduct)
        {
            try
            {
                string sreResult;
                sreResult = await objCitiRepo.repo_student_survey_exam_submit(User.GetMsrno(), deserializedProduct.surveyid, deserializedProduct.action, "exam");
                if (sreResult.Length <= 0)
                {

                    sreResult = ResponseStatus.FAILED;
                }
                return Ok(new { results = sreResult });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

        [HttpPost]
        [Route("getStudentSurveyResult")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> getStudentSurveyResult(survey_input deserializedProduct)
        {
            try
            {
                survey_exam_rank_model _survey_exam_result_model = new survey_exam_rank_model();
                _survey_exam_result_model.survey_exam_rank_model_list = await objCitiRepo.repo_student_result_declare(User.GetMsrno(), deserializedProduct.surveyid, deserializedProduct.action, "exam");
                if (_survey_exam_result_model.survey_exam_rank_model_list.Count > 0)
                    _survey_exam_result_model.status = ResponseStatus.SUCCESS;
                else
                {
                    _survey_exam_result_model.status_msg = "Reason";
                    _survey_exam_result_model.status = ResponseStatus.FAILED;
                }
                return Ok(new { results = _survey_exam_result_model });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

        [HttpPost]
        [Route("getStudentSurveyToppers")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> getStudentSurveyToppers(survey_input deserializedProduct)
        {

            try
            {
                survey_exam_rank_model _survey_exam_result_model = new survey_exam_rank_model();
                _survey_exam_result_model.survey_exam_rank_model_list = await objCitiRepo.repo_student_toppersList(User.GetMsrno(), deserializedProduct.surveyid, deserializedProduct.action, "exam");
                if (_survey_exam_result_model.survey_exam_rank_model_list.Count > 0)
                    _survey_exam_result_model.status = ResponseStatus.SUCCESS;
                else
                {
                    _survey_exam_result_model.status_msg = "Reason";
                    _survey_exam_result_model.status = ResponseStatus.FAILED;
                }
                return Ok(new { results = _survey_exam_result_model });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

        [HttpPost]
        [Route("getStudentExamList")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> getStudentExamList(survey_input deserializedProduct)
        {

            try
            {
                survey_exam_rank_model _survey_exam_result_model = new survey_exam_rank_model();
                _survey_exam_result_model.survey_exam_rank_model_list = await objCitiRepo.repo_getStudentExamList(User.GetMsrno(), "exam");
                if (_survey_exam_result_model.survey_exam_rank_model_list.Count > 0)
                    _survey_exam_result_model.status = ResponseStatus.SUCCESS;
                else
                {
                    _survey_exam_result_model.status_msg = "Reason";
                    _survey_exam_result_model.status = ResponseStatus.FAILED;
                }
                return Ok(new { results = _survey_exam_result_model });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }



    }
}
