﻿using Autofac;

namespace CommandDotNet.IoC.Autofac
{
    public static class Extension
    {
        public static AppRunner<T> UseAutofac<T>(this AppRunner<T> appRunner, IContainer container) where T :class
        {
            appRunner.UseDependencyResolver(new AutofacResolver(container));
            return appRunner;
        }
    }
}