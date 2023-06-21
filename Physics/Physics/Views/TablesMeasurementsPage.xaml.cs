using Physics.Controllers;
using Physics.Models;
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
    public partial class TablesMeasurementsPage : ContentPage
    {
        public List<TablesMeasurement> listTablesMeasurements { get; set; }

        public TablesMeasurementsPage()
        {
            InitializeComponent();
            listTablesMeasurements = TablesMeasurementsController.GetTablesMeasurements();
            TablesMeasurementsListView.ItemsSource = listTablesMeasurements;

        }

        /// <summary>
        /// Событие клика по кнопке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnItemClicked(object sender, System.EventArgs e)
        {
            try
            {   
                Button activeButton = sender as Button;
                if (sender is Button button && button.BindingContext is TablesMeasurement selectedMeasurement)
                {
                    string titleMeas = activeButton.Text;
                    int idMeas = Convert.ToInt32(activeButton.ClassId);
                    await Navigation.PushAsync(new MeasurementsPage(idMeas, titleMeas));
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Возникла непредвиденная ошибка.", "OK");
                throw; ;
            }
           
        }
    }
}