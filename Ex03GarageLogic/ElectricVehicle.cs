//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Ex03.GarageLogic
//{
//    class ElectricVehicle : Vehicle
//    {

//        public ElectricVehicle(string i_ModelName, string i_LisenseNum, float i_BatteryHours, List<Wheel> i_WeelsList,float i_MaxBatteryHours)
//            : base(i_ModelName, i_LisenseNum, i_BatteryHours, i_WeelsList, eEnergyType.Electricity, i_MaxBatteryHours)
//        {
//            this.EnergyLeft = i_BatteryHours;
//            this.MaxEnergy = i_MaxBatteryHours;
//        }
            
//        public float MaxBatteryHours
//        {
//            get { return m_EnergyLeft; }
//            set { m_MaxEnergy = value; }
//        }
        
//        public float BatteryHours
//        {   
//            get { return m_EnergyLeft;}
//            set { m_EnergyLeft = value;}
//        }

//        public bool AddEnergy(float i_HoursToAdd)
//        {
//            bool wasAdded = false;
//            float totalHours = this.BatteryHours + i_HoursToAdd;
//            if (totalHours <= this.MaxBatteryHours)
//            {
//                this.BatteryHours += i_HoursToAdd;
//                wasAdded = true;
//            }
            
//            return wasAdded;
//        }

//    }
//}
