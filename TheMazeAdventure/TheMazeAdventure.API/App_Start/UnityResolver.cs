using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;

namespace TheMazeAdventure.API
{
    public sealed class UnityResolver : IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public UnityResolver(IUnityContainer container)
        {
            this._container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (ResolutionFailedException exception)
            {
                throw new InvalidOperationException(
                    $"Unable to resolve service for type {serviceType}.",
                    exception);
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException exception)
            {
                throw new InvalidOperationException(
                    $"Unable to resolve service for type {serviceType}.",
                    exception);
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = _container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            _container.Dispose();
        }
    }
}

