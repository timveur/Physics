using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Physics
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// переход на основную страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void StartImageClicked(object sender, EventArgs e)
        {
            StartImage.Opacity = 1;

            await StartImage.RotateTo(360, 500);//вращение
            await StartImage.ScaleTo(1.6, 500);//изменение размера
            await StartImage.FadeTo(0.2, 70);//прозрачность
            await Navigation.PushAsync(new CatalogPage(), false);



        }
    }
}
