using Hwork.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hwork.Models
{
    internal class Positions:BaseModel
    {
        public string Name { get; set; }

        public List<Experts> Experts { get; set; } = new List<Experts>();
    }
}
