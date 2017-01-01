using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eColor
    {
        Yellow,
        White,
        Red,
        Black,
        Other
    }

    public class Car : Vehicle
    {
        public eColor m_Color;
        public int m_NumOfDoors;

        // Constructur
        public Car(
            string i_ModelName,
            string i_LisenseNum,
            float i_EnergyLeft,
            List<Wheel> i_WeelsList,
            eEnergyType i_FuleType,
            float i_MaxEnergy,
            eColor i_Color,
            int i_NumOfDoors) : base(i_ModelName, i_LisenseNum, i_EnergyLeft, i_WeelsList, i_FuleType, i_MaxEnergy)
        {
                    m_Color = i_Color;
                    m_NumOfDoors = i_NumOfDoors;
        }

        // NumOfDoors getter / setter
        public int NumOfDoors
        {
            get { return m_NumOfDoors; }
            set { m_NumOfDoors = value; }
        }

        // Color getter / setter
        public eColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }
    }
}
