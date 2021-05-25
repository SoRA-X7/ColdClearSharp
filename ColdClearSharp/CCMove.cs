using System.Runtime.InteropServices;

namespace ColdClearSharp {
    [StructLayout(LayoutKind.Sequential)]
    public class CCMove {
        /* Whether hold is required */
        [MarshalAs(UnmanagedType.U1)] public bool hold;
        /* Expected cell coordinates of placement, (0, 0) being the bottom left */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public byte[] expectedX;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public byte[] expectedY;
        /* Number of moves in the path */
        public byte movementCount;
        /* Movements */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public CCMovement[] movements;

        /* Bot Info */
        public uint nodes;
        public uint depth;
        public uint originalRank;
    }
}