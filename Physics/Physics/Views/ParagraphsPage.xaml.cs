using Physics.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Physics.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ParagraphsPage : ContentPage
	{
		public ParagraphsPage (string fileName, string titleParagraph)
		{
			InitializeComponent ();
			try
			{
                Title = titleParagraph;
                string htmlFilePath = Controllers.Manager.RootUrlServer + fileName;
                // Загрузка файла в WebView
                ParagraphsWebView.Source = new UrlWebViewSource { Url = htmlFilePath };
                // Установка свойств WebView
                ParagraphsWebView.VerticalOptions = LayoutOptions.FillAndExpand;
                ParagraphsWebView.HorizontalOptions = LayoutOptions.StartAndExpand;
                Content = ParagraphsWebView;
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", Convert.ToString(ex), "OK");
                throw;
            }
           

           
        }

	}
}