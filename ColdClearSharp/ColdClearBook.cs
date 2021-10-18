using System;
using static ColdClearSharp.NativeMethods;

namespace ColdClearSharp {
    public class ColdClearBook : IDisposable {
        private IntPtr book;

        private ColdClearBook(IntPtr book) {
            this.book = book;
        }

        public static ColdClearBook Load(string pathToBook) {
            var ptr = cc_load_book_from_file(pathToBook);
            return ptr == IntPtr.Zero ? null : new ColdClearBook(ptr);
        }

        private void ReleaseUnmanagedResources() {
            if (book == IntPtr.Zero) return;
            
            cc_destroy_book(book);
            book = IntPtr.Zero;
        }

        public void Dispose() {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~ColdClearBook() {
            ReleaseUnmanagedResources();
        }
    }
}