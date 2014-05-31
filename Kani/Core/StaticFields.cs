using System;

namespace Kani.Core
{
    public static class StaticFields
    {
        public static Array Playerses { 
            get
            {
                return Enum.GetValues(typeof(Enums.Players));
            }
        }
    }
}
