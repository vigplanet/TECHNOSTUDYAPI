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
    public class Fill_Combobox_Controller : Controller
    {
        Fill_Combobox_Repository obAuthRepo = new Fill_Combobox_Repository();

        [HttpPost]
        [Route("FillComboBox")]
        public async Task<IActionResult> FillCommonMasterData(Fill_Combobox_Model model)
        {
            List<Fill_Combobox_Return_Model> objRetModel = new List<Fill_Combobox_Return_Model>();

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
        [Route("FillComboBox1")]
        public async Task<IActionResult> FillCommonMasterData1(Fill_Combobox_Model model)
        {
            List<Fill_Combobox_Return_Model> objRetModel = new List<Fill_Combobox_Return_Model>();

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
    }
}
