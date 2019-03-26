using System;
using System.Collections.Generic;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVPPatternModels;
using MVPPatternViews;
using NSubstitute;

namespace MVPPatternPresenter.UnitTests
{
    [TestClass]
    public class ProductPresenterTests
    {
        List<Product> dummyProducts;
        public ProductPresenterTests()
        {
            dummyProducts = new List<Product>();
            dummyProducts.Add(new Product()
            {
                ProductId = 1,
                ProductName = "x",
                Price = 10,
                Stok = 1
            });
            dummyProducts.Add(new Product()
            {
                ProductId = 2,
                ProductName = "y",
                Price = 110,
                Stok = 4
            });
            dummyProducts.Add(new Product()
            {
                ProductId = 3,
                ProductName = "z",
                Price = 102,
                Stok = 21
            });
            dummyProducts.Add(new Product()
            {
                ProductId = 4,
                ProductName = "t",
                Price = 1,
                Stok = 13
            });
        }

        [TestMethod]
        public void Ctor_OnLoaded_WillGetProducts()
        {
            var mock = Substitute.For<IProductFormView>();
            var stub = Substitute.For<IDataAccessRepo>();
            ProductPresenter pr = new ProductPresenter(mock, stub);
            mock.OnLoaded += Raise.Event<Action>();
            mock.Received().GetAllProducts(dummyProducts);
        }
    }
}
