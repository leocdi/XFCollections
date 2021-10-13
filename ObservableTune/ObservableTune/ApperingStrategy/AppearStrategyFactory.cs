using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ObservableTune
{
    public static class AppearStrategyFactory
    {
        public static IAppearStrategy Create(string strategy){

            IAppearStrategy strat = (IAppearStrategy)Assembly.GetAssembly(typeof(IAppearStrategy)).CreateInstance(strategy, false, BindingFlags.CreateInstance, null, null, null, null);
            return strat;
        }
    }
}
