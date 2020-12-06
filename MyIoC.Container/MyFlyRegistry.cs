using System;
using System.Collections.Generic;

//The Registry:
//  Is a lazy singleton.
//  SHOULD NOT be accessible outside of this project.  It's safer this way.
//  SHOULD handle all "CRUD" operations.
//  SHOULD determine if types are registered.


//things I'd like to do
//  allow for multiple values to support the idea that multiple classes can implement the same interface
//  allow support to store types that have already been resolved so we don't have to resolve them again
//  add support to allow the user to tell us if they want to resolve a fresh instance every time the instantiation is resolved

namespace MyIoC.Registry
{
    internal sealed class MyFlyRegistry : Dictionary<Type, Type>
    {

        private static Lazy<MyFlyRegistry> registryInstance = new Lazy<MyFlyRegistry>(() => new MyFlyRegistry(), true); 

        private MyFlyRegistry() : base() { }

        public static MyFlyRegistry Instance
        {
            get => registryInstance.Value;
        }

        public bool IsRegistered(Type pRegisteredType)
        {
            if(pRegisteredType == null)
            {
                return false;
            }

            Instance.TryGetValue(pRegisteredType, out Type type);

            if(type == null)
            {

                Instance.Remove(pRegisteredType);

                return false;
            }

            return true;
        }

        public bool IsRegistered(Type pRegisteredType, out Type pResolvesTo)
        {
            pResolvesTo = null;

            if(pRegisteredType == null)
            {
                return false;
            }

            Instance.TryGetValue(pRegisteredType, out Type type);

            if (type == null)
            {

                Instance.Remove(pRegisteredType);

                return false;
            }

            pResolvesTo = type;

            return true;
        }

        public new void Add(Type pRegisterType, Type pResolvesTo)
        {
            if(IsRegistered(pRegisterType))
            {
                return;
            }

            if(pResolvesTo == null)
            {
                throw new ArgumentNullException(nameof(pResolvesTo));
            }

            base.Add(pRegisterType, pResolvesTo);
        }

    }
}
