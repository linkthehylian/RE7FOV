using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE7FOV.Util
{
    public class FOVOffsets
    {
        public static ulong[] main = { 0xD8, 0x178, 0xD8, 0x178, 0x50, 0x38, 0x148 }; //Main campaign FOV offsets
        public static ulong[] dlc1 = { 0xE8, 0x118, 0x258, 0x20, 0x10, 0x40, 0x9E8 }; //Not A Hero FOV offsets
        public static ulong[] dlc2 = { 0xE0, 0x98, 0x120, 0x188, 0xC0, 0x60, 0x18 }; //End of Zoe FOV offsets
        public static ulong[] dx11 = { 0x28, 0x78, 0xA8, 0x28, 0x30, 0x60, 0x28 };
        public static ulong[] trial = { 0x70, 0x80, 0x128, 0x5A8, 0x28, 0x28, 0x8D8 }; //Beginning Hour demo FOV offsets
    }
}
