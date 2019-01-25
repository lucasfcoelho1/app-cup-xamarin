using MoviesCupApp.Models;
using MoviesCupApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;

namespace MoviesCupApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public const string REFRESH_LIST = "REFRESH_LIST";

        private bool _counterVisibility;
        public bool CounterVisibility
        {
            get { return _counterVisibility; }
            set { SetProperty(ref _counterVisibility, value); }
        }

        private bool _isTopTextVisible;

        public bool IsTopTextVisible
        {
            get { return _isTopTextVisible; }
            set { SetProperty(ref _isTopTextVisible, value); }
        }


        private bool _isCenterTextVisible;

        public bool IsCenterTextVisible
        {
            get { return _isCenterTextVisible; }
            set { SetProperty(ref _isCenterTextVisible, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private bool _isVisible;

        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }

        public string Counter
        {
            get
            {
                if (SelectedItems.Count == 1)
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

        public Command SyncListCommand { get; set; }
        public Command StartCupCommand { get; set; }
        public MultiSelectObservableCollection<Movie> MoviesList { get; set; }
        public MultiSelectObservableCollection<Movie> SelectedItems { get; set; }
        private bool _hasSelectedItems;

        public bool HasSelectedItems
        {
            get { return _hasSelectedItems; }
            set { SetProperty(ref _hasSelectedItems, value); }
        }

        public IMovieRepository _movieRepository { get; set; }

        public MainViewModel(IMovieRepository movieRepository)
        {
            IsCenterTextVisible = true;
            IsVisible = false;
            IsBusy = false;
            _movieRepository = movieRepository;
            SyncListCommand = new Command(async () => await SyncListCommandExecuteCommand());
            //SyncListCommand = new Command(SyncListCommandExecuteCommand);
            StartCupCommand = new Command(StartCupExecuteCommand);
            SelectedItems = new MultiSelectObservableCollection<Movie>();

            MessagingCenter.Subscribe<MainViewModel>(this, REFRESH_LIST, async (sender) =>
            {
                await SyncListCommandExecuteCommand();
                //SyncListCommandExecuteCommand();
            });

            MoviesList = new MultiSelectObservableCollection<Movie>();

        }

        private void NewMethod()
        {
            MoviesList = new MultiSelectObservableCollection<Movie>
            {
                new Movie
                {
                    Identifier = "1",
                    Title = "Os Incríveis 2",
                    Year = 2018
                },
                new Movie
                {
                    Identifier = "2",
                    Title = "Bandersnatch",
                    Year = 2016
                },
                new Movie
                {
                    Identifier = "3",
                    Title = "Os Vingadores",
                    Year = 2008
                },
                new Movie
                {
                    Identifier = "4",
                    Title = "Lorem",
                    Year = 2009
                },new Movie
                {
                    Identifier = "5",
                    Title = "Ipsum ",
                    Year = 2010
                },new Movie
                {
                    Identifier = "6",
                    Title = "Dolor",
                    Year = 2011
                },new Movie
                {
                    Identifier = "7",
                    Title = "Sit",
                    Year = 2012
                },new Movie
                {
                    Identifier = "8",
                    Title = "Amet",
                    Year = 2013
                },new Movie
                {
                    Identifier = "9",
                    Title = "Consectetur",
                    Year = 2014
                },new Movie
                {
                    Identifier = "10",
                    Title = "Adipiscing",
                    Year = 2015
                },new Movie
                {
                    Identifier = "11",
                    Title = "Elit",
                    Year = 2016
                },new Movie
                {
                    Identifier = "12",
                    Title = "Pellentesque",
                    Year = 2017
                },
            };
        }

        private void StartCupExecuteCommand(object obj)
        {
            if (SelectedItems.Count != 8)
            {
                App.Current.MainPage.DisplayAlert("Atenção", "Necessário escolher 8 times para começar a copa", "OK");
            }
        }

        async Task SyncListCommandExecuteCommand()
        {
            IsBusy = true;
            IsVisible = true;
            FillMoviesList(await _movieRepository.GetMovies());
            IsCenterTextVisible = MoviesList.Count < 1;
            IsVisible = !IsCenterTextVisible;
            IsTopTextVisible = !IsCenterTextVisible;
            IsBusy = false;
            App.Current.MainPage.ForceLayout();
        }

        void FillMoviesList(List<Movie> movies)
        {
            MoviesList.Clear();
            foreach (var item in movies)
            {
                MoviesList.Add(item);
            }
        }
    }
}
