using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyIoC.Interfaces;
using MyIoC.Services;

namespace MyIoC.Tests
{
    [TestClass]
    public class IoCBasicTests
    {
        [TestMethod]
        public void ResolveInstance_No_Ctor()
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
            container.Register<IStoresService>().Using<StoreService>();



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
            //assert result is not null
            Assert.IsNotNull(storeService);

            //assert result is of expected type
            Assert.IsInstanceOfType(storeService, typeof(IStoresService));
            Assert.IsInstanceOfType(storeService, typeof(StoreService));

            //assert data is accessible
            Assert.IsNotNull(storeService.GetStore(1));
            Assert.IsNotNull(storeService.GetStores());            

        }
    }
}
