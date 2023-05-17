using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VigProject_Api.Model;
using VigProject_Api.Repository;

namespace VigProject_Api.Controllers
{
    [Route("API/VIG")]
    [ApiController]
    public class Common_Master_Insert_Controller : Controller
    {
        Common_Master_Insert_Repository obAuthRepo = new Common_Master_Insert_Repository();

        [HttpPost]
        [Route("InsertDataCommonMaster")]
        public async Task<IActionResult> FillCommonMasterData(Common_Master_Insert_Model model)
        {
            List<Common_Master_Insert_Return_Model> objRetModel = new List<Common_Master_Insert_Return_Model>();

            try
            {

                //model.Password = EncryptDecrypt.Encrypt(model.Password);
                //string dPass = EncryptDecrypt.Decrypt(model.Password);
                objRetModel = await obAuthRepo.GetData(model);
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
        [Route("InsertDataCommonMaster1")]
        public async  Task<IActionResult> FillCommonMasterData1(Common_Master_Insert_Model model)
        {
            List<Common_Master_Insert_Return_Model> objRetModel = new List<Common_Master_Insert_Return_Model>();

            try
            {

                //model.Password = EncryptDecrypt.Encrypt(model.Password);
                //string dPass = EncryptDecrypt.Decrypt(model.Password);
                objRetModel = await obAuthRepo.GetData1(model);
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
        [Route("InsertDataCommonMaster2")]
        public async Task<IActionResult> FillCommonMasterData2(Common_Master_Insert_Model model)
        {
            List<Common_Master_Insert_Return_Model> objRetModel = new List<Common_Master_Insert_Return_Model>();

            try
            {

                //model.Password = EncryptDecrypt.Encrypt(model.Password);
                //string dPass = EncryptDecrypt.Decrypt(model.Password);
                objRetModel = await obAuthRepo.GetData2(model);
                return Ok(new { results = objRetModel });
            }
            catch (Exception ex)
            {
                //objRetModel.EmployeeName = ex.ToString();
                return Ok(new { results = objRetModel });
            }

            //return View();
        }
    }    
}
