using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public enum eService
    {
        AddVehical,
        PrintVehicalList,
        UpdateVehicleStatus,
        FillAirInWheels,
        FuelUpTank,
        ChargeUpBattery,
        PrintVehicleInfo,
        Done
    }

    public class Service
    {
        private string m_ServiceString;
        private eService m_eService;

        // Constructor of object Service
        public Service(string i_ServiceOffered, eService i_Service)
        {
            m_ServiceString = i_ServiceOffered;
            m_eService = i_Service;
        }

        public string ServiceString
        {
            get { return m_ServiceString; }
            set { m_ServiceString = value; }
        }

        public eService enumService
        {
            get { return m_eService; }
            set { m_eService = value; }
        }
    }
}
