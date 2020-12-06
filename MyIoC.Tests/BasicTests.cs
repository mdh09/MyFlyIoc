using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyIoC.Container;
using MyIoC.Services;
using MyIoC.Interfaces;

namespace MyIoC.Tests
{
    [TestClass]
    public class IoCBasicTests
    {

        [TestMethod]
        public void ContainerCreation()
        {
            //verifying container still constructed without issues after splitting registry from container
            Console.WriteLine("*********** Timer CONTAINER CREATE Start ***********");
            var timer = Stopwatch.StartNew();



            //arrange
            var container = new FlyIoCContainer();



            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            Console.WriteLine("*********** Timer CONTAINER CREATE Stop ***********");

            //assert container is not null
            Assert.IsNotNull(container);

        }

        [TestMethod]
        public void TypeRegistration_ResolvesToHasNoCtor()
        {
            Console.WriteLine("*********** Timer CONTAINER CREATE Start ***********");
            var timer = Stopwatch.StartNew();



            //arrange
            var container = new FlyIoCContainer();



            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            Console.WriteLine("*********** Timer CONTAINER CREATE Stop ***********");
            timer.Reset();
            Console.WriteLine("*********** Timer REGISTER Start ***********");
            timer.Start();



            //somehow give container interface and class
            container.Register<IStoresService, StoreService>();


            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            Console.WriteLine("*********** Timer REGISTER Stop ***********");

            //assert container is not null
            Assert.IsNotNull(container);

            //assert container contains 1 registered type
            Assert.IsTrue(container.CountOfRegisteredTypes() == 1);

        }

        [TestMethod]
        public void ResolveInstance_ResolvesToHasNoCtor()
        {

            Console.WriteLine("*********** Timer CONTAINER CREATE Start ***********");
            var timer = Stopwatch.StartNew();



            //arrange
            var container = new FlyIoCContainer();



            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            Console.WriteLine("*********** Timer CONTAINER CREATE Stop ***********");
            timer.Reset();
            Console.WriteLine("*********** Timer REGISTER Start ***********");
            timer.Start();



            //somehow give container interface and class
            container.Register<IStoresService, StoreService>();


            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            Console.WriteLine("*********** Timer REGISTER Stop ***********");
            timer.Reset();
            Console.WriteLine("*********** Timer Resolve Start ***********");
            timer.Start();



            //action
            //container resolve instance of desired class
            var storeService = container.ResolveSingleton<IStoresService>();



            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            Console.WriteLine("*********** Timer Resolve Stop ***********");
            var frequency = Stopwatch.Frequency;
            Console.WriteLine("  Timer frequency in ticks per second = {0}",
                frequency);
            var nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
            Console.WriteLine("  Timer is accurate within {0} nanoseconds",
                nanosecPerTick);

            //assert

            //assert container is not null
            Assert.IsNotNull(container);

            //assert container contains 1 registered type
            Assert.IsTrue(container.CountOfRegisteredTypes() == 1);

            //assert result is not null
            Assert.IsNotNull(storeService);

            //assert result is of expected type
            Assert.IsInstanceOfType(storeService, typeof(IStoresService));
            Assert.IsInstanceOfType(storeService, typeof(StoreService));

            //assert data is accessible
            Assert.IsNotNull(storeService.GetStore(1));
            Assert.IsNotNull(storeService.GetStores());

        }

        [TestMethod]
        public void ResolveSameInstanceMultipleTimes_ResolvesToHasNoCtor()
        {

            Console.WriteLine("*********** Timer CONTAINER CREATE Start ***********");
            var timer = Stopwatch.StartNew();



            //arrange
            var container = new FlyIoCContainer();



            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            Console.WriteLine("*********** Timer CONTAINER CREATE Stop ***********");
            timer.Reset();
            Console.WriteLine("*********** Timer REGISTER Start ***********");
            timer.Start();



            //somehow give container interface and class
            container.Register<IStoresService, StoreService>();


            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            Console.WriteLine("*********** Timer REGISTER Stop ***********");
            timer.Reset();
            Console.WriteLine("*********** Timer 1 Resolve Start ***********");
            timer.Start();



            //action
            //container resolve instance of desired class
            var storeService = container.ResolveSingleton<IStoresService>();



            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            Console.WriteLine("*********** Timer 1 Resolve Stop ***********");
            timer.Reset();
            Console.WriteLine("*********** Timer 2 Resolve Start ***********");
            timer.Start();



            //action
            //container resolve same instance of desired class to different variable
            var storeService2 = container.ResolveSingleton<IStoresService>();



            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            Console.WriteLine("*********** Timer 2 Resolve Stop ***********");
            var frequency = Stopwatch.Frequency;
            Console.WriteLine("  Timer frequency in ticks per second = {0}",
                frequency);
            var nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
            Console.WriteLine("  Timer is accurate within {0} nanoseconds",
                nanosecPerTick);

            //assert

            //assert container is not null
            Assert.IsNotNull(container);

            //assert container contains 1 registered type
            Assert.IsTrue(container.CountOfRegisteredTypes() == 1);

            //assert result is not null
            Assert.IsNotNull(storeService);

            //assert result is of expected type
            Assert.IsInstanceOfType(storeService, typeof(IStoresService));
            Assert.IsInstanceOfType(storeService, typeof(StoreService));

            //assert that multiple resolves resolve the same instance
            Assert.ReferenceEquals(storeService, storeService2);

            //assert 1st data is accessible
            Assert.IsNotNull(storeService.GetStore(1));
            Assert.IsNotNull(storeService.GetStores());

            //assert 2nd data is accessible
            Assert.IsNotNull(storeService2.GetStore(1));
            Assert.IsNotNull(storeService2.GetStores());

        }
    }
}
