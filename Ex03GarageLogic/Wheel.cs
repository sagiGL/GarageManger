using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    // Constructor
    public class Wheel
    {
        private string m_Manufacture;
        private float m_AirPressure;
        private float m_MaxPssiblePressure;

        public Wheel(string i_Manufacture, float i_AirPressure, float i_MaxPossiblePressure)
        {
            this.m_Manufacture = i_Manufacture;
            m_AirPressure = i_AirPressure;
            m_MaxPssiblePressure = i_MaxPossiblePressure;
        }

        // Manufactur getter / setter
        public string Manufacture
        {
            get { return m_Manufacture; }
            set { m_Manufacture = value; }
        }

        // AirePressure getter / setter
        public float AirPressure
        {
            get { return m_AirPressure; }
            set { m_AirPressure = value; }
        }

        // MaxPossiblePressure getter / setter
        public float MaxPossiblePressure
        {
            get { return m_MaxPssiblePressure; }
            set { m_MaxPssiblePressure = value; }
        }

        // AddAit to the current Wheel 
        // Throws ValueOutOfRangeException
        public void AddAir(float airPressureToAdd)
        {
            float newAirPressure = this.AirPressure + airPressureToAdd; // This can throw a null exception;
            if (airPressureToAdd > 0 && newAirPressure <= this.m_MaxPssiblePressure)
            {
                this.AirPressure = this.AirPressure + airPressureToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(new Exception(), 0, this.MaxPossiblePressure);
            }
         }
    }
}
