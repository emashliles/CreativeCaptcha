using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeCaptcha.Domain
{
    public class MouseGesture
    {
        public string Direction { get; set; }
        public int Length { get; set; }

        public MouseGesture()
        {

        }

        public MouseGesture(string direction, int length)
        {
            Direction = direction;
            Length = length;
        }
    }
}
