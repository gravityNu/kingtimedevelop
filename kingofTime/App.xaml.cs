using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using kingofTime.Views;
using kingofTime.ViewsModels;
using Prism.Mvvm;
using Unity;

namespace kingofTime
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {


        // アプリで管理するコンテナ
        private IUnityContainer Container { get; } = new UnityContainer();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory(x => this.Container.Resolve(x));
            var vm = new MainWindowViewModel();
            var main = this.Container.Resolve<MainWindowView>();
            main.DataContext = vm;
            main.Show();

        }


    }
}
