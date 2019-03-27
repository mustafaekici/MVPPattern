using DataAccessLayer;
using MVPPatternPresenter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//Model - View - Presenter
//Model -> Class ( View a yansıyan yapılar)
//View  -> UI kullanici arabirimi
//Presenter -> Data Accessden gelen verilerin UI de nasil sunulacagını kontrol eder.

namespace ProductApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

          string conf=  ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            var data = new DataAccess(conf);
            var form = new ProductForm();

            var presenter = new ProductPresenter(form, data);
            
            Application.Run(form);


        }
    }
}
