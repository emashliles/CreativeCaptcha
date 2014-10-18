using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeCaptcha.Domain.Validation
{
   public class BasicValidator
    {
        public ImageRepository Repo { get; set; }

        public BasicValidator()
        {
            Repo = new ImageRepository();
        }

       public bool ValidateBasic(string name, List<MouseGesture> movements)
       {
           var captchaBasicImage = Repo.GetImageByName(name);

           if(captchaBasicImage == null)
           {
               return false;
           }

           foreach(var movement in movements)
           {
               if (!captchaBasicImage.Movements.Contains(movement))
               {
                   return false;
               }   
           }
           return true;
       }
    }
}
