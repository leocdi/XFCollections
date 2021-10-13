using ObservableTune.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ObservableTune
{
    public class LoopInvoke : IAppearStrategy
    {
        public void Appear(IList<Customer> sampleData, IList<Customer> uiList, Action done)
        {
            _ = Task.Run(() =>
            {
                foreach (Customer item in sampleData)
                {
                    foreach (Order order in item.Orders)
                    {
                        _ = Device.InvokeOnMainThreadAsync(() => item.OrdersObs.Add(order));
                    }

                    _ = Device.InvokeOnMainThreadAsync(() => uiList.Add(item));
                }

                done?.Invoke();
            });
        }
    }

    public class SingleInvoke : IAppearStrategy
    {
        public void Appear(IList<Customer> sampleData, IList<Customer> uiList, Action done)
        {
            _ = Device.InvokeOnMainThreadAsync(() =>
            {
                foreach (Customer item in sampleData)
                {
                    foreach (Order order in item.Orders)
                    {
                        item.OrdersObs.Add(order);
                    }
                    uiList.Add(item);
                }

                done?.Invoke();
            });
        }
    }

    public class SingleAwaitInvoke : IAppearStrategy
    {
        public void Appear(IList<Customer> sampleData, IList<Customer> uiList, Action done)
        {
            Task.Run(async () =>
            {
                await Device.InvokeOnMainThreadAsync(() =>
                {
                    foreach (Customer item in sampleData)
                    {
                        foreach (Order order in item.Orders)
                        {
                            item.OrdersObs.Add(order);
                        }
                        uiList.Add(item);
                    }

                    done?.Invoke();
                });
            });
        }
    }
}
