using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconWraith.Common.API.Common
{
    public interface IDisposableExtended : IDisposable
    {
        /// <summary>
        /// 	Returns true if the object has been Disposed, false otherwise.
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// 	Performs application-defined tasks associated with freeing, releasing, or resetting managed resources.
        /// 	This method is called when the object is Disposed explicitly but not when GC.Finalize is called on it.
        /// </summary>
        void CleanupManagedResources();

        /// <summary>
        /// 	Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// 	This method is called when the object is Disposed explicitly or the framework collects the object.
        /// </summary>
        void CleanupUnmanagedResources();

        /// <summary>
        /// 	Will throw a ObjectDisposeException if the object has been Disposed.
        /// </summary>
        void CheckDisposed();


        /// <summary>
        /// 	Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing"> True if the object is being disposed, false otherwise. </param>
        void Dispose(bool disposing);
    }
}
