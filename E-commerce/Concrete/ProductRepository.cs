using E_commerce.Data;
using E_commerce.Helper;
using E_commerce.Interface;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace E_commerce.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public ProductViewModel GetProductById(int ProductId)
        {
            using (ECommercePEntities ecommerce = new ECommercePEntities())
            {
                var myResult = ecommerce.Products.Where(y=>y.ID == ProductId).FirstOrDefault();

                return myResult.ToViewModel();
            }
        }

        public List<ProductViewModel> GetProductInfo()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            using (ECommercePEntities ecommerce = new ECommercePEntities())
            {
                var myResult = ecommerce.Products.ToList().Select(y=> new ProductViewModel()
                {
                    Id = y.ID,
                    PruductName = y.ProductName,
                    ProductDescription = y.ProductDescription,
                    Price = y.Price.Value,
                    Qty = y.Qty.Value

                });
                products= myResult.ToList();

            }
            return products;
        }

        public bool InsertUpdateProduct(ProductViewModel productViewModel)
        {
            using (ECommercePEntities ecommerce = new ECommercePEntities())
            {
                if (productViewModel.Id == 0)
                {
                    var myResult = ecommerce.Products.Add(productViewModel.ToViewModel(null));

                    var myRes = ecommerce.SaveChanges();

                    return myRes > 0 ? true : false;
                }
                else
                {
                    var myProduct = ecommerce.Products.Where(y=>y.ID == productViewModel.Id).FirstOrDefault();


                    myProduct = productViewModel.ToViewModel(myProduct);
                 
                    //myProduct.ProductName = productViewModel.PruductName;
                    //myProduct.ProductDescription = productViewModel.ProductDescription;
                    //myProduct.Price = productViewModel.Price;
                    //myProduct.Qty = productViewModel.Qty;
                    
                    var myresult = ecommerce.SaveChanges();

                    return myresult > 0 ? true : false;
                }
            }

        }

        public bool ProductDelete(int ProductId)
        {
            using (ECommercePEntities eCommerce = new ECommercePEntities())
            {
                var myResult = eCommerce.Products.Where(y=>y.ID == ProductId).FirstOrDefault();

                eCommerce.Products.Remove(myResult);

                var myRes = eCommerce.SaveChanges();
                

                return myRes > 0 ? true : false;
            }
        }

       
    }
}