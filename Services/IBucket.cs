using System.Collections.Generic;

namespace AwsDotnetS3.Services
{
    public interface IBucket
    {
        List<string> ListFilesInBucket(string bucket);
        List<string> ListBuckets();
        void CreateBucket(string bucket);
        void FileUpload(List<Ficheiros> files, string bucketName);
        void DownloadAllFiles(string bucket);
        void DownloadSingleFile(string bucket, string filename);

        void DeleteObjectInBucket(string bucket, string objectKey);

        void BucketPermissions(string bucket, bool publicPrivate);
    }
}