
using System.Collections.Generic;
using System.IO;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Configuration;

namespace AwsDotnetS3.Services
{
    public class S3Service : IBucket
    {



        AmazonS3Client client;
        IConfiguration _configuration;
        public S3Service(IConfiguration configuration)
        {
            client = new AmazonS3Client();
            _configuration = configuration;

        }

        public List<string> ListBuckets()
        {

            List<string> retval = new List<string>();
            try
            {
                var buckets = client.ListBucketsAsync();
                foreach (var item in buckets.Result.Buckets)
                {
                    retval.Add(item.BucketName);
                }

                return retval;
            }

            catch (System.Exception)
            {
                throw;
            }



        }

        public void DownloadAllFiles(string bucket)
        {

            string downloadFolder = _configuration.GetValue<string>("aws-s3:downloadFolder");
            try
            {
                var request = new ListObjectsV2Request
                {
                    BucketName = bucket,
                    MaxKeys = 1000,

                };

                var response = client.ListObjectsV2Async(request);
                var utility = new TransferUtility(client);
                foreach (var item in response.Result.S3Objects)
                {
                    utility.Download($"{downloadFolder}/{item.Key}", bucket, item.Key);
                }
            }
            catch (System.Exception ex)
            {
                // TODO
                throw;
            }
        }

        public void DownloadSingleFile(string bucket, string filename)
        {

            string downloadFolder = _configuration.GetValue<string>("aws-s3:downloadFolder");
            try
            {
                var request = new ListObjectsV2Request
                {
                    BucketName = bucket,
                    MaxKeys = 1000,

                };

                var response = client.ListObjectsV2Async(request);
                var utility = new TransferUtility(client);

                var result = response.Result.S3Objects.Find(p => p.Key == filename);

                utility.Download($"{downloadFolder}/{result.Key}", bucket, result.Key);

            }
            catch (System.Exception)
            {
                // TODO
                throw;
            }
        }

        public void FileUpload(List<Ficheiros> files, string bucketName)
        {
            try
            {

                var utility = new TransferUtility(client);
                files.ForEach(item =>
                {

                    using (FileStream fs = File.Open(item.FilePath, FileMode.Open))
                    {

                        utility.Upload(fs, bucketName, item.Filename);
                    }

                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void CreateBucket(string bucket)
        {

            if (string.IsNullOrEmpty(bucket))
            {
                throw new System.ArgumentException("Bucket name is required");
            }
            try
            {
                client.PutBucketAsync(bucket);
            }
            catch (System.Exception)
            {
                throw;
            }



        }

        public void DeleteObjectInBucket(string bucket, string objectKey)
        {


            try
            {
                DeleteObjectRequest request = new DeleteObjectRequest
                {

                    BucketName = bucket,
                    Key = objectKey

                };

                client.DeleteObjectAsync(request);
            }
            catch (System.Exception ex)
            {
                // TODO
                throw;
            }
        }

        public void BucketPermissions(string bucket, bool publicPrivate)
        {

            try
            {

                PutPublicAccessBlockRequest request = new PutPublicAccessBlockRequest
                {
                    PublicAccessBlockConfiguration = new PublicAccessBlockConfiguration
                    {
                        BlockPublicAcls = publicPrivate,
                        IgnorePublicAcls = publicPrivate,
                        BlockPublicPolicy = publicPrivate,
                        RestrictPublicBuckets = publicPrivate

                    },
                    BucketName = bucket

                };

                client.PutPublicAccessBlockAsync(request);

            }
            catch (System.Exception ex)
            {
                throw;
            }

        }

        public List<string> ListFilesInBucket(string bucket)
        {

            List<string> retval = new List<string>();
            try
            {
                var filesInBucket = client.ListObjectsAsync(bucket);

                foreach (var item in filesInBucket.Result.S3Objects)
                {
                    retval.Add(item.Key);
                }
            }
            catch (System.Exception)
            {
                // TODO
                throw;
            }
            return retval;


        }


    }
}