using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace CreativeCaptcha.Domain.MongoDb
{
    public static class DataBaseManager
    {
        public static void AddCaptcha(CaptchaBasicImage imageToAdd)
        {
            using(var conn = new SqlConnection(Properties.Settings.Default.captchadb))
            {
                var gesturelist = compressMouseGestures(imageToAdd.Movements);
                var p = new DynamicParameters();
                p.Add("@description" ,imageToAdd.DescriptiveSentence);
                p.Add("@imagepath", imageToAdd.ImagePath);
                p.Add("@gesturelist", gesturelist);

              var query =  conn.Query("dbo.addnewcaptcha", p ,commandType: CommandType.StoredProcedure);     
            };
        }

        public static string compressMouseGestures(List<MouseGesture> gestures)
        {
            string fullGestureList = string.Empty;

            foreach(var gesture in gestures)
            {
               fullGestureList = string.Concat(fullGestureList, gesture.Direction, gesture.Length);
            }

            return fullGestureList;
        }

    }
}
