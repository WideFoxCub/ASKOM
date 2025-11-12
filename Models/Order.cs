using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASKOM.Models
{
    public class Order
    {
        public required string Id { get; set; }
        public required string Produkt { get; set; }
        public int IloscPlanowana { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Produkt} (Plan: {IloscPlanowana})";
        }
    }
}