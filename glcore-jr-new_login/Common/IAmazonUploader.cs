namespace Common
{
    public interface IAmazonUploader
    {
        bool SendFileToS3(string idbucket, string localFilePath, string bucketName, string subDirectoryInBucket, string fileNameInS3);

        bool DeleteS3File(string idbucket, string bucketName, string fileNameInS3);

        string DownLoadFile(string idbucket, string bucketname, string archivo, string subDirectoryInBucket);
    }
}