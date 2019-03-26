using MVPPatternModels;
using MVPPatternViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Object Oriented 
namespace ProductApplication
{
    public partial class ProductForm : Form, IProductFormView
    {
        public ProductForm()
        {
            InitializeComponent();
            this.Load += ProductForm_Load;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.OnSelected != null)
            {
                OnSelected((Product)listBox1.SelectedItem);
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            if(this.OnLoaded!=null)
                OnLoaded();
        }

        public event Action OnLoaded;
        public event Action<Product> OnSelected;

        public void GetAllProducts(IEnumerable<Product> productList)
        {
            listBox1.DataSource = productList;
            listBox1.DisplayMember = "ProductName";
            listBox1.ValueMember = "ProductId";
        }

        public void BindToDetail(Product gelen)
        {
            textBox1.Text = gelen.Price.ToString();
            textBox2.Text = gelen.Stok.ToString();
            textBox3.Text = gelen.ProductName;
        }
    }
}
