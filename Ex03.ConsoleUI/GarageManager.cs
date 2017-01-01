using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        private List<VehicleStatusInfo> m_VehiclesList;
        private int m_NumberOfVehicles;
        public List<Service> m_ServiceList;
        
        // Set/get method to the service list field
        public List<Service> ServiceList
        {
            get { return m_ServiceList; }
            set { m_ServiceList = value; }
        }

        // Set/get method to the vehicle list field
        public List<VehicleStatusInfo> VehicleList
        {
            get { return m_VehiclesList; }
            set { m_VehiclesList = value; }
        }

        // Constructor default.
        public GarageManager()
        {
            m_VehiclesList = new List<VehicleStatusInfo>();
            m_NumberOfVehicles = 0;
            m_ServiceList = new List<Service>();
            m_ServiceList.Add(new Service("Enter a new car for repairing in the garage.", eService.AddVehical));
            m_ServiceList.Add(new Service("Print vehicle List in the Garage.", eService.PrintVehicalList));
            m_ServiceList.Add(new Service("Update vehicle status in the garage.", eService.UpdateVehicleStatus));
            m_ServiceList.Add(new Service("Fill air in the Vehicle wheels.", eService.FillAirInWheels));
            m_ServiceList.Add(new Service("Fuel up vehicle feul tank.", eService.FuelUpTank));
            m_ServiceList.Add(new Service("Charge up vehicle battery.", eService.ChargeUpBattery));
            m_ServiceList.Add(new Service("Print vehicle full info and status.", eService.PrintVehicleInfo));
        }
        
        // Constuctor with custome services
        public GarageManager(List<Service> i_ServiceList)
        {
            m_VehiclesList = new List<VehicleStatusInfo>();
            m_NumberOfVehicles = 0;
            m_ServiceList = i_ServiceList;
        }

        // Check if a vehicle with a given license number is in the garage
        public bool IsInGarage(string i_LicenseNumbe)
        {
            bool inGarage = false;
            if (IndexOfVehicle(i_LicenseNumbe) != -1)
            {
                inGarage = true;
            }

            return inGarage;
        }

        // (1) To add new vehicle to the garage and to check if he allready inside.
        public void AddVehicle(string i_LicenseNumber, string i_VehicleOwnerName, string i_VehicleOwnerPhone, Vehicle i_Vehicle)
        {
                VehicleStatusInfo newVehicle = new VehicleStatusInfo(i_LicenseNumber, i_VehicleOwnerName, i_LicenseNumber, i_Vehicle);
                m_VehiclesList.Add(newVehicle);
                m_NumberOfVehicles++;
        }
        
        // (2) Present list of vehicles in the garage
        public void PrintVehicleList()
        {
            Console.WriteLine("List of Vehicles in the garage:");
            int counter = 1;
            foreach (VehicleStatusInfo vehicleStatusInfo in m_VehiclesList)
            {
                Console.WriteLine(counter + ". " + vehicleStatusInfo.LicenseNumber);
                counter++;
            }
        }

        // (2) Present filtered list of vehicles in the garage status.
        public void PrintFilteredVehicleList(eVehicleStatus i_VehicleStatus)
        {
            Console.WriteLine("List of Vehicles in the garage filtered by the status: " + i_VehicleStatus);
            int counter = 1;
            foreach (VehicleStatusInfo vehicleStatusInfo in m_VehiclesList)
            {
                if (vehicleStatusInfo.VehicleStatus == i_VehicleStatus)
                {
                    Console.WriteLine(counter + ". " + vehicleStatusInfo.LicenseNumber);
                    counter++;
                }
            }
        }
        
        // (3) updace the vehicle status by the number license with the new status.
        public void UpdateVehicleStatus(string i_LicenseNumber, eVehicleStatus i_VehicleStatus)
        {
            m_VehiclesList[IndexOfVehicle(i_LicenseNumber)].VehicleStatus = i_VehicleStatus;
        }

        // (4) Fill air in wheels.
        public void FillAir(string i_LicenseNumber)
        {
            List<Wheel> vehicleWheelsList = m_VehiclesList[IndexOfVehicle(i_LicenseNumber)].Vehicle.WheelsList;
            foreach (Wheel currWheel in vehicleWheelsList)
            {
                // Calculate the amount of air to fill
                float currWheelAirPressureToAdd = currWheel.MaxPossiblePressure - currWheel.AirPressure;
                currWheel.AddAir(currWheelAirPressureToAdd);
            }
        }

        // (5)+(6) Fill up Fuel tank for motoric vehicle and charge battery.
        public void AddEnergy(string i_LicenseNumber, eEnergyType i_EnergyType, float i_EnergyAmount)
        {
            Vehicle currVehicle = m_VehiclesList[IndexOfVehicle(i_LicenseNumber)].Vehicle;
            eEnergyType vehicleEnergyType = currVehicle.m_EngineEnergyType;
            try
            {
                currVehicle.AddEnergy(i_EnergyType, i_EnergyAmount);
                Console.WriteLine("We added  to your " + currVehicle.GetType().Name + " " + currVehicle.EngineEnergyType  + " to the current value of " + currVehicle.EnergyLeft);
            }
            catch (EnergyDoesNotMatchToEngine)
            {
                Console.WriteLine("Your " + currVehicle.GetType().Name + " do not use " + i_EnergyType + " try again using " + vehicleEnergyType);
            }
            catch (ValueOutOfRangeException)
            {
                Console.WriteLine("Your " + currVehicle.GetType().Name + " has maximum amount capacity of " + vehicleEnergyType 
                    + " of " + currVehicle.MaxEnergy + ".\nyour currnet amount is " + currVehicle.EnergyLeft + " try again with lower amount.");
            } 
        }

        // (7)  Print vehicle information and status using reflection(part of didnt work on wheels).
        public void PrintVehicleInfo(string i_LicenseNumber)
        {
            VehicleStatusInfo vehicleStatusInfo = this.VehicleList[IndexOfVehicle(i_LicenseNumber)];
            Type typeOfVehicleStatusInfo = vehicleStatusInfo.GetType();
            FieldInfo[] fieldsOfVehicleStatusInfo = typeOfVehicleStatusInfo.GetFields();
            Console.WriteLine(vehicleStatusInfo.Vehicle.GetType().Name + " full information and status:");
            Console.WriteLine(" Vehicle Owner Name: " + vehicleStatusInfo.VehicleOwnerName);
            Console.WriteLine(" Vehicle Owner Phone Number: " + vehicleStatusInfo.VehicleOwnerPhone);
            Vehicle vehicle = vehicleStatusInfo.Vehicle;
            FieldInfo[] fieldsOfVehicle = vehicle.GetType().GetFields();
            foreach (FieldInfo field in fieldsOfVehicle)
            {
                if (field.Name.Equals("m_WheelsList"))
                {
                    int counter = 1;
                    foreach (Wheel wheel in vehicle.WheelsList)
                    {
                        Console.WriteLine(" Wheel No." + counter + " information:");
                        Console.WriteLine("  Manufacture:" + wheel.Manufacture);
                        Console.WriteLine("  Max possible pressure:" + wheel.MaxPossiblePressure);
                        Console.WriteLine("  Current air pressure:" + wheel.AirPressure);
                        counter++;
                        /*
                        FieldInfo[] fieldsOfWheel = wheel.GetType().GetFields();
                        foreach (FieldInfo wheelField in fieldsOfWheel)
                        {
                            Console.WriteLine("  " + wheelField.Name.Substring(2) + ":" + wheelField.GetValue(wheel));
                        }*/
                    }
                }
                else
                {
                    Console.WriteLine(" " + field.Name.Substring(2) + ": " + field.GetValue(vehicle));
                }
            }
        }

        // Check if vehical allready in the garage and return its index on the vehicle status list, if not return -1.
        public int IndexOfVehicle(string i_LicenseNumber)
        {
            int VehicleIndexOnList = -1;
            for (int index = 0; index < m_VehiclesList.Count; index++)
            {
                if (m_VehiclesList[index].LicenseNumber == i_LicenseNumber)
                {
                    VehicleIndexOnList = index;
                }
            }

            return VehicleIndexOnList;
        }
    }
}
