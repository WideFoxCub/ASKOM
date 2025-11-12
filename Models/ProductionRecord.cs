using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASKOM.Models
{
    public class ProductionRecord
    {
        public required string OrderId { get; set; }
        public required string Produkt { get; set; }
        public int IloscWyprodukowana { get; set; }
        public DateTime DataRejestracji { get; set; }
    }
}