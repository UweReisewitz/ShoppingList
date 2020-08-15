using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ShoppingList.Core
{
    public class EnumValueDescription
    {
        public EnumValueDescription(Enum enumvalue, string description)
        {
            EnumValue = enumvalue;
            Description = description;
        }
        public Enum EnumValue { get; set; }
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var val1 = Convert.ToInt32(EnumValue, CultureInfo.InvariantCulture);
            var val2 = Convert.ToInt32(((EnumValueDescription)obj).EnumValue, CultureInfo.InvariantCulture);
            var retval = (val1 == val2);
            return retval;
        }

        public override int GetHashCode()
        {
            return EnumValue.GetHashCode();
        }

        public static bool operator ==(EnumValueDescription obj1, EnumValueDescription obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }

            if (ReferenceEquals(obj1, null))
            {
                return false;
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(EnumValueDescription obj1, EnumValueDescription obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
