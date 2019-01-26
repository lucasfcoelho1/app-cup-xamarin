using MoviesCupApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MoviesCupApp.ViewModels
{
    public class CupResultViewModel : BaseViewModel
    {
        private Cup _cupResult;
        public Command BackToMoviesListCommand { get; set; }
        public Cup CupResult
        {
            get { return _cupResult; }
            set { SetProperty(ref _cupResult, value); }
        }

        public CupResultViewModel()
        {
            BackToMoviesListCommand = new Command(BackToMoviesListExecuteCommand);
        }

        private void BackToMoviesListExecuteCommand()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
