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
                var p = new DynamicParameters();
                p.Add("@description" ,imageToAdd.DescriptiveSentence);
                p.Add("@imagepath", imageToAdd.ImagePath);
                p.Add("@gesturelist", imageToAdd.Movements);

              var query =  conn.Query("dbo.addnewcaptcha", p ,commandType: CommandType.StoredProcedure);     
            };
        }

    }
}
