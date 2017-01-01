using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eEnergyType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98,
        Electricity,
        DeFault
    }

    public enum eVehicleType
    {
        MotoricCar,
        ElectricCar,
        MotoricBike,
        ElecticBike,
        Truck,
        Else
    }

    public class Vehicle
    {
        public string m_LisenseNum;
        public string m_ModelName;
        public eEnergyType m_EngineEnergyType;
        public float m_MaxEnergy;
        public float m_EnergyLeft;
        public List<Wheel> m_WheelsList;

        // Constructor
        public Vehicle(
            string i_ModelName,
            string i_LisenseNum,
            float i_EnergyLeft,
            List<Wheel> i_WeelsList,
            eEnergyType i_EnergyType,
            float i_MaxEnergy)
        {
            m_ModelName = i_ModelName;
            m_LisenseNum = i_LisenseNum;
            m_EnergyLeft = i_EnergyLeft;
            m_WheelsList = i_WeelsList;
            m_EngineEnergyType = i_EnergyType;
            m_MaxEnergy = i_MaxEnergy;
        }

        // EnergyLeft getter / setter
        public float EnergyLeft
        {
            get { return m_EnergyLeft; }
            set { m_EnergyLeft = value; }
        }

        // LisenceNum getter / setter
        public string LisenceNum
        {
            get { return m_LisenseNum; }
            set { m_LisenseNum = value; }
        }

        // ModelName getter / setter
        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        // WheelsList getter / setter
        public List<Wheel> WheelsList
        {
            get { return m_WheelsList; }
            set { m_WheelsList = value; }
        }

        // EngineEnergyType getter / setter
        public virtual eEnergyType EngineEnergyType
        {
            get { return m_EngineEnergyType; }
            set { m_EngineEnergyType = value; }
        }

        // MaxEnergy getter / setter
        public float MaxEnergy
        {
            get { return m_MaxEnergy; }
            set { m_MaxEnergy = value; }
        }

        // AddEnergy - Fule or Electricity
        public void AddEnergy(eEnergyType i_EnergyTypeToAdd, float i_EnergyAmountToAdd)
        {
            if (this.EngineEnergyType == i_EnergyTypeToAdd)
            {
                float totalAmount = this.EnergyLeft + i_EnergyAmountToAdd;
                if (totalAmount <= this.m_MaxEnergy)
                {
                    this.EnergyLeft += i_EnergyAmountToAdd;
                }
                else
                {
                    Exception valueOutOfRangeException = new Exception();
                    throw new ValueOutOfRangeException(valueOutOfRangeException, 0, this.MaxEnergy);
                }
            }
            else
            {
                Exception ex = new Exception();
                throw new EnergyDoesNotMatchToEngine(ex, i_EnergyTypeToAdd, this.EngineEnergyType);
            }
        }
    }
}