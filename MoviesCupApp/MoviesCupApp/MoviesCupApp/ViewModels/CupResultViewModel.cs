using MoviesCupApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesCupApp.ViewModels
{
    public class CupResultViewModel : BaseViewModel
    {
        private Cup _cupResult;
        public Cup CupResult
        {
            get { return _cupResult; }
            set { SetProperty(ref _cupResult, value); }
        }

        public CupResultViewModel()
        {

        }

    }
}
