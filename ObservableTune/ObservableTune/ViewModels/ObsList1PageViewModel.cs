using ObservableTune.Models;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace ObservableTune.ViewModels
{
    public class ObsList1PageViewModel : ViewModelBase, IUseAppearStrategy
    {
        public ObsList1PageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }



        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
        }


    }
}
