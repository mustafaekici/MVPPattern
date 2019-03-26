using MVPPatternModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPPatternViews
{
    public interface IProductFormView
    {
        void GetAllProducts(IEnumerable<Product> productList);
        event Action OnLoaded;
        event Action<Product> OnSelected;
        void BindToDetail(Product gelen);
    }
}
