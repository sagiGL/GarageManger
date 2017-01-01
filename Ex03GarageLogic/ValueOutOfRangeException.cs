using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;
        private string m_Message;

        // Constractor
        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue, string i_Message)
            : base(string.Format(i_Message, i_MinValue, i_MaxValue), i_InnerException)
        {
            this.m_Message = i_Message;
            this.m_MinValue = i_MinValue;
            this.m_MaxValue = i_MaxValue;
        }

        // Default m_Message Constructor
        public ValueOutOfRangeException(
            Exception i_InnerException,
            float i_MinValue,
            float i_MaxValue) : 
            base(
            string.Format("An error occured while trying enter a value that is not in the range of {0} and {1}", i_MinValue, i_MaxValue), i_InnerException)
        { 
        }

        // Message gettter
        public override string Message
        {
            get { return this.m_Message; }
        }

        // MinValue getter
        public float MinValue
        {
            get { return this.MinValue; }
        }

        // MaxValue getter
        public float MaxValue
        {
            get { return this.m_MaxValue; }
        }
    }
}
