using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VigProject_Api.Global;
using VigProject_Api.Model;
using VigProject_Api.Repository;

namespace VigProject_Api.Controllers
{
    [Route("api/emp")]
    [ApiController]
    public class EmployeeController : Controller
    {
        public static IWebHostEnvironment _enviroment;

        public EmployeeController(IWebHostEnvironment environment)
        { _enviroment = environment; }

        Employee_Repository objCitiRepo = new Employee_Repository();

        [Authorize]
        [HttpPost]
        [Route("getOrgSignIn")]
        public async Task<IActionResult> getOrgLoginStatus(Emp_Inputs deserializedProduct)
        {
            try
            {
                //string key = CryptorEngine.GenerateSHA512String("Vigplanet@123", 16);
                //byte[] bytes = Convert.FromBase64String(model.value2);
                //string decrypted = CryptorEngine.DecryptAES(bytes, Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(model.value1));
                //Casting_Inputs deserializedProduct = JsonConvert.DeserializeObject<Casting_Inputs>(decrypted);
                string Password = converter.Encrypt(deserializedProduct.password);
                orgEmpLogin_Model objRetModel = new orgEmpLogin_Model();
                objRetModel.Userloginlist = await objCitiRepo.repo_getOrgEmpLoginStatus(deserializedProduct.username, Password, "emp");
                if (objRetModel.Userloginlist.Count > 0)
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

        [Authorize]
        [HttpGet]
        [Route("getOrgEmpList")]
        public async Task<IActionResult> getOrgEmpList()
        {
            try
            {
                //string key = CryptorEngine.GenerateSHA512String("Vigplanet@123", 16);
                //byte[] bytes = Convert.FromBase64String(model.value2);
                //string decrypted = CryptorEngine.DecryptAES(bytes, Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(model.value1));
                //Casting_Inputs deserializedProduct = JsonConvert.DeserializeObject<Casting_Inputs>(decrypted);
                // string Password = converter.Encrypt(deserializedProduct.password);
                // orgEmp_Model objRetModel = new orgEmp_Model();
                List<orgEmpList_Model> orgEmpList_Model = new List<orgEmpList_Model>();
                orgEmpList_Model = await objCitiRepo.repo_getOrgEmpList("emp");
                //if (orgEmpList_Model.Count > 0)
                //    objRetModel.status = ResponseStatus.SUCCESS;
                //else
                //{
                //    objRetModel.status = ResponseStatus.FAILED;
                //}
                return Ok(new { results = orgEmpList_Model });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }
        public class photo_url
        {
            public string url { get; set; }
        }

        public class empmodel_photo
        {
            public int empid { get; set; }
            public Microsoft.AspNetCore.Http.IFormFile Image { get; set; }
        }

        [Authorize]
        [HttpPost]
        [Route("setEmployeePhoto")]
        public async Task<IActionResult> setEmployeePhoto([FromForm] empmodel_photo std)
        {

            try
            {
                string url = "ERROR";
                if (std.Image.Length > 0)
                {
                    var fileExt = System.IO.Path.GetExtension(std.Image.FileName).Substring(1);

                    //using (var memoryStream = new MemoryStream())
                    //{
                    //    std.Image.CopyTo(memoryStream);

                    //memoryStream.ToArray();



                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://103.120.176.187/" + std.empid.ToString() + "." + fileExt);
                    request.Credentials = new NetworkCredential("user_vigplanet", "4ePz@g22");
                    request.Method = WebRequestMethods.Ftp.UploadFile;

                    // using (Stream fileStream = File.OpenRead(@"D:\1.jpg"))
                    using (Stream ftpStream = request.GetRequestStream())
                    {
                        std.Image.CopyTo(ftpStream);
                    }
                    //}


                    //System.Net.WebClient wc = new System.Net.WebClient();

                    //var fileExt = System.IO.Path.GetExtension(std.Image.FileName).Substring(1);

                    //string fullpath = @"D:\1.jpg";
                    //wc.UseDefaultCredentials = true;
                    //wc.Credentials = new System.Net.NetworkCredential("user_vigplanet", "4ePz@g22");
                    //byte[] responseBinary = wc.UploadFile("ftp://103.120.176.187/" + std.empid.ToString() + "." + fileExt, fullpath);


                    emp_status_Model objRetModel = new emp_status_Model();
                    objRetModel.status = await objCitiRepo.repo_setEmployeePhoto("emp", std.empid, "http://vigplanet.com/folder_img/" + std.empid.ToString() + "." + fileExt);


                    // photo_url p = new photo_url();
                    url = "http://vigplanet.com/folder_img/" + std.empid.ToString() + "." + fileExt;
                    return Ok(new { url });
                }
                else { return Ok(new { url }); }
            }
            catch (Exception ex)
            {

                return Ok(new { ex.Message });
            }
            //try
            //{
            //    if (std.Image.Length > 0)
            //    {
            //        var fileExt = System.IO.Path.GetExtension(std.Image.FileName).Substring(1);
            //        if (!Directory.Exists(_enviroment.WebRootPath + "\\Upload\\"))
            //        {
            //            Directory.CreateDirectory(_enviroment.WebRootPath + "\\Upload\\");
            //        }
            //        using (FileStream fileStream = System.IO.File.Create(_enviroment.WebRootPath + "\\Upload\\" + std.empid.ToString() + "." + fileExt))
            //        {
            //            std.Image.CopyTo(fileStream);
            //            fileStream.Flush();

            //            emp_status_Model objRetModel = new emp_status_Model();
            //            objRetModel.status = await objCitiRepo.repo_setEmployeePhoto("emp", std.empid, _enviroment.WebRootPath + "\\Upload\\" + std.empid.ToString() + "." + fileExt);
            //            return _enviroment.WebRootPath + "\\Upload\\" + std.empid.ToString() + "." + fileExt;
            //        }
            //    }
            //    else { return "Failed"; }
            //}
            //catch (Exception ex)
            //{

            //    return ex.ToString();
            //}

            //string g= "http://demo.vigplanet.com/EmpImages/";



            //var filePath = g;
            //var fileExt = System.IO.Path.GetExtension(std.Image.FileName).Substring(1);
            //filePath = System.IO.Path.Combine(filePath, std.empid.ToString() + "." + fileExt);
            //// Getting Name
            //string name = std.empid.ToString();
            //// Getting Image
            //var image = std.Image;
            //// Saving Image on Server
            //if (image.Length > 0)
            //{
            //    using (var fileStream = new FileStream(filePath, FileMode.Create()))
            //    {
            //        image.CopyTo(fileStream);
            //    }
            //emp_status_Model objRetModel = new emp_status_Model();
            //objRetModel.status = await objCitiRepo.repo_setEmployeePhoto("emp", std.empid, filePath);
            //}
            //return Ok(new { results = filePath });



            //try
            //{
            //    emp_status_Model objRetModel = new emp_status_Model();
            //    string fullPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "UploadImages";
            //    var filePath = "";
            //    if (FormFile != null)
            //    {



            //        //Creating upload folder  
            //        if (!System.IO.Directory.Exists(fullPath))
            //        {
            //            System.IO.Directory.CreateDirectory(fullPath);
            //        }
            //        var formFile = FormFile;
            //        var fileExt = System.IO.Path.GetExtension(formFile.FileName).Substring(1);
            //        filePath =System.IO.Path.Combine(fullPath, empid.ToString() + "." + fileExt);

            //        using (var stream = System.IO.File.Create(filePath))
            //        {
            //            formFile.CopyToAsync(stream);
            //        }

            //        objRetModel.status = await objCitiRepo.repo_setEmployeePhoto("emp", empid, empid.ToString() + "." + fileExt);
            //    }
            //    return Ok(new { results = filePath });




            //}
            //catch (Exception ex)
            //{
            //    return Ok(new { results = ex.Message });
            //}
        }
        [Authorize]
        [HttpPost]
        [Route("getEmployeePhoto")]
        public async Task<IActionResult> getEmployeePhoto(Profile_input input)
        {
            try
            {
                emp_status_Model objRetModel = new emp_status_Model();
                objRetModel.status = await objCitiRepo.repo_getEmployeePhoto("emp", input.empid);
                return Ok(new { results = objRetModel });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }
        [Authorize]
        [HttpPost]
        [Route("setEmployeePunchIn")]
        public async Task<IActionResult> setEmployeePunchIn(Profile_input input)
        {
            try
            {
                emp_status_Model objRetModel = new emp_status_Model();
                objRetModel.status = await objCitiRepo.repo_setEmployeeCheckIn("emp", input.empid);
                return Ok(new { results = objRetModel });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }
        [Authorize]
        [HttpPost]
        [Route("setEmployeePunchOut")]
        public async Task<IActionResult> setEmployeePunchOut(Profile_input input)
        {
            try
            {
                emp_status_Model objRetModel = new emp_status_Model();
                objRetModel.status = await objCitiRepo.repo_setEmployeeCheckOut("emp", input.empid);
                return Ok(new { results = objRetModel });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("OnPostUpload")]
        public IActionResult OnPostUpload(Microsoft.AspNetCore.Http.IFormFile FormFile)
        {
            if (FormFile != null)
            {
                string fullPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "UploadImages";
                //Creating upload folder  
                if (!System.IO.Directory.Exists(fullPath))
                {
                    System.IO.Directory.CreateDirectory(fullPath);
                }
                var formFile = FormFile;
                var filePath = System.IO.Path.Combine(fullPath, formFile.FileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    formFile.CopyToAsync(stream);
                }

            }
            return Ok(new { results = "Ok" });

        }

        [HttpPost]
        [Route("set_KAM_signup")]
        public async Task<IActionResult> setKAMMemberRegistration(kam_membersignup_input deserializedProduct)
        {
            try
            {
                kamLogin_Model objRetModel = new kamLogin_Model();

                objRetModel.kamloginlist = await objCitiRepo.repo_setKAMMemberRegistration(deserializedProduct.LoginId, deserializedProduct.fullname, deserializedProduct.emailid, deserializedProduct.mobileno, deserializedProduct.emailid
                    , converter.Encrypt(deserializedProduct.password),deserializedProduct.deviceid
                    , "kamemp");
                if (objRetModel.kamloginlist.Count > 0)
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
        [Route("set_KAM_signin")]
        public async Task<IActionResult> getKAMMemberlogin(kam_membersignin_input deserializedProduct)
        {
            try
            {
                //string key = CryptorEngine.GenerateSHA512String("Vigplanet@123", 16);
                //byte[] bytes = Convert.FromBase64String(model.value2);
                //string decrypted = CryptorEngine.DecryptAES(bytes, Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(model.value1));
                //Casting_Inputs deserializedProduct = JsonConvert.DeserializeObject<Casting_Inputs>(decrypted);
                string Password = converter.Encrypt(deserializedProduct.password);
                kamLogin_Model objRetModel = new kamLogin_Model();
                objRetModel.kamloginlist = await objCitiRepo.repo_setKAMMemberlogin(deserializedProduct.emailid, Password, "kamemp");
                if (objRetModel.kamloginlist.Count > 0)
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
        [Route("set_KAM_Notification")]
        public async Task<IActionResult> set_KAM_Notification(kam_notification_input deserializedProduct)
        {
            try
            {


                //RegisterId you got from Android Developer.
                // string deviceId = "e_Rq-T9ORQWxK00lJWshkg:APA91bHn8cHDDF3w4SN385YsxZGkGgGsfjvyC3VATutGUAea-zT9yq3xAGjo2JKBO3gTyaOjk8W677ZjnQcHD2MNVsubhv7Ozt5KCFocIFCy6TGLDZQbUAP0zsUhyioc0p-oPDIfU6d-";
                string deviceId = deserializedProduct.deviceId;

                string message = deserializedProduct.message;
                string tickerText = deserializedProduct.tickerText;
                string contentTitle = deserializedProduct.contentTitle;
                string msgtype = deserializedProduct.msgtype;
                string postData =
                "{ \"registration_ids\": [ \"" + deviceId + "\" ], " +
                  "\"data\": {\"tickerText\":\"" + tickerText + "\", " +
                             "\"contentTitle\":\"" + contentTitle + "\", " +
                             "\"msgtype\":\"" + msgtype + "\", " +
                             "\"message\": \"" + message + "\"}}";

                string response = SendGCMNotification("AAAAD26FS2Q:APA91bECg8V9R6P1SKltVBluszcobZLgOv4cFIkv6oWD1ypo-vGlV9CYcylY9j_GN5IUTWg150qnPX5LbfyVzrRAk_jNSFuqmKxMOB1zh3LPu9k75izTbn35fYwDTR5-EILuXBH1GUHi", postData);




               // Label1.Text = response;



                //string Password = converter.Encrypt(deserializedProduct.password);
                //kamLogin_Model objRetModel = new kamLogin_Model();
                //objRetModel.kamloginlist = await objCitiRepo.repo_setKAMMemberlogin(deserializedProduct.emailid, Password, "kamemp");
                //if (objRetModel.kamloginlist.Count > 0)
                //    objRetModel.status = ResponseStatus.SUCCESS;
                //else
                //{
                //    objRetModel.status = ResponseStatus.FAILED;
                //}
                return Ok(new { results = response });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }




        private string SendGCMNotification(string apiKey, string postData, string postDataContentType = "application/json")
        {
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(ValidateServerCertificate);

            //  
            //  MESSAGE CONTENT  
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(postData);

            //  
            //  CREATE REQUEST  
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            //Request.Headers.Add(HttpRequestHeader.Authorization, "key=AAAACIq4DDA:APA91bEqdaotLCR83WlS8ewkWMyDMEZaO7cEr_w67XxG8kNOuoHoLjF_Gb9QcncMFk-LWogAODv8jJ3NHJugoFfJjbdZND6nz23l41Z4RJWy2v8OYSOyHieofzEmn1Zza1foELm73y8A");
            Request.Method = "POST";
            //  Request.KeepAlive = false;  

            Request.ContentType = postDataContentType;
            Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
            Request.ContentLength = byteArray.Length;

            Stream dataStream = Request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            //  
            //  SEND MESSAGE  
            try
            {
                WebResponse Response = Request.GetResponse();

                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                {
                    var text = "Unauthorized - need new token";
                }
                else if (!ResponseCode.Equals(HttpStatusCode.OK))
                {
                    var text = "Response from web service isn't OK";
                }

                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                string responseLine = Reader.ReadToEnd();
                Reader.Close();

                return responseLine;
            }
            catch (Exception e)
            {
            }
            return "error";
        }
        public static bool ValidateServerCertificate(
                                                     object sender,
                                                     X509Certificate certificate,
                                                     X509Chain chain,
                                                     SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }



        [HttpPost]
        [Route("SendFileWhatsApp")]
        public async Task<IActionResult> SendFileWhatsApp(Message_Input deserializedProduct)
        {
            try
            {

                //byte[] picArray = System.IO.File.ReadAllBytes(FilePath);
                //DataTable dt = new DataTable();

                //cn.ExecuteQuery("update DeliveryMaster  set IsServerUpdated=1 where MDeliverId=" + MDeliveryId);

             //   Enc_Inputs Crypto = new Enc_Inputs();
                //Crypto.number = "91" + Contactno;
                //Crypto.base64Image = Convert.ToBase64String(picArray);
                //Crypto.message = DeliveryNo + ".pdf";
                //Crypto.mediatype = "application/pdf";
                string apiUrl = "http://localhost:3000/sendfile";
                string inputJson = JsonSerializer.Serialize<Message_Input>(deserializedProduct);
                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = client.UploadString(apiUrl, inputJson);

                return Ok(new { results = json });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

    }
}
