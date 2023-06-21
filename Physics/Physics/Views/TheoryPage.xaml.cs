using Physics.Controllers;
using Physics.Models;
using System;
using System.Collections.Generic;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Physics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TheoryPage : ContentPage
    {
        List<Chapter> chapters;
        int idChapter = 0;
        public TheoryPage()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                chapters = ChaptersController.GetChapters();
                // Загрузка разделов в первый Picker
                List<Chapter> sections = chapters.FindAll(c => c.ParentId == 0);
                SectionPicker.ItemsSource = sections;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", Convert.ToString(ex), "OK");
                throw;
            }
        }


        private async void SectionPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Chapter selectedSection = (Chapter)SectionPicker.SelectedItem;
                if (selectedSection != null)
                {
                    if (chapters != null)
                    {
                        // Загрузка глав из выбранного раздела во второй Picker
                        List<Chapter> chaptersInSection = chapters.FindAll(c => c.ParentId == selectedSection.IdChapter);
                        ChapterPicker.ItemsSource = chaptersInSection;
                        ChapterPicker.IsEnabled = true;
                        ChapterPicker.Title = "Выберите главу";
                        ParagraphPicker.Title = "Сначала выберите главу";
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Возникла непредвиденная ошибка.", "OK");
                throw;
            }
        }

        private async void ChapterPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Chapter selectedChapter = (Chapter)ChapterPicker.SelectedItem;
                if (selectedChapter != null)
                {
                    if (chapters != null)
                    {
                        idChapter = selectedChapter.IdChapter;
                        // Загрузка параграфов из выбранной главы в третий Picker
                        List<Chapter> paragraphsInChapter = chapters.FindAll(c => c.ParentId == selectedChapter.IdChapter);
                        ParagraphPicker.ItemsSource = paragraphsInChapter;
                        ParagraphPicker.IsEnabled = true;
                        ParagraphPicker.Title = "Выберите параграф";
                    }
                }
            }

            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Возникла непредвиденная ошибка.", "OK");
                throw;
            }
        }


        private async void ParagraphPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (idChapter == 0)
                {
                    ParagraphPicker.Title = "Сначала выберите главу";
                }
                else
                {
                    var selectedParagraph = (Chapter)ParagraphPicker.SelectedItem;
                    int idParagraph = Convert.ToInt32(selectedParagraph.IdChapter);
                    string titleParagraph = Convert.ToString(selectedParagraph.TitleChapter);
                    string fileName = ChaptersController.GetChapterFile(idParagraph); // Получение названия файла из API на основе выбранного элемента
                    if (String.IsNullOrEmpty(fileName))
                    {
                        await DisplayAlert("Ошибка", "Файл параграфа не найден", "OK");
                    }
                    else
                    {
                        await Navigation.PushAsync(new ParagraphsPage(fileName, titleParagraph));
                    }
                }


            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Возникла непредвиденная ошибка.", "OK");
                throw;
            }
        }
    }
}