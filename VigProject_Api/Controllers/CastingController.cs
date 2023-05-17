using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigProject_Api.Model_casting;
using VigProject_Api.Repository;
using VigProject_Api.Utility;
using Newtonsoft.Json;
using VigProject_Api.Global;

namespace VigProject_Api.Controllers
{
    [Route("api/Casting")]
    [ApiController]
    public class CastingController : Controller
    {
        Casting_Repository objCitiRepo = new Casting_Repository();
        [HttpPost]
        [Route("CheckSuperAdminLogin")]
        public async Task<IActionResult> CheckSuperAdminLogin(Enc_Inputs model)
        {
            try
            {
                string key = CryptorEngine.GenerateSHA512String("Vigplanet@123", 16);
                byte[] bytes = Convert.FromBase64String(model.value2);
                string decrypted = CryptorEngine.DecryptAES(bytes, Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(model.value1));
                Casting_Inputs deserializedProduct = JsonConvert.DeserializeObject<Casting_Inputs>(decrypted);


                SuperAdminLogin_Model objRetModel = new SuperAdminLogin_Model();
                objRetModel.Userloginlist = await objCitiRepo.CheckSuperAdminLoginAsync(deserializedProduct.username, deserializedProduct.password, deserializedProduct.conn);
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
                //return Ok(new { results = "Something went wrong!" });
                return Ok(new { results = ex.Message });
            }
        }


        [HttpPost]
        [Route("sendWhatsappMessage_VIG")]
        public async Task<IActionResult> sendWhatsappMessage_VIG(Enc_Inputs_whatspp model)
        {
            try
            {
                //Enc_Inputs Crypto = new Enc_Inputs();
                //Crypto.number = "91" + number;
                //Crypto.message = messgage;
                //Crypto.sender = ClientCode;
                string apiUrl = "https://gentle-ravine-00897.herokuapp.com/send-message";
                string inputJson = JsonConvert.SerializeObject(model);
                System.Net.WebClient client = new System.Net.WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = client.UploadString(apiUrl, inputJson);
                //  return json;

                //SuperAdminLogin_Model objRetModel = new SuperAdminLogin_Model();
                //objRetModel.Userloginlist = await objCitiRepo.CheckSuperAdminLoginAsync(deserializedProduct.username, deserializedProduct.password, deserializedProduct.conn);
                //if (objRetModel.Userloginlist.Count > 0)
                //    objRetModel.status = ResponseStatus.SUCCESS;
                //else
                //{
                //    objRetModel.status_msg = "Reason";
                //    objRetModel.status = ResponseStatus.FAILED;
                //}
                return Ok(new { results = json });
            }
            catch (Exception ex)
            {
                //return Ok(new { results = "Something went wrong!" });
                return Ok(new { results = ex.Message });
            }
        }


        [HttpPost]
        [Route("sendWhatsappFile_VIG")]
        public async Task<IActionResult> sendWhatsappFile_VIG(Enc_Inputs_whatspp_file model)
        {
            try
            {


                //Crypto.number = "91" + number;
                //Crypto.base64Image = Convert.ToBase64String(PDFFILE);
                //Crypto.message = Caption;
                //Crypto.sender = ClientCode;
                //Crypto.mediatype = mediatype;// "application/pdf";
               
                string apiUrl = "http://localhost:8000/send-file";
                string inputJson = JsonConvert.SerializeObject(model);
                System.Net.WebClient client = new System.Net.WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = client.UploadString(apiUrl, inputJson);

                return Ok(new { results = json });
            }
            catch (Exception ex)
            {
                //return Ok(new { results = "Something went wrong!" });
                return Ok(new { results = ex.Message });
            }
        }


        public class Enc_Inputs_whatspp
        {
            public string sender { get; set; }
            public string number { get; set; }
            public string message { get; set; }
        }
        public class Enc_Inputs_whatspp_file
        {
            public string number { get; set; }
            public string message { get; set; }
            public string mediatype { get; set; }
            public string base64Image { get; set; }

            public string sender { get; set; }
        }
    }
}
