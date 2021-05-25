using System.Runtime.InteropServices;

namespace ColdClearSharp {
    [StructLayout(LayoutKind.Sequential)]
    public class CCOptions {
        public CCMovementMode mode;
        public CCSpawnRule spawnRule;
        public CCPcPriority pcLoop;
        public uint minNodes;
        public uint maxNodes;
        public uint threads;
        [MarshalAs(UnmanagedType.U1)] public bool useHold;
        [MarshalAs(UnmanagedType.U1)] public bool speculate;
    }
}