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

       public bool ValidateBasic(int id, List<MouseGesture> movements)
       {
           var captchaBasicImage = Repo.GetImageByID(id);

           if(captchaBasicImage == null)
           {
               return false;
           }

           for(var i = 0; i >= movements.Count -1; i++ )
           {

               if (!LengthIsOK(movements.ElementAt(i).Length, captchaBasicImage.MovementsList.ElementAt(i).Length) && CompasDirectionIsOK(movements.ElementAt(i).Direction, captchaBasicImage.MovementsList.ElementAt(i).Direction)) 
               {
                  
                   return false;
               }   
           }
           return true;
           
       }
  

       public bool LengthIsOK(int givenLength, int idealLength)
       {
           var difference = Math.Abs(givenLength - idealLength);

           if( difference > 5)
           {
               return false;
           }

           return true;
       }

       public bool CompasDirectionIsOK(string givenDirection, string idealDirection)
       {
           if(givenDirection.Equals(idealDirection))
           {
               return true;
           }

           return false;
       }
    }
}
