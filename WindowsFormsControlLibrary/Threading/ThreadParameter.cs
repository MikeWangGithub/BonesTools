using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsControlLibrary.Threading
{
    public class UpdateBoneDataParameter :ICloneable
    {
        public string CharactorFileName { get; set; }
        public SafeCallDelegateUpdateBoneByString UpdateOneBone { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone(); 
        }
        public UpdateBoneDataParameter(string charactorFileName, SafeCallDelegateUpdateBoneByString updateOneBone)
        {
            CharactorFileName = charactorFileName;
            UpdateOneBone = updateOneBone;
        }
    }
    public class WriteBoneDataParameter : ICloneable
    {
        public string CharactorFileName { get; set; }
        public List<string> lines { get; set; }

        public ESaveBoneSetting BoneSaveSettting { get; set; } 
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public WriteBoneDataParameter(string charactorFileName)
        {
            CharactorFileName = charactorFileName;
            BoneSaveSettting = ESaveBoneSetting.OnlyChanged;


        }
    }
    public delegate void SafeCallDelegateUpdateBoneByString(string text);
    public delegate void SafeCallDelegateUpdateBoneByClass(Bone bone, EAction eAction);

    public enum ThreadTypes {  UpdateBoneData, WriteBoneData }

}
