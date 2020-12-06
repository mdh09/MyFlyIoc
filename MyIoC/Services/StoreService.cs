using System.Collections.Generic;
using System.Linq;
using MyIoC.DomainModels;
using MyIoC.Extensions;
using MyIoC.Interfaces;

namespace MyIoC.Services
{
    public class StoreService : IStoresService
    {

        private List<IStore> stores;

        public IStore GetStore(int pStoreId)
        {
            var lstStores = GetStores();
            return lstStores.FirstOrDefault(x => x.StoreID == pStoreId);
        }

        public List<IStore> GetStores()
        {
            if(!stores.SafeAny())
            {
                stores = new List<IStore>() {
                    new StoreDetails("999-999-9999", "111-111-1111","8 am - 5 am", "Some Place, Tx 79321", 1, "Store Services"),
                    new StoreDetails("888-888-8888", "222-222-2222","8 am - 5 am", "Some Other Place, Tx 79326", 2, "Tyler"),
                    new StoreDetails("777-777-7777", "333-333-3333","8 am - 5 am", "Yet Another Place, Tx 79327", 3 , "Silver"),
                    new StoreDetails("666-666-6666", "444-444-4444","8 am - 5 am", "Another Place, Tx 79328", 4, "Tuel")
                };
            }

            return stores;
        }
    }
}
