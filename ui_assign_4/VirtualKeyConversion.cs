using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace ui_assign_4
{
    class VirtualKeyConversion
    {
        /// <summary>
        /// Convert a VirtualKey to an integer
        /// </summary>
        /// <param name="key">Virtual Key from key event</param>
        /// <returns>Number pressed on keyboard or -1 if a number was not pressed</returns>
        public static int ConvertToInt(VirtualKey key)
        {
            switch (key)
            {
                case VirtualKey.Number0:
                    return 0;
                case VirtualKey.Number1:
                    return 1;
                case VirtualKey.Number2:
                    return 2;
                case VirtualKey.Number3:
                    return 3;
                case VirtualKey.Number4:
                    return 4;
                case VirtualKey.Number5:
                    return 5;
                case VirtualKey.Number6:
                    return 6;
                case VirtualKey.Number7:
                    return 7;
                case VirtualKey.Number8:
                    return 8;
                case VirtualKey.Number9:
                    return 9;
                case VirtualKey.NumberPad0:
                    return 0;
                case VirtualKey.NumberPad1:
                    return 1;
                case VirtualKey.NumberPad2:
                    return 2;
                case VirtualKey.NumberPad3:
                    return 3;
                case VirtualKey.NumberPad4:
                    return 4;
                case VirtualKey.NumberPad5:
                    return 5;
                case VirtualKey.NumberPad6:
                    return 6;
                case VirtualKey.NumberPad7:
                    return 7;
                case VirtualKey.NumberPad8:
                    return 8;
                case VirtualKey.NumberPad9:
                    return 9;
            }

            return -1;
        }
    }
}
