﻿using System;
using Autofac;

namespace CommandDotNet.IoC.Autofac
{
    public class AutofacResolver : IDependencyResolver
    {
        private readonly IContainer _container;

        public AutofacResolver(IContainer container)
        {
            _container = container;
        }
        
        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}