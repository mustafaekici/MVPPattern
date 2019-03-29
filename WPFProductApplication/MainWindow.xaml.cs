using DataAccessLayer;
using MVPPatternModels;
using MVPPatternPresenter;
using MVPPatternViews;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFProductApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IProductFormView
    {
        public MainWindow()
        {
            string conf = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            var data = new DataAccess(conf);
            var presenter = new ProductPresenter(this, data);

            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.OnLoaded != null)
                OnLoaded();
        }

        public event Action OnLoaded;
        public event Action<Product> OnSelected;

        public void BindToDetail(Product gelen)
        {
            txt1.Text = gelen.Price.ToString();
            txt2.Text = gelen.Stok.ToString();
            txt3.Text = gelen.ProductName;
        }

        public void GetAllProducts(IEnumerable<Product> productList)
        {
            listbox.ItemsSource = productList;
            listbox.DisplayMemberPath = "ProductName";
            listbox.SelectedValuePath = "ProductId";
        }

        private void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.OnSelected != null)
            {
                try
                {
                    OnSelected((Product)listbox.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
