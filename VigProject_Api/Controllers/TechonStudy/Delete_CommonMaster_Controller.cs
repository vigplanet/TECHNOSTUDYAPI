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
    public class Delete_CommonMaster_Controller : Controller
    {
        Delete_CommonMaster_Repository obAuthRepo = new Delete_CommonMaster_Repository();

        [HttpPost]
        [Route("DeleteCommonMaster")]
        public async Task<IActionResult> DeleteCommonMaster(Delete_CommonMaster_Model model)
        {
            List<Delete_CommonMaster_Return_Model> objRetModel = new List<Delete_CommonMaster_Return_Model>();

            try
            {

                //model.Password = EncryptDecrypt.Encrypt(model.Password);
                //string dPass = EncryptDecrypt.Decrypt(model.Password);
                objRetModel = await obAuthRepo.DeleteData(model);
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
        [Route("DeleteCommonMaster1")]
        public async Task<IActionResult> DeleteCommonMaster1(Delete_CommonMaster_Model model)
        {
            List<Delete_CommonMaster_Return_Model> objRetModel = new List<Delete_CommonMaster_Return_Model>();

            try
            {

                //model.Password = EncryptDecrypt.Encrypt(model.Password);
                //string dPass = EncryptDecrypt.Decrypt(model.Password);
                objRetModel = await obAuthRepo.DeleteData1(model);
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
        [Route("DeleteCommonMaster2")]
        public async Task<IActionResult> DeleteCommonMaster2(Delete_CommonMaster_Model model)
        {
            List<Delete_CommonMaster_Return_Model> objRetModel = new List<Delete_CommonMaster_Return_Model>();

            try
            {

                //model.Password = EncryptDecrypt.Encrypt(model.Password);
                //string dPass = EncryptDecrypt.Decrypt(model.Password);
                objRetModel = await obAuthRepo.DeleteData2(model);
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
