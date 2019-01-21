using System;
using System.Collections.Generic;
using System.Text;

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

        public MainViewModel()
        {
            MyProperty = "Oi, eu sou o Goku";
        }

    }
}
