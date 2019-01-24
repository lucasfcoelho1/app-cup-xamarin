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
        private bool _counterVisibility;

        public bool CounterVisibility
        {
            get { return _counterVisibility; }
            set { SetProperty(ref _counterVisibility, value); }
        }

        private string _counter;
        public string Counter
        {
            get
            {
                if(SelectedItems.Count == 1)
                    return $"{SelectedItems.Count} Filme Selecionado";
                else
                    return $"{SelectedItems.Count} Filmes Selecionados";
            }
        }

        private int _setCounter;

        public int SetCounter
        {
            get { return _setCounter; }
            set
            {
                SetProperty(ref _setCounter, value);
                OnPropertyChanged(nameof(Counter));
            }
        }

        public MultiSelectObservableCollection<Movie> Movies { get; set; }
        public MultiSelectObservableCollection<Movie> SelectedItems { get; set; }
        private bool _hasSelectedItems;

        public bool HasSelectedItems
        {
            get { return _hasSelectedItems; }
            set { SetProperty(ref _hasSelectedItems, value); }
        }


        public MainViewModel()
        {
            SelectedItems = new MultiSelectObservableCollection<Movie>();
            Movies = new MultiSelectObservableCollection<Movie>
            {
                new Movie
                {
                    Identifier = 1,
                    Title = "Os Incríveis 2",
                    Year = 2018
                },
                new Movie
                {
                    Identifier = 2,
                    Title = "Bandersnatch",
                    Year = 2016
                },
                new Movie
                {
                    Identifier = 3,
                    Title = "Os Vingadores",
                    Year = 2008
                },
                new Movie
                {
                    Identifier = 4,
                    Title = "Lorem",
                    Year = 2009
                },new Movie
                {
                    Identifier = 5,
                    Title = "Ipsum ",
                    Year = 2010
                },new Movie
                {
                    Identifier = 6,
                    Title = "Dolor",
                    Year = 2011
                },new Movie
                {
                    Identifier = 7,
                    Title = "Sit",
                    Year = 2012
                },new Movie
                {
                    Identifier = 8,
                    Title = "Amet",
                    Year = 2013
                },new Movie
                {
                    Identifier = 9,
                    Title = "Consectetur",
                    Year = 2014
                },new Movie
                {
                    Identifier = 10,
                    Title = "Adipiscing",
                    Year = 2015
                },new Movie
                {
                    Identifier = 11,
                    Title = "Elit",
                    Year = 2016
                },new Movie
                {
                    Identifier = 12,
                    Title = "Pellentesque",
                    Year = 2017
                },
            };

        }

    }
}
