using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeCaptcha.Domain
{
   

   public class Position
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Direction { get; set; }

       public Position(int x, int y, string direction)
       {
    
          XCoordinate = x;
          YCoordinate =y;
          Direction = direction;
       }
    }
}
