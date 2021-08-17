using System.Collections.Generic;
using AwsDotnetS3.Model;
using AwsDotnetS3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwsDotnetS3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BucketController : ControllerBase
    {

        IBucket iBucket;
        public BucketController(IBucket bucket)
        {
            iBucket = bucket;
        }

        [HttpPost]
        public ActionResult CreateBucket([FromBody] Bucket bucket)
        {
            try
            {
                iBucket.CreateBucket(bucket.Name);
                return Created("", bucket.Name);
            }
            catch (System.Exception ex)
            {
                ProblemDetails problem = new ProblemDetails
                {
                    Title = "Error creating Bucket",
                    Instance = HttpContext.Request.Path,
                    Type = ex.GetType().Name,
                    Status = StatusCodes.Status400BadRequest,
                    Detail = ex.Message
                };

                return BadRequest(problem);
            }

        }

        [HttpPut("{bucket}/{publicPrivate}/permissions")]
        public ActionResult SetBucketPermissions(string bucket, bool publicPrivate)
        {

            try
            {
                iBucket.BucketPermissions(bucket, publicPrivate);
                return Ok();
            }
            catch (System.Exception ex)
            {
                ProblemDetails problem = new ProblemDetails
                {

                    Title = "Error listing Buckets",
                    Instance = HttpContext.Request.Path,
                    Type = ex.GetType().Name,
                    Status = StatusCodes.Status400BadRequest,
                    Detail = ex.Message
                };

                return BadRequest(problem);
            }


        }


        [HttpGet]
        public ActionResult GetBuckets()
        {
            try
            {
                var retval = iBucket.ListBuckets();
                return Ok(retval);
            }
            catch (System.Exception ex)
            {
                ProblemDetails problem = new ProblemDetails
                {
                    Title = "Error listing Buckets",
                    Instance = HttpContext.Request.Path,
                    Type = ex.GetType().Name,
                    Status = StatusCodes.Status400BadRequest,
                    Detail = ex.Message
                };

                return BadRequest(problem);
            }


        }

        [HttpPost("{bucket}/files")]
        public ActionResult UploadFiles([FromBody] List<Ficheiros> ficheiros, string bucket)
        {
            try
            {
                iBucket.FileUpload(ficheiros, bucket);
                return Ok();
            }

            catch (System.Exception ex)
            {
                ProblemDetails problem = new ProblemDetails
                {

                    Detail = ex.Message,
                    Type = ex.GetType().Name,
                    Status = StatusCodes.Status400BadRequest,
                    Instance = HttpContext.Request.Path
                };

                return BadRequest(problem);
            }
        }

        [HttpGet("{bucket}/files/download")]
        public ActionResult DownloadFiles(string bucket)
        {

            try
            {
                iBucket.DownloadAllFiles(bucket);
                return Ok();
            }
            catch (System.Exception ex)
            {
                ProblemDetails problem = new ProblemDetails
                {
                    Title = "Error downloading all files",
                    Detail = ex.Message,
                    Type = ex.GetType().Name,
                    Status = StatusCodes.Status400BadRequest,
                    Instance = HttpContext.Request.Path
                };

                return BadRequest(problem);
            }
        }

        [HttpGet("{bucket}/{filename}/download")]
        public ActionResult DownloadSingleFile(string bucket, string filename)
        {

            try
            {
                iBucket.DownloadSingleFile(bucket, filename);
                return Ok();
            }
            catch (System.Exception ex)
            {
                ProblemDetails problem = new ProblemDetails
                {

                    Detail = ex.Message,
                    Type = ex.GetType().Name,
                    Status = StatusCodes.Status400BadRequest,
                    Instance = HttpContext.Request.Path
                };

                return BadRequest(problem);

            }
        }

        [HttpGet("{bucketName}/files")]
        public ActionResult GetFiles(string bucketName)
        {
            try
            {
                var list = iBucket.ListFilesInBucket(bucketName);
                return Ok(list);
            }
            catch (System.Exception ex)
            {
                ProblemDetails problem = new ProblemDetails
                {

                    Detail = ex.Message,
                    Type = ex.GetType().Name,
                    Status = StatusCodes.Status400BadRequest,
                    Instance = HttpContext.Request.Path
                };

                return BadRequest(problem);
            }

        }

        [HttpDelete("{bucketName}/{filename}")]
        public ActionResult DeleteFileInBucket(string bucketName, string filename)
        {


            try
            {
                iBucket.DeleteObjectInBucket(bucketName, filename);
                return Ok();
            }
            catch (System.Exception ex)
            {
                ProblemDetails problem = new ProblemDetails
                {

                    Detail = ex.Message,
                    Type = ex.GetType().Name,
                    Status = StatusCodes.Status400BadRequest,
                    Instance = HttpContext.Request.Path
                };

                return BadRequest(problem);
            }
        }
    }
}