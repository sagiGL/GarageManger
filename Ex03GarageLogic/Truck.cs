using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle 
    {
        public bool m_HasDangerouseMaterial;
        public float m_MaxWeight;

        // Constructor
        public Truck(
            string i_ModelName,
            string i_LisenseNum,
            float i_EnergyLeft, 
            List<Wheel> i_WeelsList,
            eEnergyType i_FuleType,
            float i_MaxEnergy,
            bool i_HasDangerouseMaterial,
            float i_MaxWeight )
            : base(i_ModelName, i_LisenseNum, i_EnergyLeft, i_WeelsList, i_FuleType, i_MaxEnergy)
        {
            m_HasDangerouseMaterial = i_HasDangerouseMaterial;
            m_MaxWeight = i_MaxWeight;
        }

        // MaxWeight getter / setter
        public float MaxWeight
        {
            get { return m_MaxWeight; }
            set { float m_MaxWeight = value; }
        }

        // HasDangerouseMaterial getter / setter
        public bool HasDangerouse
        {
            get { return m_HasDangerouseMaterial; }
            set { m_HasDangerouseMaterial = value; }
        }
    }
}
