using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eLisenceSize
    {
        A,
        A1,
        AB,
        B1,
        Other
    }

    public class Motorcycle : Vehicle
    {
        public eLisenceSize m_LisenceSize;
        public int m_EngineCapacity;

        // Constructor
        public Motorcycle(
            string i_ModelName,
            string i_LisenseNum,
            float i_EnergyLeft,
            List<Wheel> i_WeelsList,
            eEnergyType i_FuleType,
            float i_MaxEnergy,
            eLisenceSize i_LisenceSize,
            int i_EngineCapasity) : base(
            i_ModelName, 
            i_LisenseNum, 
            i_EnergyLeft, 
            i_WeelsList, 
            i_FuleType, 
            i_MaxEnergy)
        {
            m_LisenceSize = i_LisenceSize;
            m_EngineCapacity = i_EngineCapasity;
        }

        // EngineCapacity getter / setter
        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }

        // LisenceSize getter / setter
        public eLisenceSize LisenceSize
        {
            get { return m_LisenceSize; }
            set { m_LisenceSize = value; }
        }
    }
}
