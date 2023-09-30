using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webpllkdt.Models
{
    [Serializable]
    public class CartItem
    {
        public SanPham SanPhams { get; set; }

        public int Quantity { get; set; }
    }
}