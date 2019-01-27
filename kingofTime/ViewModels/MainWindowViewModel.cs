using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kingofTime.Models;
using Prism.Mvvm;

namespace kingofTime.ViewsModels
{
    public class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {

        }

        private string m_html;

        public string Html
        {
            set { SetProperty(ref m_html, value); }
            get { return m_html; }
        }

        public void ReturnHTML(string url)
        {
            Html = Webscraping.GetHtml(url);
        }

        public async void Login()
        {
            var login = new Login("test", "pass");
            await login.LoginAsync(); 
        }


    }
}
