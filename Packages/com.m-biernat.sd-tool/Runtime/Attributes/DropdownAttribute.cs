using UnityEngine;

namespace SDTool
{
    public class DropdownAttribute : PropertyAttribute
    {
        public readonly string[] values;

        public int index;

        public void IndexFromValue(string value)
        {
            if (index > -1) return;

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == value)
                {
                    index = i;
                    return;
                }
            }
            index = 0;
        }

        public DropdownAttribute(string[] values)
        {
            this.values = values;
            index = -1;
        }
    }
}