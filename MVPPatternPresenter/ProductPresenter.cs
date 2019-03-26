using DataAccessLayer;
using MVPPatternModels;
using MVPPatternViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPPatternPresenter
{
    public class ProductPresenter
    {
        IProductFormView _view;
        IDataAccessRepo _repo;
        public ProductPresenter(IProductFormView view,IDataAccessRepo repo)
        {
            _view = view;
            _repo = repo;
            _view.OnLoaded += _view_OnLoaded;
            _view.OnSelected += _view_OnSelected;
        }
        private void _view_OnSelected(Product product)
        {
            var gelen= _repo.Select(product.ProductId);
            _view.BindToDetail(gelen);
        }
        private void _view_OnLoaded()
        {
           var sonuc= _repo.SelectAll();
            _view.GetAllProducts(sonuc);
        }
    }
}
