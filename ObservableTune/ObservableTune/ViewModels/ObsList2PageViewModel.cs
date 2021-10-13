using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ObservableTune.ViewModels
{
    public class ObsList2PageViewModel : ViewModelBase, IUseAppearStrategy
    {
        public ObsList2PageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

    }
}
