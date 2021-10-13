using ObservableTune.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObservableTune
{
    public interface IAppearStrategy
    {
        void Appear(IList<Customer> sampleData, IList<Customer> uiList, Action done);
    }
}
