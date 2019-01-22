using MoviesCupApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms.MultiSelectListView;

namespace MoviesCupApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string myVar;

        public string MyProperty
        {
            get { return myVar; }
            set {SetProperty(ref myVar, value); }
        }

        private bool _counterVisibility;

        public bool CounterVisibility
        {
            get { return _counterVisibility; }
            set {SetProperty(ref _counterVisibility, value); }
        }


        public MultiSelectObservableCollection<Movie> Movies { get; set; }
        public MultiSelectObservableCollection<Movie> Items { get; set; }

        public MainViewModel()
        {
            MyProperty = "Oi, eu sou o Goku";
            Items = new MultiSelectObservableCollection<Movie>();
            Movies = new MultiSelectObservableCollection<Movie>
            {
                new Movie
                {
                    Title = "Os Incríveis 2",
                    Year = 2018
                },
                new Movie
                {
                    Title = "Bandersnatch",
                    Year = 2016
                },
                new Movie
                {
                    Title = "Os Vingadores",
                    Year = 2008
                },

            };
            
        }

    }
}
