using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemySiparis.Models.ViewModels
{
    public class CartVM
    {
        public OrderProduct OrderProduct { get; set; }
        public IEnumerable<Cart> ListCart { get; set; }
    }
}
