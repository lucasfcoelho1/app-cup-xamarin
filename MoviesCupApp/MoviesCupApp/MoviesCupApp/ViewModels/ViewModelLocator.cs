using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesCupApp.ViewModels
{
    public class ViewModelLocator
    {
        private UnityContainer _unityContainer;

        public MainViewModel MainViewModel
        {
            get { return _unityContainer.Resolve<MainViewModel>(); }
        }

        public ViewModelLocator()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager());

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(_unityContainer));
        }
    }
}
