using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Newtonsoft.Json;

namespace CreativeCaptcha.Domain.MongoDb
{
    public static class DataBaseManager
    {
        public static void AddCaptcha(CaptchaBasicImage imageToAdd)
        {
            using(var conn = new SqlConnection(Properties.Settings.Default.captchadb))
            {
                //var gesturelist = compressMouseGestures(imageToAdd.MovementsList);
                var p = new DynamicParameters();
                p.Add("@description" ,imageToAdd.DescriptiveSentence);
                p.Add("@imagepath", imageToAdd.ImagePath);
                p.Add("@gesturelist", imageToAdd.MovementsJson);

              var query =  conn.Query("dbo.addnewcaptcha", p ,commandType: CommandType.StoredProcedure);     
            };
        }

        public static List<CaptchaBasicImage> GetCaptchas()
        {
            List<CaptchaBasicImage> results;

            using(var conn = new SqlConnection(Properties.Settings.Default.captchadb)){
                results = conn.Query<CaptchaBasicImage>("dbo.returnallcaptchas", null, commandType: CommandType.StoredProcedure).ToList();  
            }

            //foreach(var result in results)
            //{
            //    result.MovementsList = JsonConvert.DeserializeObject<List<MouseGesture>>(result.MovementsJson);
            //}
            
            return results;
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
