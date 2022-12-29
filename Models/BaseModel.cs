using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Models
{
    public class BaseModel
    {
        public DateTime CreationDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
