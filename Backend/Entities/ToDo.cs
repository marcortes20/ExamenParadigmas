using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ToDo : IHasId 
    {
        public int Id { get; set; }

        public string TodoTitle { get; set; }
        public string TodoContent { get; set; }
    }
}
