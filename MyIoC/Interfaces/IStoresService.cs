using System.Collections.Generic;

namespace MyIoC.Interfaces
{
    public interface IStoresService
    {

        List<IStore> GetStores();
        IStore GetStore(int pStoreId);

    }

    public interface IStore
    {
        int StoreID { get; }
        string StoreName { get; }
        string PhoneNumber { get; }
        string EmergencyPhoneNumber { get; }
        string OperationHours { get; }
        string Address { get; }
    }

}
