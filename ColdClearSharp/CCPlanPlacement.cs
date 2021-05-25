using System.Runtime.InteropServices;

namespace ColdClearSharp {
    public struct CCPlanPlacement {
        public CCPiece piece;
        public CCTspinStatus tspin;

        /* Expected cell coordinates of placement, (0, 0) being the bottom left */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public byte[] expected_x;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public byte[] expected_y;

        /* Expected lines that will be cleared after placement, with -1 indicating no line */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public int[] cleared_lines;
    }
}