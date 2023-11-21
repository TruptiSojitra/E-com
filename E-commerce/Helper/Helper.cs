using E_commerce.Data;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_commerce.Helper
{
    /// <summary>
    /// Extention method for convert to view model 
    /// </summary>
    static class Helper
    {
        public static Product ToViewModel (this ProductViewModel productViewModel,Product product1)
        {
            if (product1 == null)
            {
                Product product =   new Product();
                product.ID = productViewModel.Id;
                product.ProductName = productViewModel.PruductName;
                product.ProductDescription = productViewModel.ProductDescription;
                product.Price = productViewModel.Price;
                product.Qty = productViewModel.Qty;
                return product;

            }
            else
            {
                product1.ProductName = productViewModel.PruductName;
                product1.ProductDescription = productViewModel.ProductDescription;
                product1.Price = productViewModel.Price;
                product1.Qty = productViewModel.Qty;

                return product1;

            }
               

           



            
        }

        public static ProductViewModel ToViewModel (this Product product)
        {
            ProductViewModel productViewModel = new ProductViewModel();

            productViewModel.PruductName = product.ProductName;
            productViewModel.ProductDescription = product.ProductDescription;
            productViewModel.Price = product.Price.Value;
            productViewModel.Qty = product.Qty.Value;
            productViewModel.Id = product.ID;

            return productViewModel;


        }




    }
}