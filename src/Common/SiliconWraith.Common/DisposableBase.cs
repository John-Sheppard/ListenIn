using SiliconWraith.Common.API.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconWraith.Common
{
    public abstract class DisposableBase : IDisposableExtended
    {
        private bool _disposed;


        /// <summary>
        /// Destructors are used to destruct instances of classes. 
        /// </summary>
        /// <remarks>
        /// <list type="Bullet">
        /// <item>
        /// <description>
        /// Destructors cannot be inherited or overloaded.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Destructors cannot be called. They are invoked automatically. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A destructor does not take modifiers or have parameters. 
        /// </description>
        /// </item>
        /// </list>
        /// The destructor implicitly calls Finalize on the base class of the object.
        /// This means that the Finalize method is called recursively for all instances in the inheritance chain, from the most-derived to the least-derived. 
        /// Note: 
        /// Empty destructors should not be used. When a class contains a destructor, an entry is created in the Finalize queue. When the destructor is called, the garbage collector is invoked to process the queue. If the destructor is empty, this just causes a needless loss of performance. 
        /// </remarks>
        ~DisposableBase()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }


        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">True if the object is being disposed, false otherwise.</param>
        public void Dispose(bool disposing)
        {
            if (!this.IsDisposed)
            {
                this.CleanupUnmanagedResources();
                if (disposing)
                {
                    // This implementing classes based upon ServiceWorkerBase
                    // will only get their unmanged rescources cleaned up when 
                    // the disposing variable is set to true
                    // which is true only when someone explicitly calls dispose
                    // or the Framework garbage collects. Therefore we need to call
                    // GC.SuppressFinalize to take the object off the finalization queue
                    // and prevent finalization for this object from executing a second
                    // time.
                    this.CleanupManagedResources();
                    GC.SuppressFinalize(this);
                }
                this._disposed = true;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed resources.
        /// This method is called when the object is Disposed explicitly but not when GC.Finalize is called on it.
        /// </summary>
        public virtual void CleanupManagedResources()
        {
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// This method is called when the object is Disposed explicitly or the framework collects the object.
        /// </summary>
        public virtual void CleanupUnmanagedResources()
        {
        }

        /// <summary>
        /// Returns true if the object has been Disposed, false otherwise.
        /// </summary>
        public bool IsDisposed
        {
            get
            {
                return this._disposed;
            }
        }

        /// <summary>
        /// Will throw a ObjectDisposeException if the object has been Disposed.
        /// </summary>
        public void CheckDisposed()
        {
            ObjectDisposedException.ThrowIf(this.IsDisposed, this);
        }
    }

}
