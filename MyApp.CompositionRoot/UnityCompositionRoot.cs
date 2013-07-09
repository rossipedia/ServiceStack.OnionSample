using System;
using System.Collections.Generic;
using Funq;
using Microsoft.Practices.Unity;
using MyApp.DomainServices;
using ServiceStack.Configuration;

namespace MyApp.CompositionRoot
{
    public class UnityCompositionRoot : ICompositionRoot
    {
        public void Compose(Container container)
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<IPersonRepository, PersonRepository>();

            unityContainer.AddNewExtension<ModelExtension.UnityExtensionWithTypeTracking>();
            container.Adapter = new UnityContainerAdapter(unityContainer);
        }
    }

    public class UnityContainerAdapter : IContainerAdapter
    {
        private readonly UnityContainer _container;

        public UnityContainerAdapter(UnityContainer container)
        {
            _container = container;
        }

        public T TryResolve<T>()
        {
            return _container.CanResolve<T>() ? _container.Resolve<T>() : default(T);
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }

    // CanResolve<T> from here: http://unity.codeplex.com/discussions/24543#post86640
    public static class ModelExtension
    {
        public class UnityExtensionWithTypeTracking : UnityContainerExtension
        {
            internal readonly HashSet<Type> RegisteredTypes = new HashSet<Type>();

            protected override void Initialize()
            {
                Context.RegisteringInstance += (sender, e) => RegisteredTypes.Add(e.RegisteredType);
                Context.Registering += (sender, e) => RegisteredTypes.Add(e.TypeFrom);
            }

        }

        public static bool CanResolve<T>(this UnityContainer container)
        {
            return container.Configure<UnityExtensionWithTypeTracking>().RegisteredTypes.Contains(typeof(T));
        }
    }
}