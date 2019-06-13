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
    public class UpdateBoneDataThread: CustomizedThread
    {
        private UpdateBoneDataParameter param;
        public UpdateBoneDataThread(CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_tokenSource, _threadParameter)
        {
            param = (UpdateBoneDataParameter)_threadParameter;
        }
        
        public override void RunSub(ICloneable _threadParameter)
        {
            JudgeTaskCancelFlag();
            //Open file
            List<string> Lines = new List<string>();
            // FileStream fileStream = new FileStream(param.CharactorFileName, FileMode.Open, FileAccess.Read);

            using (StreamReader reader = File.OpenText(param.CharactorFileName))
            {
                while (reader.Peek() >= 0)
                {
                    JudgeTaskCancelFlag();
                    string line = reader.ReadLine();
                    if (line.Length >= 1) { 
                        switch (line.ToLower().Substring(0,1)){
                            case "s":
                                Lines.Add(line);
                                break;
                            case "r":
                                Lines.Add(line);
                                break;
                            case "p":
                                Lines.Add(line);
                                break;
                            default:
                                break;
                        }
                    }

                }
            }
            foreach(string line in Lines)
            {
                JudgeTaskCancelFlag();
                param.UpdateOneBone(line);
            }

            
        //JudgeTaskCancelFlag();
        //CopyFileParameter subparam = (CopyFileParameter)param.Clone();
        //subparam.OriginalDirectory = dir.FullName;
        //        subparam.OutoutDirectoy = param.OutoutDirectoy + "\\" + originalFold.Name;
        //        RunSub(subparam);
            
        }

        public override bool CheckParameter()
        {
            if (System.IO.File.Exists(param.CharactorFileName)) { return true; }
            return false;
        }
    }
}
