using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using VigProject_Api.Global;
using VigProject_Api.Model;
using VigProject_Api.Repository;

namespace VigProject_Api.Controllers
{
    [Route("api/store")]
    [ApiController]
    public class StoreController : Controller
    {
        Store_Repository objCitiRepo = new Store_Repository();

        [HttpGet]
        [Route("getItemList")]
        public async Task<IActionResult> getItemList()
        {
            try
            {
                item_model objRetModel = new item_model();
                objRetModel.item_model_list = await objCitiRepo.repo_GetItemList("store");
                if (objRetModel.item_model_list.Count > 0)
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

        [HttpGet]
        [Route("itemUtility")]
        public async Task<IActionResult> itemUtility()
        {
            try
            {
                ItemUtility objRetModel = new ItemUtility();
                objRetModel = await objCitiRepo.repo_itemUtility("store");
                //if (objRetModel.CategoryList.Count > 0)
                objRetModel.status = ResponseStatus.SUCCESS;
                //else
                //{
                //    objRetModel.status = ResponseStatus.FAILED;
                //}
                return Ok(new { results = objRetModel });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }


        [HttpGet]
        [Route("LedgerUtility")]
        public async Task<IActionResult> LedgerUtility()
        {
            try
            {
                LedgerUtility objRetModel = new LedgerUtility();
                objRetModel = await objCitiRepo.repo_ledgerUtility("store");
                //if (objRetModel.CategoryList.Count > 0)
                objRetModel.status = ResponseStatus.SUCCESS;
                //else
                //{
                //    objRetModel.status = ResponseStatus.FAILED;
                //}
                return Ok(new { results = objRetModel });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

        [HttpPost]
        [Route("FileUploadS3")]
        public async Task<IActionResult> FileUploadS3([FromForm] FileRequest req)
        {
            try
            {
                 
                if (req.Imgname != null && req.Imgname.Length > 0)
                {
                    Guid id = Guid.NewGuid();
                    var fileExt = System.IO.Path.GetExtension(req.Imgname.FileName).Substring(1);

                 // string  imgPath = string.Format("{0}/{1}/{2}", req.OrgId, "_Category", id.ToString() + "." + fileExt);
                     using var newMemoryStream = new MemoryStream();
                    req.Imgname.CopyTo(newMemoryStream);
                    //var uploadStatus =  _bucket.UploadFile(newMemoryStream, imgPath);
                    //if (!uploadStatus)
                    //{
                    //    imgPath = string.Format("{0}/{1}/{2}", req.OrgId, "_Category", "no-img.png");
                    //}


                    var result = "";
                    try
                    {
                        var s3Client = new AmazonS3Client("AKIARIILU3T4YM5ZL24N", "D+wwxMGU+xjC5Ra3AiDteuIwHxbbnjuqOnZ1Lc3f", Amazon.RegionEndpoint.APNortheast1);
                        var bucketName = "vigpublicappnw";
                        var keyName = req.Imgname.FileName;
                        //if (!string.IsNullOrEmpty(subFolder))
                        //    keyName = keyName + "/" + subFolder.Trim();
                        //keyName = keyName + "/" + myfile.FileName;

                        var fs = req.Imgname.OpenReadStream();
                        var request = new Amazon.S3.Model.PutObjectRequest
                        {
                            BucketName = bucketName,
                            Key = keyName,
                            InputStream = fs,
                            ContentType = req.Imgname.ContentType
                        };
                        await s3Client.PutObjectAsync(request);

                        result = string.Format("http://{0}.s3.amazonaws.com/{1}", bucketName, keyName);
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message;
                    }
                }


                return Ok(new { results = "OK" });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }


        public class FileRequest
        {

            public int id { get; set; }
            public IFormFile Imgname { get; set; }

        }

    }
}
