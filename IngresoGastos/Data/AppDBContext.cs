using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IngresoGastos.Models;

namespace IngresoGastos.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base("DefaultConnection")
        {

        }

        public DbSet<IngresoGastosModel> ingresoGastos{ get; set; }
    }
}