using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public enum eVehicleStatus
    {
        InRepair,
        Repaired,
        Piad
    }

    public class VehicleStatusInfo
    {
        private string m_LicenseNumber;
        private string m_VehicleOwnerName;
        private string m_VehicleOwnerPhone;
        private Vehicle m_Vehicle;
        private eVehicleStatus m_VehicleStatus;
        private eVehicleType m_VehicleType;

        // Getter / Setter
        public eVehicleType vehicleType
        {
            get { return m_VehicleType; }
            set { m_VehicleType = value; }
        }

        // Getter / Setter
        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }

        // Getter / Setter
        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        // Getter / Setter
        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        // Constructor 
        public VehicleStatusInfo(string i_VehicleLicenseNumber, string i_VehicleOwnerName, string i_VehicleOwnerPhone, Vehicle i_Vehicle)
        {
            m_LicenseNumber = i_VehicleLicenseNumber;
            m_VehicleOwnerName = i_VehicleOwnerName;
            m_VehicleOwnerPhone = i_VehicleOwnerPhone;
            m_VehicleStatus = eVehicleStatus.InRepair;
            m_Vehicle = i_Vehicle;
    }
        
        // Owner Name gette/setter
        public string VehicleOwnerName
        {
            get { return m_VehicleOwnerName; }
            set { m_VehicleOwnerName = value; }
        }

        // Getter / Setter
        public string VehicleOwnerPhone
        {
            get { return m_VehicleOwnerPhone; }
            set { m_VehicleOwnerPhone = value; }
        }
    }
}
