using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Service.AmazonS3;

namespace Services.WeatherForecast
{
    public class WeatherForecast : IWeatherForecast
    {
        private IAmazonS3Access _amazonS3Access;
        public WeatherForecast(IAmazonS3Access amazonS3Access)
        {
            _amazonS3Access = amazonS3Access;
        }
        public int? GetWeatherForecast(DateTime date, double lat, double lon)
        {
            int? temp = null;
            try
            {
                string S3path, fileName = null;
                (S3path, fileName) = GetFilePath(date, lat, lon);
                GetFileDataAsync(S3path, fileName);
                return temp;
            }
            catch (Exception e)
            {
                //log 
                return null;
            }
        }

        private (string S3path,string fileName) GetFilePath(DateTime date, double lat, double lon)
        {
            string path , S3fileName = null;
            if (date < DateTime.Now)
            {
                path = String.Format(Consts.BucketPath, date.ToString("yyyyMMdd"));
                S3fileName = String.Format(Consts.BucketfileName,  date.ToString("HH"));
            }
            else
            {
                int Daydiff = (date - DateTime.Now).Hours;
                int Hourdiff = (date - DateTime.Now).Hours;
                int diff = (Daydiff > 0 ? Daydiff * 24 : 0) + Hourdiff;
                path = String.Format(Consts.BucketPath, date.ToString("yyyyMMdd"));
                S3fileName = String.Format(Consts.BucketfileName, (diff < 10 ? "0" + diff : diff.ToString()));
            }
            return (path, S3fileName);
        }

        private async System.Threading.Tasks.Task GetFileDataAsync(string S3path, string fileName)
        {
            await _amazonS3Access.GetFileDataAsync(S3path, fileName).ConfigureAwait(false);

        }
    }
}
