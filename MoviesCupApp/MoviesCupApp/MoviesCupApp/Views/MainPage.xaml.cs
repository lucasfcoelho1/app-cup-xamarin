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
        #region props
        public MainViewModel ViewModel { get; set; } 
        #endregion

        public MainPage()
        {
            InitializeComponent();

            ViewModel = BindingContext as MainViewModel;
        }

        #region methods
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel.SelectedItems != null && ViewModel.SelectedItems?.Count > 1)
            {
                //turning a MultiSelectObservableCollection<Movie> into a List<Movie>
                var list = (from item in ViewModel.MoviesList select item.Data).ToList();
                ViewModel.FillMoviesList(list);
            }
        }

        private void LvMovies_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.ToggleSelectedItem(e);
        }
        #endregion

    }
}
