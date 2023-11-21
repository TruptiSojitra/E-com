using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Interface
{
    internal interface IProductRepository
    {
        List<ProductViewModel> GetProductInfo();

        bool InsertUpdateProduct (ProductViewModel productViewModel);

        bool ProductDelete (int ProductId);

        ProductViewModel GetProductById( int ProductId);
    }
}
