using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using WindowsFormsControlLibrary.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Verktyg.Threading
{
    public class WriteBoneDataThread: CustomizedThread
    {
        private WriteBoneDataParameter param;
        public WriteBoneDataThread(CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_tokenSource, _threadParameter)
        {
            param = (WriteBoneDataParameter)_threadParameter;
        }
        
        public override void RunSub(ICloneable _threadParameter)
        {
            JudgeTaskCancelFlag();
            //Open file
            //List<string> Lines = new List<string>();
            // FileStream fileStream = new FileStream(param.CharactorFileName, FileMode.Open, FileAccess.Read);
            try { 
                using (StreamWriter write = new StreamWriter(param.CharactorFileName,false))
                {
                    foreach(string line in param.lines) { 

                        JudgeTaskCancelFlag();
                        write.WriteLine(line);
                    
                    
                    }
                }
            }
            catch
            {

            }


        //JudgeTaskCancelFlag();
        //CopyFileParameter subparam = (CopyFileParameter)param.Clone();
        //subparam.OriginalDirectory = dir.FullName;
        //        subparam.OutoutDirectoy = param.OutoutDirectoy + "\\" + originalFold.Name;
        //        RunSub(subparam);

        }

        public override bool CheckParameter()
        {
            //if (System.IO.File.Exists(param.CharactorFileName)) { return true; }
            //return false;
            return true;
        }
    }
}
