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
    public class Common_Master_Controller : Controller
    {
        Common_Master_Repository obAuthRepo = new Common_Master_Repository();

        [HttpPost]
        [Route("GetCommonDetails")]
        public async Task<IActionResult> FillCommonMasterData(Common_Master_Model model)
        {
            List<Common_Master_Return_Model> objRetModel = new List<Common_Master_Return_Model>();

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
        [Route("EditCommonData")]
        public async Task<IActionResult> EditCommonMasterData(Common_Master_Model model)
        {
            List<Common_Master_Return_Model> objRetModel = new List<Common_Master_Return_Model>();

            try
            {

                //model.Password = EncryptDecrypt.Encrypt(model.Password);
                //string dPass = EncryptDecrypt.Decrypt(model.Password);
                objRetModel = await obAuthRepo.EditData(model);
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
