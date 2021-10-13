using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ObservableTune.ViewModels
{
    public class ObsListComplexUiPageViewModel : ViewModelBase, IUseAppearStrategy
    {
        public ObsListComplexUiPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
