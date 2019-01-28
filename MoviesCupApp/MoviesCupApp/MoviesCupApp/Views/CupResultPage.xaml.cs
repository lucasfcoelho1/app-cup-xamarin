using MoviesCupApp.Models;
using MoviesCupApp.Resources;
using MoviesCupApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesCupApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CupResultPage : ContentPage
    {
        public CupResultViewModel ViewModel { get; set; }

        public CupResultPage(Cup cupResult)
        {
            InitializeComponent();

            ViewModel = BindingContext as CupResultViewModel;
            ViewModel.CupResult = cupResult;

            Title = AppResources.CupResult;
            lblRunnerUp.Text = AppResources.RunnerUp;
            lblWinner.Text = AppResources.Winner;
            lblStartAgain.Text = AppResources.StartAgain;
        }
    }
}