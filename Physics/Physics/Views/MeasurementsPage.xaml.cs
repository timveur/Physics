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
    public partial class MeasurementsPage : ContentPage
    {
        public List<Measurement> listMeasurements { get; set; }
        public MeasurementsPage(int idTablesMeasurements, string titleMeasure)
        {
            InitializeComponent();
            listMeasurements = MeasurementsController.GetMeasurementsFromTablesId(idTablesMeasurements);
            MeasurementsListView.ItemsSource = listMeasurements;
            Title = titleMeasure;

        }
    }
}