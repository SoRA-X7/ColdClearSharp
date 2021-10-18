using System;
using System.Linq;
using System.Threading.Tasks;
using static ColdClearSharp.NativeMethods;

namespace ColdClearSharp {
    public class ColdClearBot : IDisposable {
        private IntPtr bot;

        public ColdClearBot() {
            bot = cc_launch_async(DefaultOptions, DefaultWeights, (IntPtr)null, Array.Empty<CCPiece>(), 0);
        }

        public ColdClearBot(CCOptions options, CCWeights weights) {
            bot = cc_launch_async(options, weights, (IntPtr)null, Array.Empty<CCPiece>(), 0);
        }

        public void AddNextPiece(CCPiece piece) {
            cc_add_next_piece_async(bot, piece);
        }

        public async Task<(CCMove move, CCPlanPlacement[] plan)?> NextMove(uint incomingGarbage) {
            return await Task.Run(() => {
                var move = new CCMove();
                var planLength = 32U;
                var plan = new CCPlanPlacement[planLength];
                var status = cc_block_next_move(bot, move, plan, ref planLength);
                if (status == CCBotPollStatus.MoveProvided) {
                    return (move, plan.Take((int)planLength).ToArray());
                } else {
                    return ((CCMove, CCPlanPlacement[])?)null;
                }
            });
        }

        public void RequestNextMove(uint incomingGarbage) {
            cc_request_next_move(bot, incomingGarbage);
        }

        public CCBotPollStatus PollNextMove(out CCMove move, out CCPlanPlacement[] plan) {
            move = new CCMove();
            var planLength = 32U;
            plan = new CCPlanPlacement[planLength];
            var status = cc_poll_next_move(bot, move, plan, ref planLength);
            plan = plan.Take((int)planLength).ToArray();
            return status;
        }

        public void Reset(bool[] board, uint combo, bool backToBack) {
            cc_reset_async(bot, board.Select(b => b ? (byte)1 : (byte)0).ToArray(), backToBack, combo);
        }

        private void ReleaseUnmanagedResources() {
            cc_destroy_async(bot);
        }

        public void Dispose() {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~ColdClearBot() {
            ReleaseUnmanagedResources();
        }

        public static CCOptions DefaultOptions {
            get {
                var options = new CCOptions();
                cc_default_options(options);
                return options;
            }
        }

        public static CCWeights DefaultWeights {
            get {
                var weights = new CCWeights();
                cc_default_weights(weights);
                return weights;
            }
        }

        public static CCWeights FastWeights {
            get {
                var weights = new CCWeights();
                cc_fast_weights(weights);
                return weights;
            }
        }
    }
}