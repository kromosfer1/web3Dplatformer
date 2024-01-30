using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public static class CharacterSystemUtilities 
    {
        public static float CalculatePercentage(float minValue, float maxValue, float currentValue)
        {
            if (maxValue == minValue)
            {
                throw new ArgumentException("Max value and min value cannot be the same.");
            }

            return (currentValue - minValue) / (maxValue - minValue);
        }
    }
}
