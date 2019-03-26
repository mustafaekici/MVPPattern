using MVPPatternModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccess: IDataAccessRepo
    {
        List<Product> productList;
        public DataAccess()
        {
            productList = new List<Product>();
            productList.Add(new Product()
            {
                ProductId = 1,
                ProductName = "x",
                Price = 10,
                Stok = 1
            });
            productList.Add(new Product()
            {
                ProductId = 2,
                ProductName = "y",
                Price = 110,
                Stok = 4
            });
            productList.Add(new Product()
            {
                ProductId = 3,
                ProductName = "z",
                Price = 102,
                Stok = 21
            });
            productList.Add(new Product()
            {
                ProductId = 4,
                ProductName = "t",
                Price = 1,
                Stok = 13
            });
        }

        public Product Select(int id)
        {
            return productList.Find(x => x.ProductId == id);
        }

        public IEnumerable<Product> SelectAll()
        {
            return productList;
        }

       
    }

  
}
