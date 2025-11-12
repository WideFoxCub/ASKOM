using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASKOM.Config
{
    public static class Paths
    {
        private static readonly string BasePath = Path.Combine(AppContext.BaseDirectory, "Data");
        public static string OrdersPath => Path.Combine(BasePath, "orders.json");
        public static string ProductionPath => Path.Combine(BasePath, "production.json");
    }
}