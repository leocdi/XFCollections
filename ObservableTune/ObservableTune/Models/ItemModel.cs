using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObservableTune.Models
{
    public class ItemModel : BindableBase
    {

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set { SetProperty(ref _nom, value); }
        }

        private string _prenom;
        public string Prenom
        {
            get { return _prenom; }
            set { SetProperty(ref _prenom, value); }
        }
    }
}
