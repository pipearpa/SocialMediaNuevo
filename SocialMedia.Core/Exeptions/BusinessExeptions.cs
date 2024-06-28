using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Exeptions
{
     public class BusinessExeptions : Exception
    {
        public BusinessExeptions()
        {
            
        }

        public BusinessExeptions(string message) : base(message) 
        {
            
        }
    }
}
