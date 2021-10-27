using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ObservableTune.ViewModels
{
    public class Case3BPageViewModel : ViewModelBase, IUseAppearStrategy
    {
        public Case3BPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
