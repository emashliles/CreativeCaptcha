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
        public int wrongDirectionCount { get; set; }
        public int iteratorModifier { get; set; }

        public BasicValidator()
        {
            Repo = new ImageRepository();

            wrongDirectionCount = 0;
            iteratorModifier = 0;
        }

       public bool ValidateBasic(int id, List<MouseGesture> movements)
       {
           var captchaBasicImage = Repo.GetImageByID(id);

           if(captchaBasicImage == null)
           {
               return false;
           }

           for(var i = 0; i < movements.Count; i++ )
           {

              if(!CompasDirectionIsOK(movements.ElementAt(i).Direction, captchaBasicImage.MovementsList.ElementAt(i-iteratorModifier).Direction))
               {
                   if(wrongDirectionCount == 2)
                   {
                       return false;
                   }
                   else
                   {
                       wrongDirectionCount++;
                       iteratorModifier++;
                       continue;
                   }
               }

              if (!LengthIsOK(movements.ElementAt(i).Length, captchaBasicImage.MovementsList.ElementAt(i - iteratorModifier).Length))
              {

                  return false;
              }   
           }
           return true;
           
       }
  

       public bool LengthIsOK(int givenLength, int idealLength)
       {
           var difference = Math.Abs(givenLength - idealLength);

           if( difference > 50)
           {
               return false;
           }

           return true;
       }

       public bool CompasDirectionIsOK(string givenDirection, string idealDirection)
       {
           if(givenDirection.Equals(idealDirection))
           {
               wrongDirectionCount = 0;
               return true;
           }

           return false;
       }
    }
}
