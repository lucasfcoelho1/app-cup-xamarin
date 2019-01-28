using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoviesCupApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        //public async Task PushAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        //{
        //    var viewModelType = typeof(TViewModel);

        //    var viewModelTypeName = viewModelType.Name;
        //    var viewModelWordLenght = "ViewModel".Length;
        //    var viewTypeName = $"MoviesCupApp.Views.{viewModelTypeName.Substring(0, viewModelTypeName.Length - viewModelWordLenght)}Page";
        //    var viewType = Type.GetType(viewTypeName);

        //    var page = Activator.CreateInstance(viewType) as Page;

        //    var viewModel = Activator.CreateInstance(viewModelType, args);
        //    if (page != null)
        //    {
        //        page.BindingContext = viewModel;
        //    }

        //    await Application.Current.MainPage.Navigation.PushAsync(page);
        //}

    }
}
