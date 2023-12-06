using Hwork.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hwork.Models
{
    internal class Experts:BaseModel
    {
        public string Name { get; set; }    
        public string Surname {  get; set; }    

        public Positions Positions { get; set; }    
        
        public int PositionId { get; set; }
    }
}
