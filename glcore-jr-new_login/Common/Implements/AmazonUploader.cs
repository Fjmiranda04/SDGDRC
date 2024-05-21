using Amazon;
using Amazon.CognitoIdentity;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;

namespace Common.Implements
{
    public class AmazonUploader : IAmazonUploader
    {
        public bool SendFileToS3(string idbucket, string localFilePath, string bucketName, string subDirectoryInBucket, string fileNameInS3)
        {
            CognitoAWSCredentials credentials = new CognitoAWSCredentials(idbucket, RegionEndpoint.USEast1);

            IAmazonS3 client = new AmazonS3Client(credentials, RegionEndpoint.USEast1); //(AmazonS3Client)(new Amazon.CognitoIdentity.AmazonCognitoIdentityClient(credentials));

            // create a TransferUtility instance passing it the IAmazonS3 created in the first step
            TransferUtility utility = new TransferUtility(client);
            // making a TransferUtilityUploadRequest instance
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

            if (subDirectoryInBucket == "" || subDirectoryInBucket == null)
            {
                request.BucketName = bucketName; //no subdirectory just bucket name
            }
            else
            {   // subdirectory and bucket name
                request.BucketName = bucketName + "/" + subDirectoryInBucket;
            }
            request.Key = fileNameInS3; //file name up in S3
            request.FilePath = System.Net.WebUtility.UrlDecode(localFilePath); //local file name

            request.CannedACL = S3CannedACL.PublicRead;
            request.AutoCloseStream = false;
            request.AutoResetStreamPosition = false;
            utility.UploadAsync(request); //commensing the transfer
            // ("x-amz-acl", "public-read");

            /*if (System.IO.File.Exists(localFilePath))
            {
                System.IO.File.Delete(localFilePath);
            }*/
            return true; //indicate that the file was sent
        }

        public bool DeleteS3File(string idbucket, string bucketName, string fileNameInS3)
        {
            CognitoAWSCredentials credentials = new CognitoAWSCredentials(idbucket, RegionEndpoint.USEast1);
            IAmazonS3 client = new AmazonS3Client(credentials, RegionEndpoint.USEast1);
            TransferUtility utility = new TransferUtility(client);

            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = fileNameInS3
            };

            utility.S3Client.DeleteObjectAsync(deleteObjectRequest).Wait();

            return true;
        }

        public string DownLoadFile(string idbucket, string bucketname, string archivo, string subDirectoryInBucket)
        {
            CognitoAWSCredentials credentials = new CognitoAWSCredentials(idbucket, RegionEndpoint.USEast1);
            IAmazonS3 client = new AmazonS3Client(credentials, RegionEndpoint.USEast1);
            TransferUtility utility = new TransferUtility(client);
            TransferUtilityDownloadRequest request = new TransferUtilityDownloadRequest();

            if (subDirectoryInBucket == "" || subDirectoryInBucket == null)
            {
                request.BucketName = bucketname; //no subdirectory just bucket name
            }
            else
            {   // subdirectory and bucket name
                request.BucketName = bucketname + @"/" + subDirectoryInBucket;
            }

            request.BucketName = bucketname;
            request.Key = archivo;
            request.FilePath = Environment.CurrentDirectory + @"/wwwroot/Temp/Trash/" + archivo; //local file name

            utility.Download(request.FilePath, bucketname, archivo);

            return request.FilePath;
        }
    }
}