using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Ticket12306
{
    public static class CodeAPI
    {
        [DllImport("Vc.dll", CharSet = CharSet.Ansi)]
        public static extern bool GetCodeFromBuffer(Int32 LibFileIndex, Byte[] FileBuffer, Int32 ImgBufLen, StringBuilder Code);
        [DllImport("Vc.dll", CharSet = CharSet.Ansi)]
        public static extern bool LoadLibFromBuffer(Byte[] FileBuffer, Int32 BufLen, String Password);
    }
}
