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
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ObservableTune.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible, IPageLifecycleAware
    {
        protected INavigationService NavigationService { get; private set; }
        protected IAppearStrategy appearStrategy;
        private Chronometre appearingMeasure;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _time;
        public string Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }

        protected List<Customer> _cutomers;

        private ObservableCollection<Customer> _items;
        public ObservableCollection<Customer> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
            _cutomers = new Generator().GetCustomers().ToList();
            Items = new ObservableCollection<Customer>();
        }

        public virtual void Initialize(INavigationParameters parameters)
        {
            if (this is IUseAppearStrategy && parameters.TryGetValue(KnownNavigationParameters.XamlParam, out string strat))
            {
                appearStrategy = AppearStrategyFactory.Create(strat);
            }
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        public void OnAppearing()
        {
            if (!(this is IUseAppearStrategy vm)) return;


            appearingMeasure = Utils.CreateCronometer();
            appearStrategy.Appear(_cutomers, Items, Done);
        }



        private void Done()
        {
            Time = appearingMeasure.TimeToString();
        }

        public void OnDisappearing()
        {

        }
    }
}
