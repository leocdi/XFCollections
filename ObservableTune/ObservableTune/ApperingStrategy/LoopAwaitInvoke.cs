using ObservableTune.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ObservableTune
{
    public class LoopAwaitInvoke : IAppearStrategy
    {
        public void Appear(IList<Customer> sampleData, IList<Customer> uiList, Action done)
        {
            _ = Task.Run(async () =>
            {
                foreach (Customer item in sampleData)
                {
                    foreach (Order order in item.Orders)
                    {
                        await Device.InvokeOnMainThreadAsync(() => item.OrdersObs.Add(order));
                    }
                    await Device.InvokeOnMainThreadAsync(() => uiList.Add(item));
                }

                done?.Invoke();
            });
        }
    }
}
