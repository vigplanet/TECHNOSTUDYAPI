using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VigProject_Api.Model;
using VigProject_Api.Model.Student;
using VigProject_Api.Repository.Student_Repository;
using vigstudent.Model;

namespace VigProject_Api.Controllers.Student_Controllers
{
    [Route("API/VIG")]
    [ApiController]
    public class Student_Registration_insert_Controllers : Controller
    {
        Student_Registration_insert_Repository obAuthRepo = new Student_Registration_insert_Repository();

        [HttpPost]
        [Route("InsertStudentRegstration")]
            
        public async Task<IActionResult> InsertStudentRegtration(Student_Registation_insert_Model model)
        {
            List<Student_Registation_insert_Return_Model> objRetModel = new List<Student_Registation_insert_Return_Model>();

            try
            {

                //model.Password = EncryptDecrypt.Encrypt(model.Password);
                //string dPass = EncryptDecrypt.Decrypt(model.Password);
                objRetModel = await obAuthRepo.InsertStudent(model);
                return Ok(new { results = objRetModel });
            }
            catch (Exception ex)
            {
                //objRetModel.EmployeeName = ex.ToString();
                return Ok(new { results = objRetModel });
            }
            //return View();
        }


        [HttpPost]
        [Route("GetMasterData")]

        public async Task<IActionResult> getMasterData(CommonData_Parameter _parameter)
        {
            CommonClassData _classdata = new CommonClassData();
            try
            {
                FunctionAll objRetModel = new FunctionAll();
                _classdata= await objRetModel.checkdata(_parameter);
                //model.Password = EncryptDecrypt.Encrypt(model.Password);
                //string dPass = EncryptDecrypt.Decrypt(model.Password);
                //objRetModel = await obAuthRepo.InsertStudent(model);
                return Ok(new { results = _classdata });
            }
            catch (Exception ex)
            {
                //objRetModel.EmployeeName = ex.ToString();
                return Ok(new { results = _classdata });
            }
            //return View();
        }
    }
}
