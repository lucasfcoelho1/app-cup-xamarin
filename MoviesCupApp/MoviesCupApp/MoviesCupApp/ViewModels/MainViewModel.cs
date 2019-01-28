using MoviesCupApp.Models;
using MoviesCupApp.Repositories.Interfaces;
using MoviesCupApp.Resources;
using MoviesCupApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;

namespace MoviesCupApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region props
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
        public bool IsListVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }

        private bool _isControlsEnabled;
        public bool IsControlsEnabled
        {
            get { return _isControlsEnabled; }
            set { SetProperty(ref _isControlsEnabled, value); }
        }

        public string Counter
        {
            get
            {
                if (SelectedItems.Count == 1)
                    return $"{SelectedItems.Count} {AppResources.SelectedMovie}";
                else
                    return $"{SelectedItems.Count} {AppResources.SelectedMovies}";
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

        private bool _hasSelectedItems;
        public bool HasSelectedItems
        {
            get { return _hasSelectedItems; }
            set { SetProperty(ref _hasSelectedItems, value); }
        }

        public IMovieRepository _movieRepository { get; set; }
        #endregion

        #region commands
        public Command SyncListCommand { get; set; }
        public Command StartCupCommand { get; set; }
        public MultiSelectObservableCollection<Movie> MoviesList { get; set; }
        public MultiSelectObservableCollection<Movie> SelectedItems { get; set; }
        #endregion

        public MainViewModel(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
            var r = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            IsCenterTextVisible = true;
            IsListVisible = false;
            ToggleIsBusy(isBusy: false, isControlsEnabled: true);

            SyncListCommand = new Command(async () => await SyncListCommandExecuteCommand());
            StartCupCommand = new Command(async () => await StartCupExecuteCommand());
            SelectedItems = new MultiSelectObservableCollection<Movie>();
            MoviesList = new MultiSelectObservableCollection<Movie>();
        }

        #region methods
        //initiate the cup with the 8 movies
        private async Task StartCupExecuteCommand()
        {
            ToggleIsBusy(isBusy: true, isControlsEnabled: false);
            if (SelectedItems.Count != 8)
            {
                await App.Current.MainPage.DisplayAlert(AppResources.Oops, AppResources.WrongSizeMoviesList, AppResources.OK);
                ToggleIsBusy(isBusy: false, isControlsEnabled: true);
                return;
            }
            var moviesId = new string[SelectedItems.Count];
            for (int i = 0; i < SelectedItems.Count; i++)
            {
                moviesId[i] = SelectedItems[i].Data.Identifier;
            }

            var cupResult = await _movieRepository.PostAsync<Cup>(moviesId);
            if (cupResult == null)
            {
                ToggleIsBusy(isBusy: false, isControlsEnabled: true);
                return;
            }
            ToggleIsBusy(isBusy: false, isControlsEnabled: true);
            //await PushAsync<CupResultViewModel>(cupResult);
            await App.Current.MainPage.Navigation.PushAsync(new CupResultPage(cupResult));
        }

        private void ToggleIsBusy(bool isBusy, bool isControlsEnabled)
        {
            IsBusy = isBusy;
            IsControlsEnabled = isControlsEnabled;
        }

        private async Task SyncListCommandExecuteCommand()
        {
            if (MoviesList.Count > 1)
            {
                var result = await App.Current.MainPage.DisplayAlert(AppResources.Attention, AppResources.RefreshConfirmation, AppResources.OK, AppResources.Cancel);
                if (!result)
                {
                    IsBusy = false;
                    return;
                }
            }

            ToggleIsBusy(isBusy: true, isControlsEnabled: false);
            var movies = await _movieRepository.GetMoviesAsync<List<Movie>>();
            if (movies == null || movies?.Count < 1)
            {
                IsCenterTextVisible = MoviesList.Count < 1;
                IsListVisible = !IsCenterTextVisible;
                IsTopTextVisible = !IsCenterTextVisible;
                ToggleIsBusy(isBusy: false, isControlsEnabled: true);
                return;
            }
            FillMoviesList(movies);
            IsCenterTextVisible = MoviesList.Count < 1;
            IsListVisible = !IsCenterTextVisible;
            IsTopTextVisible = !IsCenterTextVisible;
            ToggleIsBusy(isBusy: false, isControlsEnabled: true);
            App.Current.MainPage.ForceLayout();
        }

        internal void FillMoviesList(IList<Movie> movies)
        {
            SelectedItems.Clear();
            MoviesList.Clear();
            HasSelectedItems = SelectedItems.Count > 0;
            SetCounter = SelectedItems.Count;
            foreach (var item in movies)
                MoviesList.Add(item);
        }

        internal void ToggleSelectedItem(ItemTappedEventArgs e)
        {
            var movie = ((SelectableItem<Movie>)e.Item);
            var result = SelectedItems?.FirstOrDefault(i => i == movie);

            if (result == null)
            {
                SelectedItems.Add(movie);
                HasSelectedItems = true;
                SetCounter = SelectedItems.Count;
            }
            else
            {
                SelectedItems.Remove(movie);
                HasSelectedItems = SelectedItems.Count > 0;
                SetCounter = SelectedItems.Count;
            }
        }
        #endregion
    }
}
