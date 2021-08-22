using Amazon;
using Amazon.S3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using GetObjectRequest = Amazon.S3.GetObjectRequest;

namespace Service.AmazonS3
{

    public class AmazonS3Access : IAmazonS3Access
    {
        private string bucketName = "noaa-gfs-bdp-pds";

        public  async Task GetFileDataAsync(string S3path, string fileName)
        {
            try
            {
                IAmazonS3 client = new AmazonS3Client(RegionEndpoint.USEast1);
                ListObjectsRequest request = new ListObjectsRequest
                {
                    BucketName = bucketName,
                    Prefix = S3path
                };
                ListObjectsResponse response = await client.ListObjectsAsync(request);
                var file = response.S3Objects.Where(x => x.Key == fileName);
               // return file;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
