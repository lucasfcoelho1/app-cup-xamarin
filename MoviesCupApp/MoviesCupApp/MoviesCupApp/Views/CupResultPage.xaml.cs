using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesCupApp.Models;
using MoviesCupApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesCupApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CupResultPage : ContentPage
	{
        public CupResultViewModel ViewModel { get; set; }
        public CupResultPage (Cup cupResult)
		{
			InitializeComponent ();

            ViewModel = BindingContext as CupResultViewModel;
            ViewModel.CupResult = cupResult;
		}
    }
}