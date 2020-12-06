using System;
using MyIoC.Registry;

//after comparing the SPEED of my interpretation of how Prism registers services to my initial attempt, the PRO (Prism RipOff) was notably faster.

//The container can essentially be thought of as a registry manager.  An instance of the registry SHOULD NOT be accessible outside of this project.  Any communication with the instance of the registry should be handled by the container.

//Container is in charge of
//  Referencing the registry so the registry can be hidden away
//  Registering the Registered and Resolves types with the instance of the registry
//  Creating instances of the ResolvesTo type
//  Resolving created instances of the ResolvesTo

namespace MyIoC.Container
{
    public class FlyIoCContainer
    {

        public void Register<TRegisterType, TResolvesTo>()
        {
            Register(typeof(TRegisterType), typeof(TResolvesTo));
        }

        public void Register(Type pRegisterType, Type pResolvesTo)
        {
            MyFlyRegistry.Instance.Add(pRegisterType, pResolvesTo);
        }

        public TRegisteredType ResolveSingleton<TRegisteredType>()
        {
            return (TRegisteredType)ResolveSingleton(typeof(TRegisteredType));
        }

        public object ResolveSingleton(Type pRegisteredType)
        {

            Type resolvesTo;
            object resolved = null;

            if (MyFlyRegistry.Instance.IsRegistered(pRegisteredType, out resolvesTo))
            {
                resolved = Activator.CreateInstance(resolvesTo);
            }

            if (resolved == null)
            {
                throw new ArgumentOutOfRangeException(pRegisteredType.FullName, "Unable to resolve " + pRegisteredType.FullName);
            }

            return resolved;

        }

        public int CountOfRegisteredTypes()
        {
            return MyFlyRegistry.Instance.Count;
        }

    }

}
