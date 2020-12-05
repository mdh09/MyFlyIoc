using System;
using System.Collections.Generic;

//FlyIoCContainer uses the FluentAPI pattern

namespace MyIoC
{
    public class FlyIoCContainer
    {

        Dictionary<Type, Type> registry = new Dictionary<Type, Type>();

        public FlyIoCContainerBuilder Register<TRegisterType>()
        {
            return Register(typeof(TRegisterType));
        }

        public FlyIoCContainerBuilder Register(Type pSourceType)
        {
            return new FlyIoCContainerBuilder(this, pSourceType);
        }


        public TRegisteredType ResolveSingleton<TRegisteredType>()
        {
            return (TRegisteredType)ResolveSingleton(typeof(TRegisteredType));
        }

        public object ResolveSingleton(Type pRegisteredType)
        {

            Type resolvesTo;
            object resolved = null;

            if(registry.TryGetValue(pRegisteredType, out resolvesTo))
            {
                resolved = Activator.CreateInstance(resolvesTo);
            }

            if(resolved == null)
            {
                throw new ArgumentOutOfRangeException(pRegisteredType.FullName, "Unable to resolve " + pRegisteredType.FullName);
            }

            return resolved;
            
        }

        public class FlyIoCContainerBuilder
        {
            private FlyIoCContainer flyIoCContainer;
            private Type source;

            public FlyIoCContainerBuilder(FlyIoCContainer pFlyIoCContainer, Type pSource)
            {
                flyIoCContainer = pFlyIoCContainer;
                source = pSource;
            }

            public FlyIoCContainerBuilder Using<TResolvesTo>()
            {
                return Using(typeof(TResolvesTo));
            }

            public FlyIoCContainerBuilder Using(Type pResolvesTo)
            {
                flyIoCContainer.registry.Add(source, pResolvesTo);
                return this;
            }
        }

    }
}
