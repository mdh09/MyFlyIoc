using MyIoC.Interfaces;

namespace MyIoC.DomainModels
{
    public class StoreDetails : IStore
    {
        public StoreDetails(string pPhoneNumber, string pEmergencyPhoneNumber, string pOperationHours, string pAddress, int pStoreId, string pStoreName)
        {

            PhoneNumber = pPhoneNumber;
            EmergencyPhoneNumber = pEmergencyPhoneNumber;
            OperationHours = pOperationHours;
            Address = pAddress;
            StoreID = pStoreId;
            StoreName = pStoreName;

        }

        public string PhoneNumber { get; }

        public string EmergencyPhoneNumber { get; }

        public string OperationHours { get; }

        public string Address { get; }

        public int StoreID { get; }

        public string StoreName { get; }
    }
}
