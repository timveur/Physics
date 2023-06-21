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
    public partial class LabPage : ContentPage
    {
        public List<LabWork> listLabWorks { get; set; }
        private Label currentLabel;
        public LabPage()
        {
            InitializeComponent();
            listLabWorks = LabWorksController.GetLabWorks();
            LabsListView.ItemsSource = listLabWorks;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Label label = (Label)clickedButton.Parent.FindByName("label");

            // Сворачивание предыдущего label
            if (currentLabel != null && currentLabel.IsVisible)
            {
                currentLabel.IsVisible = false;
            }

            // Показать/скрыть текущий label
            if (currentLabel != label)
            {
                label.IsVisible = true;
                currentLabel = label;

                //// Получение ID нажатого элемента
                //var labWork = (LabWork)clickedButton.BindingContext;
                //int idLabWork = labWork.IdLabWorks;

                //// Получение данных по idLabWork и обновление списка
                //UpdateListLabWorks(idLabWork);
            }
            else
            {
                currentLabel = null;
            }
        }

        //private void UpdateListLabWorks(int idLabWork)
        //{
        //    // Получение данных из API по idLabWork и обновление списка
        //    listLabWorks = LabWorksController.GetLabWorksById(idLabWork);
        //    LabsListView.ItemsSource = listLabWorks;
        //}
    }
}