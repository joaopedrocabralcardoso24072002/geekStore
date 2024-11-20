using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geekStore.Models
{
    internal class ModProduto
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }
        public int quantidade { get; set; }
        public string foto { get; set; }
        public string tipo { get; set; }
    }
}
