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
            var result = ViewModel.Items?.FirstOrDefault(i => i == movie);

            if (result == null)
                ViewModel.Items.Add(movie);
            else
                ViewModel.Items.Remove(movie);


            //foreach (var item in ViewModel.Movies)
            //{
            //    if (!item.Equals(movie))
            //        ViewModel.Items.Add(item.Data);
            //    else
            //        ViewModel.Items.Remove(item.Data);
            //}
        }

        //private void MenuItem_Clicked(object sender, EventArgs e)
        //{
        //    var menuItem = sender as MenuItem;
        //    var movie = menuItem.CommandParameter as Movie;
        //    DisplayAlert("Movie : ", movie.Title, "Ok");
        //}

        //private void MenuItem_Deletar(object sender, EventArgs e)
        //{
        //    var movie = (sender as MenuItem).CommandParameter as Movie;
        //    ViewModel.Movies.Remove(movie);
        //}

        //private void LvMovies_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var menuItem = sender as MenuItem;
        //    var movie = menuItem.CommandParameter as Movie;
        //    DisplayAlert("Movie : ", movie.Title, "Ok");
        //}


    }
}
