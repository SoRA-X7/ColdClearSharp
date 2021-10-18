using System;
using System.Runtime.InteropServices;

namespace ColdClearSharp {
    internal static class NativeMethods {
        private const string CC_DLL = "libcold_clear";
        
        [DllImport(CC_DLL)]
        internal static extern IntPtr cc_launch_async(
            CCOptions options,
            CCWeights weights,
            IntPtr book,
            CCPiece[] queue,
            uint count);
        
        [DllImport(CC_DLL)]
        internal static extern IntPtr cc_launch_with_board_async(
            CCOptions options,
            CCWeights weights,
            IntPtr book,
            byte[] field, 
            uint bag_remain,
            ref CCPiece hold, 
            [MarshalAs(UnmanagedType.U1)] bool b2b, 
            uint combo,
            CCPiece[] queue,
            uint count);
        
        [DllImport(CC_DLL)]
        internal static extern void cc_destroy_async(IntPtr bot);
        
        [DllImport(CC_DLL)]
        internal static extern void cc_reset_async(
            IntPtr bot,
            byte[] field,
            [MarshalAs(UnmanagedType.U1)] bool b2b,
            uint combo);
        
        [DllImport(CC_DLL)]
        internal static extern void cc_add_next_piece_async(IntPtr bot, CCPiece piece);
        
        [DllImport(CC_DLL)]
        internal static extern void cc_request_next_move(IntPtr bot, uint incoming);
        
        [DllImport(CC_DLL)]
        internal static extern CCBotPollStatus cc_poll_next_move(
            IntPtr bot,
            [Out] CCMove move,
            [Out] CCPlanPlacement[] plan,
            ref uint plan_length
        );
        
        [DllImport(CC_DLL)]
        internal static extern CCBotPollStatus cc_block_next_move(
            IntPtr bot,
            [Out] CCMove move,
            [Out] CCPlanPlacement[] plan,
            ref uint plan_length
        );
        
        [DllImport(CC_DLL)]
        internal static extern void cc_default_options([Out] CCOptions options);
        
        [DllImport(CC_DLL)]
        internal static extern void cc_default_weights([Out] CCWeights weights);
        
        [DllImport(CC_DLL)]
        internal static extern void cc_fast_weights([Out] CCWeights weights);
        
        [DllImport(CC_DLL)]
        internal static extern IntPtr cc_load_book_from_file(string path);
        
        [DllImport(CC_DLL)]
        internal static extern void cc_destroy_book(IntPtr book);
    }
}