using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDNewPro.Data
{
   public class Product
   {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Uint { get; set; }
   }

     public class Shop
     {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress {  get; set; }
     }
}
