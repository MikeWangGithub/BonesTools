using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WindowsFormsControlLibrary.Threading
{
    public class ThreadContext
    {
        private CustomizedThread superThread = null;
        public ThreadContext(ThreadTypes ThreadName, CancellationTokenSource _tokenSource, ICloneable _threadParameter)
        {
            superThread = ThreadFactory.createThread(ThreadName, _tokenSource, _threadParameter);
        }

        public Task ThreadRun()
        {
            if(superThread!= null)
            {
                return superThread.Run();
            }
            else { return null; }
        }
    }
}
