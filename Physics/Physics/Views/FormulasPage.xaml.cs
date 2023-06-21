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
    public partial class FormulasPage : ContentPage
    {
        public List<Formula> listFormula { get; set; }
        public FormulasPage()
        {
            InitializeComponent();
            listFormula = FormulasController.GetFormulas();
            FormulasListView.ItemsSource = listFormula;

        }
    }
}