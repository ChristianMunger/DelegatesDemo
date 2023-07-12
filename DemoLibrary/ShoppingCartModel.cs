using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ShoppingCartModel
    {
        // whenever used it will return void and take in one decimal
        // not thread safe in this example
        public delegate void MentionDiscount(decimal subTotal);
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
        
        public decimal GenerateTotal(MentionDiscount mentionSubtotal,
            // Func of items, subtotal and returns output
            Func<List<ProductModel>, decimal, decimal> calculateDiscountedTotal,
            // Action like func but returns void
            Action<string> tellUserWeAreDiscounting)
        {
            decimal subTotal = Items.Sum(x => x.Price);
            mentionSubtotal(subTotal);
            tellUserWeAreDiscounting("We are applying your discount");
            return calculateDiscountedTotal(Items, subTotal);
            //if (subTotal > 100)
            //{

            //    return subTotal * .80M;
            //}

            //else if (subTotal > 50)
            //{
            //    return subTotal * .85M;

            //}
            //else if (subTotal > 10)
            //{
            //    return subTotal * .90M;

            //}
            //return subTotal;

        }
    }
}
