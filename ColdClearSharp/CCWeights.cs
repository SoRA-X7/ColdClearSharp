using System.Runtime.InteropServices;

namespace ColdClearSharp {
    [StructLayout(LayoutKind.Sequential)]
    public class CCWeights {
        public int backToBack;
        public int bumpiness;
        public int bumpinessSq;
        public int rowTransitions;
        public int height;
        public int topHalf;
        public int jeopardy;
        public int topQuarter;
        public int cavityCells;
        public int cavityCellsSq;
        public int overhangCells;
        public int overhangCellsSq;
        public int coveredCells;
        public int coveredCellsSq;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public int[] tslot;
        public int wellDepth;
        public int maxWellDepth;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)] public int[] wellColumn;
        
        public int b2bClear;
        public int clear1;
        public int clear2;
        public int clear3;
        public int clear4;
        public int tspin1;
        public int tspin2;
        public int tspin3;
        public int miniTspin1;
        public int miniTspin2;
        public int perfectClear;
        public int comboGarbage;
        public int moveTime;
        public int wastedT;

        [MarshalAs(UnmanagedType.U1)] public bool useBag;
        [MarshalAs(UnmanagedType.U1)] public bool stackPcDamage;
        [MarshalAs(UnmanagedType.U1)] public bool timedJeopardy;
    }
}