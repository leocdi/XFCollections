using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObservableTune.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        private List<string> _appearStrategy;
        public List<string> AppearStrategy
        {
            get { return _appearStrategy; }
            set { SetProperty(ref _appearStrategy, value); }
        }

        private string _selectedAppearStrategy;
        public string SelectedAppearStrategy
        {
            get { return _selectedAppearStrategy; }
            set { SetProperty(ref _selectedAppearStrategy, value); }
        }

        public override void Initialize(INavigationParameters parameters)
        {
            ChargerListStrategies();

            base.Initialize(parameters);
        }

        private void ChargerListStrategies()
        {
            var targetType = typeof(IAppearStrategy);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => targetType.IsAssignableFrom(p) && p.IsClass).Select(x => x.FullName).ToList();

            AppearStrategy = types;
            SelectedAppearStrategy = AppearStrategy.FirstOrDefault();
        }
    }
}
