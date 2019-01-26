using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using kingofTime.Views;

namespace kingofTime
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {

        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            var main = new MainWindowView();
            app.Run(main);
        }

    }
}
