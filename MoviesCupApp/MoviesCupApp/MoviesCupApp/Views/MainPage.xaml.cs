using MoviesCupApp.Models;
using MoviesCupApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;

namespace MoviesCupApp
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel ViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();

            ViewModel = BindingContext as MainViewModel;
        }

        private void LvMovies_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var movie = ((SelectableItem<Movie>)e.Item);
            var result = ViewModel.SelectedItems?.FirstOrDefault(i => i == movie);

            if (result == null)
            {
                ViewModel.SelectedItems.Add(movie);
                ViewModel.HasSelectedItems = true;
                ViewModel.SetCounter = ViewModel.SelectedItems.Count;
            }
            else
            {
                ViewModel.SelectedItems.Remove(movie);
                ViewModel.HasSelectedItems = ViewModel.SelectedItems.Count > 0;
                ViewModel.SetCounter = ViewModel.SelectedItems.Count;
            }
        }
        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var x = (sender as MenuItem).CommandParameter as Movie;
        }
    }
}
