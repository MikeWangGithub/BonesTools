using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Verktyg.Threading;

namespace WindowsFormsControlLibrary.Threading
{
    public class ThreadFactory
    {
        public static CustomizedThread createThread(ThreadTypes ThreadName, CancellationTokenSource _tokenSource, ICloneable _threadParameter)
        {
            CustomizedThread thread = null;
            switch (ThreadName)
            {
                case ThreadTypes.UpdateBoneData:
                    thread = new UpdateBoneDataThread(_tokenSource, _threadParameter);
                    break;
                case ThreadTypes.WriteBoneData:
                    thread = new WriteBoneDataThread(_tokenSource, _threadParameter);
                    break;
                default:
                    break;
            }
            return thread;
        }
    }
}
