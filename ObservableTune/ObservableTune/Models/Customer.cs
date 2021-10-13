using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ObservableTune.Models
{
    public class Customer : BindableBase
    {
        public Customer()
        {
            OrdersObs = new ObservableCollection<Order>();
        }

        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }

        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode, value); }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _contactName;
        public string ContactName
        {
            get { return _contactName; }
            set { SetProperty(ref _contactName, value); }
        }
        //public Guid Id { get; set; }
        //public string Name { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string Country { get; set; }
        // public string ZipCode { get; set; }
        //public string Phone { get; set; }
        //public string Email { get; set; }
        //public string ContactName { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        private ObservableCollection<Order> _ordersObs;
        public ObservableCollection<Order> OrdersObs
        {
            get { return _ordersObs; }
            set { SetProperty(ref _ordersObs, value); }
        }
    }
}
