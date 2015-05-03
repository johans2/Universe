using UnityEngine;
using System.Collections;

namespace Universe.Core.MathU
{ 
    public static class MathU
    {
        public static bool RoughlyEqual(float a, float b, float threshold)
        {
            return (Mathf.Abs(a - b) < threshold);
        }
    }
}
