using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.AmazonS3
{
    public interface IAmazonS3Access
    {
        Task GetFileDataAsync(string S3path, string fileName);
    }
}
