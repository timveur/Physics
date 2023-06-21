using Physics.Controllers;
using Physics.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Physics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabPage : ContentPage
    {
        public List<LabWork> listLabWorks { get; set; }
        public LabPage()
        {
            InitializeComponent();
            listLabWorks = LabWorksController.GetLabWorks();
            LabsListView.ItemsSource = listLabWorks;
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Button activeButton = sender as Button;
                int idLabWorks = Convert.ToInt32(activeButton.ClassId);
                LabWork selectedLabWork = listLabWorks.FirstOrDefault(x => x.IdLabWorks == idLabWorks);
                string descriptionLabWorks = selectedLabWork.DescriptionLabWork;
                await DisplayAlert(activeButton.Text, descriptionLabWorks, "OK"); 
               
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Возникла непредвиденная ошибка.", "OK");
                throw;
            }
        }

    }
}