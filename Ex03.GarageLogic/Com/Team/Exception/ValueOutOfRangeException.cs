﻿// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace Ex03.GarageLogic.Com.Team.Exception
{
    public class ValueOutOfRangeException : System.Exception
    {
        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
            : base(string.Format(
                "Invalid ranges, Max Value: {0}, Min Value: {1}", i_MaxValue,
                i_MinValue))
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
        }

        private float MaxValue { get; } // Redundant, but required by lecturer.

        private float MinValue { get; } // Redundant, but required by lecturer.
    }
}
