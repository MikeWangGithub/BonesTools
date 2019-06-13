using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsControlLibrary
{
    public class Bone:ICloneable
    {

        public string BoneName { get; set; }
        public string BoneTranslateName { get; set; }

        public string BoneDescription { get; set; }
        public decimal ScalingX { get; set; }
        public decimal ScalingY { get; set; }
        public decimal ScalingZ { get; set; }

        public decimal RotationX { get; set; }
        public decimal RotationY { get; set; }
        public decimal RotationZ { get; set; }

        public decimal PositioningX { get; set; }
        public decimal PositioningY { get; set; }
        public decimal PositioningZ { get; set; }

        
        public EBoneType BoneType { get; set; }

        public Bone(EBoneType boneType, string boneName, string boneTranslateName, string boneDescription)
        {
            BoneName = boneName;
            BoneType = boneType;
            BoneTranslateName = boneTranslateName;
            BoneDescription = boneDescription;
            ScalingX = 1;
            ScalingY = 1;
            ScalingZ = 1;

            RotationX = 0;
            RotationY = 0;
            RotationZ = 0;

            PositioningX = 0;
            PositioningY = 0;
            PositioningZ = 0;

        }

        public bool IsScalingModified()
        {
            if (ScalingX != 1) { return true; }
            if (ScalingY != 1) { return true; }
            if (ScalingZ != 1) { return true; }
            return false;
        }
        public bool IsRotationModified()
        {
            if (RotationX != 0) { return true; }
            if (RotationY != 0) { return true; }
            if (RotationZ != 0) { return true; }
            return false;
        }
        public bool IsPositioningModified()
        {
            if (PositioningX != 0) { return true; }
            if (PositioningY != 0) { return true; }
            if (PositioningZ != 0) { return true; }
            return false;
        }
        public static string GetBoneName(string lineValue)
        {
            List<string> values = lineValue.Split(',').ToList<string>();
            if (values.Count >= 2)
            {
                return values[1];
            }
            else
            {
                return "";
            }

        }

        public string GetLineValue(EAction eAction)
        {
            string rtn = "";
            switch (eAction) {
                case EAction.Scaling:
                    rtn = "s" + BonesResources.SpiltSymbol + this.BoneName + BonesResources.SpiltSymbol + this.ScalingX.ToString() + BonesResources.SpiltSymbol + this.ScalingY.ToString() + BonesResources.SpiltSymbol + this.ScalingZ.ToString();
                    break;
                case EAction.Rotation:
                    rtn = "r" + BonesResources.SpiltSymbol + this.BoneName + BonesResources.SpiltSymbol + this.RotationX.ToString() + BonesResources.SpiltSymbol + this.RotationY.ToString() + BonesResources.SpiltSymbol + this.RotationZ.ToString();
                    break;
                case EAction.Positioning:
                    rtn = "p" + BonesResources.SpiltSymbol + this.BoneName + BonesResources.SpiltSymbol + this.PositioningX.ToString() + BonesResources.SpiltSymbol + this.PositioningY.ToString() + BonesResources.SpiltSymbol + this.PositioningZ.ToString();
                    break;
                default:
                    break;
            }
            return rtn;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public bool IsNeedUpdate(string Value)
        {
            EAction eAction;
            Bone bone = Bone.GetBoneByString(Value,out eAction);
            return IsNeedUpdate(bone, eAction);
        }
        public bool IsNeedUpdate(Bone bone, EAction action)
        {
            if(bone.BoneName == this.BoneName)
            {
                switch (action)
                {
                    case EAction.Scaling:
                        if (bone.ScalingX != this.ScalingX) { return true; }
                        if (bone.ScalingY != this.ScalingY) { return true; }
                        if (bone.ScalingZ != this.ScalingZ) { return true; }
                        break;
                    case EAction.Rotation:
                        if (bone.RotationX != this.RotationX) { return true; }
                        if (bone.RotationY != this.RotationY) { return true; }
                        if (bone.RotationZ != this.RotationZ) { return true; }
                        break;
                    case EAction.Positioning:
                        if (bone.PositioningX != this.PositioningX) { return true; }
                        if (bone.PositioningY != this.PositioningY) { return true; }
                        if (bone.PositioningZ != this.PositioningZ) { return true; }
                        break;

                    default:
                        break;
                }
                
            }
            return false;
        }
        public static Bone GetBoneByString(string Value, out EAction eAction)
        {
            List<string> values = Value.Split(',').ToList<string>();
            int i = 0;
            string name = "";
            decimal x = 0, y = 0, z = 0;
            EAction action = EAction.None;
            foreach (string v in values)
            {
                if (i < values.Count)
                {
                    // array ok;
                    switch (i)
                    {
                        case 0:
                            action = Bone.GetAction(v);
                            break;
                        case 1:
                            name = v;
                            break;
                        case 2:
                            x = Bone.Getdecimal(action, v);
                            break;
                        case 3:
                            y = Bone.Getdecimal(action, v);
                            break;
                        case 4:
                            z = Bone.Getdecimal(action, v);
                            break;
                        default:
                            break;
                    }
                }

                i++;
            }
            Bone rtn = BonesResources.GetBoneByBoneName(name.Trim());
            eAction = action;
            if (rtn != null) { 
                switch (action)
                {
                    case EAction.Scaling:
                        rtn.ScalingX = x;
                        rtn.ScalingY = y;
                        rtn.ScalingZ = z;
                        break;
                    case EAction.Rotation:
                        rtn.RotationX = x;
                        rtn.RotationY = y;
                        rtn.RotationZ = z;
                        break;
                    case EAction.Positioning:
                        rtn.PositioningX = x;
                        rtn.PositioningY = y;
                        rtn.PositioningZ = z;
                        break;

                    default:
                        break;
                }
            }
            return rtn;
        }
        public void Update(string Value)
        {
            EAction eAction;
            Bone bone = GetBoneByString(Value, out eAction);

            if (bone.BoneName.ToLower().Trim() == this.BoneName.ToLower().Trim())
            {
                switch (eAction)
                {
                    case EAction.Scaling:
                        this.ScalingX = bone.ScalingX;
                        this.ScalingY = bone.ScalingY;
                        this.ScalingZ = bone.ScalingZ;
                        break;
                    case EAction.Rotation:
                        this.RotationX = bone.RotationX;
                        this.RotationY = bone.RotationY;
                        this.RotationZ = bone.RotationZ;
                        break;
                    case EAction.Positioning:
                        this.PositioningX = bone.PositioningX;
                        this.PositioningY = bone.PositioningY;
                        this.PositioningZ = bone.PositioningZ;
                        break;

                    default:
                        break;
                }
            }
        }

        public static EAction GetAction(string value)
        {
            EAction rtn = EAction.None;
            switch (value.ToLower())
            {
                case "s":
                    rtn = EAction.Scaling;
                    break;
                case "r":
                    rtn = EAction.Rotation;
                    break;
                case "p":
                    rtn = EAction.Positioning;
                    break;

                default:
                    break;
            }
            return rtn;
        }
        public static decimal Getdecimal(EAction action, string value)
        {
            decimal rtn = 0;
            switch (action)
            {
                case EAction.Scaling:
                    rtn = GetScaling(value);
                    break;
                case EAction.Rotation:
                    rtn = GetRotation(value);
                    break;
                case EAction.Positioning:
                    rtn = GetPositioning(value);
                    break;

                default:
                    break;
            }
            return rtn;
        }
        public static decimal GetScaling(string value)
        {
            decimal rtn = 1;
            try
            {
                rtn = System.Convert.ToDecimal(value);
            }
            catch
            {

            }
            return rtn;
        }
        public static decimal GetRotation(string value)
        {
            decimal rtn = 0;
            try
            {
                rtn = System.Convert.ToDecimal(value);
            }
            catch
            {

            }
            return rtn;
        }
        public static  decimal GetPositioning(string value)
        {
            return GetRotation(value);
        }
    }


    public enum EBoneType { GlobalBones=1, BodyBones=2, HeadBones=4 }

    public enum EAction { None=0,Scaling = 1, Rotation = 2, Positioning = 3 }

    public enum ESaveBoneSetting {  OnlyChanged, All }

    public struct BoneResource
    {
        public string BoneName { get; set; }
        public string BoneTranslateName { get; set; }
        public string Description { get; set; }

        public BoneResource(string boneName, string boneTranslateName, string description)
        {
            BoneName = boneName;
            BoneTranslateName = boneTranslateName;
            Description = description;
        }

    }
    public class BonesResources {
        public static Dictionary<string, Bone> GlobalBones = new Dictionary<string, Bone>();
        public static Dictionary<string, Bone> BodyBones = new Dictionary<string, Bone>();
        public static Dictionary<string, Bone> HeadBones = new Dictionary<string, Bone>();
        public const string SpiltSymbol = ",";

        public static List<BoneResource> GlobalBonesRecources = new List<BoneResource>()
        {
            new BoneResource("cf_J_ArmLow01_L", "【上肢前臂+腕+手】左","影响【腕+手】左\r\n例如【上肢前臂+腕+手】 x=2 ,则 【腕+手】x=2*2=4"),
            new BoneResource("cf_J_ArmLow01_R", "【上肢前臂+腕+手】右","影响【腕+手】右\r\n例如【上肢前臂+腕+手】 x=2 ,则 【腕+手】x=2*2=4"),
            new BoneResource("cf_J_ArmUp00_L", "【上肢上臂+肘+上肢前臂+腕+手】左","影响【上肢前臂+腕+手】左\r\n例如【上肢上臂+肘+上肢前臂+腕+手】 x=2 ,则 【上肢前臂+腕+手】x=2*2=4"),
            new BoneResource("cf_J_ArmUp00_R", "【上肢上臂+肘+上肢前臂+腕+手】右","影响【上肢前臂+腕+手】右\r\n例如【上肢上臂+肘+上肢前臂+腕+手】 x=2 ,则 【上肢前臂+腕+手】x=2*2=4"),
            new BoneResource("cf_J_Foot01_L", "【脚踝+脚掌】左","影响【脚掌】左\r\n例如【脚踝+脚掌】 x=2 ,则 【脚掌】x=2*2=4"),
            new BoneResource("cf_J_Foot01_R", "【脚踝+脚掌】左","影响【脚掌】右\r\n例如【上肢前臂+腕+手】 x=2 ,则 【腕+手】x=2*2=4"),
            new BoneResource("cf_J_Foot02_L", "【脚掌】左",""),
            new BoneResource("cf_J_Foot02_R", "【脚掌】右",""),
            new BoneResource("cf_J_Hand_L", "【手】左",""),
            new BoneResource("cf_J_Hand_R", "【手】右",""),
            new BoneResource("cf_J_Kosi01", "【小腹+跨+大腿+膝+小腿+脚踝+脚掌】无左右",""),
            new BoneResource("cf_J_Kosi02", "【跨+大腿+膝+小腿+脚踝+脚掌】无左右",""),
            new BoneResource("cf_J_LegKnee_dam_L", "【膝】左",""),
            new BoneResource("cf_J_LegKnee_dam_R", "【膝】右",""),
            new BoneResource("cf_J_LegLow01_L", "【小腿上部+小腿下部+脚踝+脚掌】左",""),
            new BoneResource("cf_J_LegLow01_R", "【小腿上部+小腿下部+脚踝+脚掌】右",""),
            new BoneResource("cf_J_LegLowRoll_L", "【小腿下部+脚踝+脚掌】左",""),
            new BoneResource("cf_J_LegLowRoll_R", "【小腿下部+脚踝+脚掌】右",""),
            new BoneResource("cf_J_LegUp00_L", "【大腿+膝+小腿+脚踝+脚掌】左",""),
            new BoneResource("cf_J_LegUp00_R", "【大腿+膝+小腿+脚踝+脚掌】右",""),
            new BoneResource("cf_J_Shoulder_L", "【肩+上肢上臂+肘+上肢前臂+腕+手】左","影响 【上肢上臂+肘+上肢前臂+腕+手】"),
            new BoneResource("cf_J_Shoulder_R", "【肩+上肢上臂+肘+上肢前臂+腕+手】右","影响 【上肢上臂+肘+上肢前臂+腕+手】"),
            new BoneResource("cf_J_ShoulderIK_L", "【肩+上肢上臂+肘+上肢前臂+腕+手】左","同cf_J_Shoulder_L未发现区别"),
            new BoneResource("cf_J_ShoulderIK_R", "【肩+上肢上臂+肘+上肢前臂+腕+手】右","同cf_J_Shoulder_R未发现区别"),
        };
        public static List<BoneResource> BodyBonesRecources = new List<BoneResource>() { 
            new BoneResource("cf_J_Head_s", "【头】无左右",""),
            new BoneResource("cf_J_Neck_s", "【脖子】",""),
            new BoneResource("cf_J_Shoulder02_s_L", "【肩】左",""),
            new BoneResource("cf_J_Shoulder02_s_R", "【肩】右",""),
            new BoneResource("cf_J_ArmUp01_s_L", "【上肢大臂-靠近肩】左",""),
            new BoneResource("cf_J_ArmUp01_s_R", "【上肢大臂-靠近肩】右",""),
            new BoneResource("cf_J_ArmUp02_s_L", "【上肢大臂-肩肘之间】左",""),
            new BoneResource("cf_J_ArmUp02_s_R", "【上肢大臂-肩肘之间】右",""),
            new BoneResource("cf_J_ArmUp03_s_L", "【上肢大臂-靠近肘】左",""),
            new BoneResource("cf_J_ArmUp03_s_R", "【上肢大臂-靠近肘】右",""),
            new BoneResource("cf_J_ArmElbo_low_s_L", "【肘】左",""),
            new BoneResource("cf_J_ArmElbo_low_s_R", "【肘】右",""),
            new BoneResource("cf_J_ArmLow01_s_L", "【上肢小臂-靠近肘】左",""),
            new BoneResource("cf_J_ArmLow01_s_R", "【上肢小臂-靠近肘】右",""),
            new BoneResource("cf_J_ArmLow02_s_L", "【上肢小臂-靠近腕】左",""),
            new BoneResource("cf_J_ArmLow02_s_R", "【上肢小臂-靠近腕】右",""),
            new BoneResource("cf_J_Hand_Wrist_s_L", "【腕】左",""),
            new BoneResource("cf_J_Hand_Wrist_s_R", "【腕】右",""),
            new BoneResource("cf_J_Hand_s_L", "【手】左",""),
            new BoneResource("cf_J_Hand_s_R", "【手】右",""),

            new BoneResource("cf_J_Mune_Nip01_s_L", "【乳头-上】左",""),
            new BoneResource("cf_J_Mune_Nip01_s_R", "【乳头-上】右",""),
            new BoneResource("cf_J_Mune_Nip02_s_L", "【乳头-下】左","影响【乳头-上】左"),
            new BoneResource("cf_J_Mune_Nip02_s_R", "【乳头-下】右","影响【乳头-上】右"),
            new BoneResource("cf_J_Mune_Nipacs01_L", "【乳头饰品】左","无乳头饰品，无效果"),
            new BoneResource("cf_J_Mune_Nipacs01_R", "【乳头饰品】右","无乳头饰品，无效果"),


            new BoneResource("cf_J_Spine03_s", "【胸腔】",""),
            new BoneResource("cf_J_Spine02_s", "【腰】",""),
            new BoneResource("cf_J_Spine01_s", "【上腹】",""),
            new BoneResource("cf_J_Kosi01_s", "【下腹】",""),
            new BoneResource("cf_J_Kosi02_s", "【跨】",""),
            new BoneResource("cf_J_LegUpDam_s_L", "【盆骨】左","比【跨】略低的位置，分左右"),
            new BoneResource("cf_J_LegUpDam_s_R", "【盆骨】右","比【跨】略低的位置，分左右"),
            new BoneResource("cf_J_Siri_s_L", "【臀】左","指身后的屁股，前面无效果"),
            new BoneResource("cf_J_Siri_s_R", "【臀】右","指身后的屁股，前面无效果"),

            new BoneResource("cf_J_LegUp01_s_L", "【大腿-靠近臀】左",""),
            new BoneResource("cf_J_LegUp01_s_R", "【大腿-靠近臀】右",""),
            new BoneResource("cf_J_LegUp02_s_L", "【大腿-臀膝之间】左",""),
            new BoneResource("cf_J_LegUp02_s_R", "【大腿-臀膝之间】右",""),
            new BoneResource("cf_J_LegUp03_s_L", "【大腿-靠近膝】左",""),
            new BoneResource("cf_J_LegUp03_s_R", "【大腿-靠近膝】左",""),

            new BoneResource("cf_J_LegKnee_back_s_L", "【膝-后】左",""),
            new BoneResource("cf_J_LegKnee_back_s_R", "【膝-后】右",""),
            new BoneResource("cf_J_LegKnee_low_s_L", "【膝-前】左",""),
            new BoneResource("cf_J_LegKnee_low_s_R", "【膝-前】右",""),
            new BoneResource("cf_J_LegLow01_s_L", "【小腿-靠近膝】左",""),
            new BoneResource("cf_J_LegLow01_s_R", "【小腿-靠近膝】右",""),
            new BoneResource("cf_J_LegLow02_s_L", "【小腿-膝踝之间】左",""),
            new BoneResource("cf_J_LegLow02_s_R", "【小腿-膝踝之间】右",""),
            new BoneResource("cf_J_LegLow03_s_L", "【小腿-靠近踝】左",""),
            new BoneResource("cf_J_LegLow03_s_R", "【小腿-靠近踝】右",""),



            new BoneResource("cf_N_height", "【身高】","整体，控制身体所有骨骼"),
            new BoneResource("cf_J_sk_siri_dam", "【裙子后摆】","需穿裙子才能看到效果"),
            new BoneResource("cf_J_sk_top", "【裙子】","可控制裙子前后左右，所有布料,需穿裙子才能看到效果。"),
            new BoneResource("cf_J_sk_00_00_dam", "【裙摆+正前】","控制裙子布料。需穿裙子方能看到效果。"),
            new BoneResource("cf_J_sk_01_00_dam", "【裙摆+右前】","控制裙子布料。需穿裙子方能看到效果。"),
            new BoneResource("cf_J_sk_02_00_dam", "【裙摆+右】","控制裙子布料。需穿裙子方能看到效果。"),
            new BoneResource("cf_J_sk_03_00_dam", "【裙摆+右后】","控制裙子布料。需穿裙子方能看到效果。"),
            new BoneResource("cf_J_sk_04_00_dam", "【裙摆+正后】","控制裙子布料。需穿裙子方能看到效果。"),
            new BoneResource("cf_J_sk_05_00_dam", "【裙摆+左后】","控制裙子布料。需穿裙子方能看到效果。"),
            new BoneResource("cf_J_sk_06_00_dam", "【裙摆+左】","控制裙子布料。需穿裙子方能看到效果。"),
            new BoneResource("cf_J_sk_07_00_dam", "【裙摆+左前】","控制裙子布料。需穿裙子方能看到效果。"),
            new BoneResource("cf_hit_Mune02_s_L", "【风-胸】左","在左胸形成一个圆形的风，当x,y,z调大时，头发，裙子等会随风飘扬。"),
            new BoneResource("cf_hit_Mune02_s_R", "【风-胸】右","在右胸形成一个圆形的风，当x,y,z调大时，头发，裙子等会随风飘扬。"),
            new BoneResource("cf_hit_Kosi02_s", "【风-胯】","在阴部形成风，当x,y,z调大时，头发，裙子等会随风飘扬。"),
            new BoneResource("cf_hit_LegUp01_s_L", "【风-腿】左","在左腿形成风，，当x,y,z调大时，头发，裙子等会随风飘扬。"),
            new BoneResource("cf_hit_LegUp01_s_R", "【风-腿】右","在右腿形成风，，当x,y,z调大时，头发，裙子等会随风飘扬。"),
            new BoneResource("cf_hit_Siri_s_L", "【风-臀】左","在左屁股形成风，，当x,y,z调大时，头发，裙子等会随风飘扬。"),
            new BoneResource("cf_hit_Siri_s_R", "【风-臀】右","在右屁股形成风，，当x,y,z调大时，头发，裙子等会随风飘扬。"),

            new BoneResource("cf_J_Mune00_d_L", "【乳房-0层-D】左","D层位于T,S层上。D层的旋转，尺寸变化，不影响T,S层，但影响1,2,3,4层"),
            new BoneResource("cf_J_Mune00_d_R", "【乳房-0层-D】右","D层位于T,S层上。D层的旋转，尺寸变化，不影响T,S层，但影响1,2,3,4层"),
            new BoneResource("cf_J_Mune00_s_L", "【乳房-0层-S】左","基于自身层，进行旋转，放大缩小等，不影响1,2,3,4层"),
            new BoneResource("cf_J_Mune00_s_R", "【乳房-0层-S】右","基于自身层，进行旋转，放大缩小等，不影响1,2,3,4层"),
            new BoneResource("cf_J_Mune00_t_L", "【乳房-0层-T】左","cf_J_Mune00_t 影响整个cf_J_Mune00层。影响D层及1,2,3,4层。\r\n换句话说，T层变化点在0层的最低点，而S层变化点在0层的中间。"),
            new BoneResource("cf_J_Mune00_t_R", "【乳房-0层-T】右","cf_J_Mune00_t 影响整个cf_J_Mune00层。影响D层及1,2,3,4层。\r\n换句话说，T层变化点在0层的最低点，而S层变化点在0层的中间。"),

            new BoneResource("cf_J_Mune01_s_L", "【乳房-1层-S】 左","受0层影响，但是不影响2,3,4层。"),
            new BoneResource("cf_J_Mune01_s_R", "【乳房-1层-S】 右","受0层影响，但是不影响2,3,4层。"),
            new BoneResource("cf_J_Mune01_t_L", "【乳房-1层-T】 左","cf_J_Mune01_t 影响整个cf_J_Mune01层。影响2,3,4层。\r\n换句话说，T层变化点在1层的最低点，而S层变化点在1层的中间。"),
            new BoneResource("cf_J_Mune01_t_R", "【乳房-1层-T】 右","cf_J_Mune01_t 影响整个cf_J_Mune01层。影响2,3,4层。\r\n换句话说，T层变化点在1层的最低点，而S层变化点在1层的中间。"),

            new BoneResource("cf_J_Mune02_s_L", "【乳房-2层-S】左","受0，1层影响，但是不影响3,4层。"),
            new BoneResource("cf_J_Mune02_s_R", "【乳房-2层-S】右","受0，1层影响，但是不影响3,4层。"),
            new BoneResource("cf_J_Mune02_t_L", "【乳房-2层-T】左","cf_J_Mune02_t 影响整个cf_J_Mune02层。影响3,4层。\r\n换句话说，T层变化点在2层的最低点，而S层变化点在2层的中间。"),
            new BoneResource("cf_J_Mune02_t_R", "【乳房-2层-T】右","cf_J_Mune02_t 影响整个cf_J_Mune02层。影响3,4层。\r\n换句话说，T层变化点在2层的最低点，而S层变化点在2层的中间。"),

            new BoneResource("cf_J_Mune03_s_L", "【乳晕-下部】左","受0，1，2层影响，影响4层。"),
            new BoneResource("cf_J_Mune03_s_R", "【乳晕-下部】右","受0，1，2层影响，影响4层。"),
            new BoneResource("cf_J_Mune04_s_L", "【乳晕-上部】左","受0，1，2，3层影响"),
            new BoneResource("cf_J_Mune04_s_R", "【乳晕-上部】右","受0，1，2，3层影响")
        };
        public static List<BoneResource> HeadBonesRecources = new List<BoneResource>() {
            new BoneResource("cf_J_CheekLow_L", "",""),
            new BoneResource("cf_J_CheekLow_R", "",""),
            new BoneResource("cf_J_CheekUp_L", "",""),
            new BoneResource("cf_J_CheekUp_R", "",""),
            new BoneResource("cf_J_Chin_rs", "【下颚+下巴】",""),
            new BoneResource("cf_J_ChinLow", "【下颚】",""),
            new BoneResource("cf_J_ChinTip_s", "【下巴】",""),
            new BoneResource("cf_J_EarBase_s_L", "",""),
            new BoneResource("cf_J_EarBase_s_R", "",""),
            new BoneResource("cf_J_EarLow_L", "",""),
            new BoneResource("cf_J_EarLow_R", "",""),
            new BoneResource("cf_J_EarRing_L", "",""),
            new BoneResource("cf_J_EarRing_R", "",""),
            new BoneResource("cf_J_EarUp_L", "",""),
            new BoneResource("cf_J_EarUp_R", "",""),
            new BoneResource("cf_J_Eye_r_L", "",""),
            new BoneResource("cf_J_Eye_r_R", "",""),
            new BoneResource("cf_J_eye_rs_L", "",""),
            new BoneResource("cf_J_eye_rs_R", "",""),
            new BoneResource("cf_J_Eye_s_L", "",""),
            new BoneResource("cf_J_Eye_s_R", "",""),
            new BoneResource("cf_J_Eye_t_L", "",""),
            new BoneResource("cf_J_Eye_t_R", "",""),
            new BoneResource("cf_J_Eye01_L", "",""),
            new BoneResource("cf_J_Eye01_R", "",""),
            new BoneResource("cf_J_Eye02_L", "",""),
            new BoneResource("cf_J_Eye02_R", "",""),
            new BoneResource("cf_J_Eye03_L", "",""),
            new BoneResource("cf_J_Eye03_R", "",""),
            new BoneResource("cf_J_Eye04_L", "",""),
            new BoneResource("cf_J_Eye04_R", "",""),
            new BoneResource("cf_J_EyePos_rz_L", "",""),
            new BoneResource("cf_J_EyePos_rz_R", "",""),
            new BoneResource("cf_J_FaceBase", "",""),
            new BoneResource("cf_J_FaceLow_s", "",""),
            new BoneResource("cf_J_FaceLowBase", "",""),
            new BoneResource("cf_J_FaceUp_ty", "",""),
            new BoneResource("cf_J_FaceUp_tz", "",""),
            new BoneResource("cf_J_Mayu_L", "【眉毛】左",""),
            new BoneResource("cf_J_Mayu_R", "【眉毛】右",""),
            new BoneResource("cf_J_MayuMid_s_L", "",""),
            new BoneResource("cf_J_MayuMid_s_R", "",""),
            new BoneResource("cf_J_MayuTip_s_L", "",""),
            new BoneResource("cf_J_MayuTip_s_R", "",""),
            new BoneResource("cf_J_megane", "",""),
            new BoneResource("cf_J_Mouth_L", "",""),
            new BoneResource("cf_J_Mouth_R", "",""),
            new BoneResource("cf_J_MouthBase_s", "",""),
            new BoneResource("cf_J_MouthBase_tr", "",""),
            new BoneResource("cf_J_MouthCavity", "【上下牙冠】含舌头","长舌：口类型30，s比例0.8,1,1.4"),
            new BoneResource("cf_J_MouthLow", "",""),
            new BoneResource("cf_J_Mouthup", "",""),
            new BoneResource("cf_J_Nose_t", "",""),
            new BoneResource("cf_J_Nose_tip", "",""),
            new BoneResource("cf_J_NoseBase_s", "",""),
            new BoneResource("cf_J_NoseBase_trs", "",""),
            new BoneResource("cf_J_NoseBridge_s", "",""),
            new BoneResource("cf_J_NoseBridge_t", "",""),
            new BoneResource("cf_J_NoseWing_tx_L", "",""),
            new BoneResource("cf_J_NoseWing_tx_R", "",""),
            new BoneResource("cf_J_pupil_s_L", "【黑眼球】左",""),
            new BoneResource("cf_J_pupil_s_R", "【黑眼球】右","")
        };

        public static string GetMaxBoneName()
        {
            string rtn = "";
            List<string> Keys = GlobalBones.Keys.Concat(BodyBones.Keys.Concat(HeadBones.Keys)).ToList<string>();
            int max = Keys.Max<string>(p=>p.Length);
            rtn = Keys.First<string>(p => p.Length == max);
            return rtn;
        }
        public static string GetMaxBoneTranslateName()
        {
            string rtn = "";
            List<Bone> Values = GlobalBones.Values.Concat(BodyBones.Values.Concat(HeadBones.Values)).ToList();
            int max = Values.Max<Bone>(p => p.BoneTranslateName.Length);
            rtn = Values.First<Bone>(p => p.BoneTranslateName.Length == max).BoneTranslateName;
            return rtn;
        }
        static BonesResources()
        {
            foreach(BoneResource  source in GlobalBonesRecources)
            {
                GlobalBones.Add(source.BoneName,new Bone(EBoneType.GlobalBones,source.BoneName,source.BoneTranslateName,source.Description));
            }
            foreach (BoneResource source in BodyBonesRecources)
            {
                BodyBones.Add(source.BoneName, new Bone(EBoneType.BodyBones, source.BoneName, source.BoneTranslateName, source.Description));
            }
            foreach (BoneResource source in HeadBonesRecources)
            {
                HeadBones.Add(source.BoneName, new Bone(EBoneType.HeadBones, source.BoneName, source.BoneTranslateName, source.Description));
            }

            //BonesResources.GlobalBones.Add("cf_J_ArmLow01_L", new Bone(EBoneType.GlobalBones, "cf_J_ArmLow01_L", "【上肢前臂+腕+手】左", "影响【腕+手】左\r\n例如【上肢前臂+腕+手】 x=2 ,则 【腕+手】x=2*2=4 "));
            //BonesResources.GlobalBones.Add("cf_J_ArmLow01_R", new Bone(EBoneType.GlobalBones, "cf_J_ArmLow01_R", "【上肢前臂+腕+手】右", "影响【腕+手】右\r\n例如【上肢前臂+腕+手】 x=2 ,则 【腕+手】x=2*2=4 "));
            //BonesResources.GlobalBones.Add("cf_J_ArmUp00_L", new Bone(EBoneType.GlobalBones, "cf_J_ArmUp00_L", "【上肢上臂+肘+上肢前臂+腕+手】左", "影响【上肢前臂+腕+手】左\r\n例如【上肢上臂+肘+上肢前臂+腕+手】 x=2 ,则 【上肢前臂+腕+手】x=2*2=4"));
            //BonesResources.GlobalBones.Add("cf_J_ArmUp00_R", new Bone(EBoneType.GlobalBones, "cf_J_ArmUp00_R", "【上肢上臂+肘+上肢前臂+腕+手】右", " 影响【上肢前臂+腕+手】右\r\n例如【上肢上臂+肘+上肢前臂+腕+手】 x=2 ,则 【上肢前臂+腕+手】x=2*2=4"));
            //BonesResources.GlobalBones.Add("cf_J_Foot01_L", new Bone(EBoneType.GlobalBones, "cf_J_Foot01_L", "【脚踝+脚掌】左 ", "影响【脚掌】左\r\n例如【脚踝+脚掌】 x=2 ,则 【脚掌】x=2*2=4"));
            //BonesResources.GlobalBones.Add("cf_J_Foot01_R", new Bone(EBoneType.GlobalBones, "cf_J_Foot01_R", "【脚踝+脚掌】左 ", "影响【脚掌】右\r\n例如【上肢前臂+腕+手】 x=2 ,则 【腕+手】x=2*2=4 "));
            //BonesResources.GlobalBones.Add("cf_J_Foot02_L", new Bone(EBoneType.GlobalBones, "cf_J_Foot02_L", "【脚掌】左", ""));
            //BonesResources.GlobalBones.Add("cf_J_Foot02_R", new Bone(EBoneType.GlobalBones, "cf_J_Foot02_R", "【脚掌】右", ""));
            //BonesResources.GlobalBones.Add("cf_J_Hand_L", new Bone(EBoneType.GlobalBones, "cf_J_Hand_L", "【手】左", ""));
            //BonesResources.GlobalBones.Add("cf_J_Hand_R", new Bone(EBoneType.GlobalBones, "cf_J_Hand_R", "【手】右", ""));
            //BonesResources.GlobalBones.Add("cf_J_Kosi01", new Bone(EBoneType.GlobalBones, "cf_J_Kosi01", "【小腹+跨+大腿+膝+小腿+脚踝+脚掌】无左右", ""));
            //BonesResources.GlobalBones.Add("cf_J_Kosi02", new Bone(EBoneType.GlobalBones, "cf_J_Kosi02", "【跨+大腿+膝+小腿+脚踝+脚掌】无左右", ""));
            //BonesResources.GlobalBones.Add("cf_J_LegKnee_dam_L", new Bone(EBoneType.GlobalBones, "cf_J_LegKnee_dam_L", "【膝】左", ""));
            //BonesResources.GlobalBones.Add("cf_J_LegKnee_dam_R", new Bone(EBoneType.GlobalBones, "cf_J_LegKnee_dam_R", "【膝】右", ""));
            //BonesResources.GlobalBones.Add("cf_J_LegLow01_L", new Bone(EBoneType.GlobalBones, "cf_J_LegLow01_L", "【小腿上部+小腿下部+脚踝+脚掌】左",""));
            //BonesResources.GlobalBones.Add("cf_J_LegLow01_R", new Bone(EBoneType.GlobalBones, "cf_J_LegLow01_R", "【小腿上部+小腿下部+脚踝+脚掌】右",""));
            //BonesResources.GlobalBones.Add("cf_J_LegLowRoll_L", new Bone(EBoneType.GlobalBones, "cf_J_LegLowRoll_L", "【小腿下部+脚踝+脚掌】左",""));
            //BonesResources.GlobalBones.Add("cf_J_LegLowRoll_R", new Bone(EBoneType.GlobalBones, "cf_J_LegLowRoll_R", "【小腿下部+脚踝+脚掌】右", ""));
            //BonesResources.GlobalBones.Add("cf_J_LegUp00_L", new Bone(EBoneType.GlobalBones, "cf_J_LegUp00_L", "【大腿+膝+小腿+脚踝+脚掌】左", ""));
            //BonesResources.GlobalBones.Add("cf_J_LegUp00_R", new Bone(EBoneType.GlobalBones, "cf_J_LegUp00_R", "【大腿+膝+小腿+脚踝+脚掌】右", ""));
            //BonesResources.GlobalBones.Add("cf_J_Shoulder_L", new Bone(EBoneType.GlobalBones, "cf_J_Shoulder_L", "【肩+上肢上臂+肘+上肢前臂+腕+手】左", "影响 【上肢上臂+肘+上肢前臂+腕+手】"));
            //BonesResources.GlobalBones.Add("cf_J_Shoulder_R", new Bone(EBoneType.GlobalBones, "cf_J_Shoulder_R", "【肩+上肢上臂+肘+上肢前臂+腕+手】右", "影响 【上肢上臂+肘+上肢前臂+腕+手】"));
            //BonesResources.GlobalBones.Add("cf_J_ShoulderIK_L", new Bone(EBoneType.GlobalBones, "cf_J_ShoulderIK_L", "【肩+上肢上臂+肘+上肢前臂+腕+手】左", "同cf_J_Shoulder_L未发现区别"));
            //BonesResources.GlobalBones.Add("cf_J_ShoulderIK_R", new Bone(EBoneType.GlobalBones, "cf_J_ShoulderIK_R", "【肩+上肢上臂+肘+上肢前臂+腕+手】右", "同cf_J_Shoulder_R未发现区别"));

            //BodyBones.Add("cf_J_Head_s", new Bone(EBoneType.BodyBones, "cf_J_Head_s", "【头】无左右", ""));
            //BodyBones.Add("cf_J_Neck_s", new Bone(EBoneType.BodyBones, "cf_J_Neck_s", "【脖子】", ""));
            //BodyBones.Add("cf_J_Shoulder02_s_L", new Bone(EBoneType.BodyBones, "cf_J_Shoulder02_s_L", "【肩】左", ""));
            //BodyBones.Add("cf_J_Shoulder02_s_R", new Bone(EBoneType.BodyBones, "cf_J_Shoulder02_s_R", "【肩】右", ""));
            //BodyBones.Add("cf_J_ArmUp01_s_L", new Bone(EBoneType.BodyBones, "cf_J_ArmUp01_s_L", "【上肢大臂-靠近肩】左", ""));
            //BodyBones.Add("cf_J_ArmUp01_s_R", new Bone(EBoneType.BodyBones, "cf_J_ArmUp01_s_R", "【上肢大臂-靠近肩】右", ""));
            //BodyBones.Add("cf_J_ArmUp02_s_L", new Bone(EBoneType.BodyBones, "cf_J_ArmUp02_s_L", "【上肢大臂-肩肘之间】左", ""));
            //BodyBones.Add("cf_J_ArmUp02_s_R", new Bone(EBoneType.BodyBones, "cf_J_ArmUp02_s_R", "【上肢大臂-肩肘之间】右", ""));
            //BodyBones.Add("cf_J_ArmUp03_s_L", new Bone(EBoneType.BodyBones, "cf_J_ArmUp03_s_L", "【上肢大臂-靠近肘】左", ""));
            //BodyBones.Add("cf_J_ArmUp03_s_R", new Bone(EBoneType.BodyBones, "cf_J_ArmUp03_s_R", "【上肢大臂-靠近肘】右", ""));
            //BodyBones.Add("cf_J_ArmElbo_low_s_L", new Bone(EBoneType.BodyBones, "cf_J_ArmElbo_low_s_L", "【肘】左", ""));
            //BodyBones.Add("cf_J_ArmElbo_low_s_R", new Bone(EBoneType.BodyBones, "cf_J_ArmElbo_low_s_R", "【肘】右", ""));
            //BodyBones.Add("cf_J_ArmLow01_s_L", new Bone(EBoneType.BodyBones, "cf_J_ArmLow01_s_L", "【上肢小臂-靠近肘】左", ""));
            //BodyBones.Add("cf_J_ArmLow01_s_R", new Bone(EBoneType.BodyBones, "cf_J_ArmLow01_s_R", "【上肢小臂-靠近肘】右", ""));
            //BodyBones.Add("cf_J_ArmLow02_s_L", new Bone(EBoneType.BodyBones, "cf_J_ArmLow02_s_L", "【上肢小臂-靠近腕】左", ""));
            //BodyBones.Add("cf_J_ArmLow02_s_R", new Bone(EBoneType.BodyBones, "cf_J_ArmLow02_s_R", "【上肢小臂-靠近腕】右", ""));
            //BodyBones.Add("cf_J_Hand_Wrist_s_L", new Bone(EBoneType.BodyBones, "cf_J_Hand_Wrist_s_L", "【腕】左", ""));
            //BodyBones.Add("cf_J_Hand_Wrist_s_R", new Bone(EBoneType.BodyBones, "cf_J_Hand_Wrist_s_R", "【腕】右", ""));
            //BodyBones.Add("cf_J_Hand_s_L", new Bone(EBoneType.BodyBones, "cf_J_Hand_s_L", "【手】左", ""));
            //BodyBones.Add("cf_J_Hand_s_R", new Bone(EBoneType.BodyBones, "cf_J_Hand_s_R", "【手】右", ""));

            //BodyBones.Add("cf_J_Mune_Nip01_s_L", new Bone(EBoneType.BodyBones, "cf_J_Mune_Nip01_s_L", "【乳头-上】左", ""));
            //BodyBones.Add("cf_J_Mune_Nip01_s_R", new Bone(EBoneType.BodyBones, "cf_J_Mune_Nip01_s_R", "【乳头-上】右", ""));
            //BodyBones.Add("cf_J_Mune_Nip02_s_L", new Bone(EBoneType.BodyBones, "cf_J_Mune_Nip02_s_L", "【乳头-下】左", "影响【乳头-上】左"));
            //BodyBones.Add("cf_J_Mune_Nip02_s_R", new Bone(EBoneType.BodyBones, "cf_J_Mune_Nip02_s_R", "【乳头-下】右", "影响【乳头-上】右"));
            //BodyBones.Add("cf_J_Mune_Nipacs01_L", new Bone(EBoneType.BodyBones, "cf_J_Mune_Nipacs01_L", "【乳头饰品】左", "无乳头饰品，无效果"));
            //BodyBones.Add("cf_J_Mune_Nipacs01_R", new Bone(EBoneType.BodyBones, "cf_J_Mune_Nipacs01_R", "【乳头饰品】右", "无乳头饰品，无效果"));


            //BodyBones.Add("cf_J_Spine03_s", new Bone(EBoneType.BodyBones, "cf_J_Spine03_s", "【胸腔】", ""));
            //BodyBones.Add("cf_J_Spine02_s", new Bone(EBoneType.BodyBones, "cf_J_Spine02_s", "【腰】", ""));
            //BodyBones.Add("cf_J_Spine01_s", new Bone(EBoneType.BodyBones, "cf_J_Spine01_s", "【上腹】", ""));
            //BodyBones.Add("cf_J_Kosi01_s", new Bone(EBoneType.BodyBones, "cf_J_Kosi01_s", "【下腹】", ""));
            //BodyBones.Add("cf_J_Kosi02_s", new Bone(EBoneType.BodyBones, "cf_J_Kosi02_s", "【跨】", ""));
            //BodyBones.Add("cf_J_LegUpDam_s_L", new Bone(EBoneType.BodyBones, "cf_J_LegUpDam_s_L", "【盆骨】左", "比【跨】略低的位置，分左右"));
            //BodyBones.Add("cf_J_LegUpDam_s_R", new Bone(EBoneType.BodyBones, "cf_J_LegUpDam_s_R", "【盆骨】右", "比【跨】略低的位置，分左右"));
            //BodyBones.Add("cf_J_Siri_s_L", new Bone(EBoneType.BodyBones, "cf_J_Siri_s_L", "【臀】左", "指身后的屁股，前面无效果"));
            //BodyBones.Add("cf_J_Siri_s_R", new Bone(EBoneType.BodyBones, "cf_J_Siri_s_R", "【臀】右", "指身后的屁股，前面无效果"));

            //BodyBones.Add("cf_J_LegUp01_s_L", new Bone(EBoneType.BodyBones, "cf_J_LegUp01_s_L", "【大腿-靠近臀】左", ""));
            //BodyBones.Add("cf_J_LegUp01_s_R", new Bone(EBoneType.BodyBones, "cf_J_LegUp01_s_R", "【大腿-靠近臀】右", ""));
            //BodyBones.Add("cf_J_LegUp02_s_L", new Bone(EBoneType.BodyBones, "cf_J_LegUp02_s_L", "【大腿-臀膝之间】左", ""));
            //BodyBones.Add("cf_J_LegUp02_s_R", new Bone(EBoneType.BodyBones, "cf_J_LegUp02_s_R", "【大腿-臀膝之间】右", ""));
            //BodyBones.Add("cf_J_LegUp03_s_L", new Bone(EBoneType.BodyBones, "cf_J_LegUp03_s_L", "【大腿-靠近膝】左", ""));
            //BodyBones.Add("cf_J_LegUp03_s_R", new Bone(EBoneType.BodyBones, "cf_J_LegUp03_s_R", "【大腿-靠近膝】左", ""));

            //BodyBones.Add("cf_J_LegKnee_back_s_L", new Bone(EBoneType.BodyBones, "cf_J_LegKnee_back_s_L", "【膝-后】左", ""));
            //BodyBones.Add("cf_J_LegKnee_back_s_R", new Bone(EBoneType.BodyBones, "cf_J_LegKnee_back_s_R", "【膝-后】右", ""));
            //BodyBones.Add("cf_J_LegKnee_low_s_L", new Bone(EBoneType.BodyBones, "cf_J_LegKnee_low_s_L", "【膝-前】左", ""));
            //BodyBones.Add("cf_J_LegKnee_low_s_R", new Bone(EBoneType.BodyBones, "cf_J_LegKnee_low_s_R", "【膝-前】右", ""));
            //BodyBones.Add("cf_J_LegLow01_s_L", new Bone(EBoneType.BodyBones, "cf_J_LegLow01_s_L", "【小腿-靠近膝】左", ""));
            //BodyBones.Add("cf_J_LegLow01_s_R", new Bone(EBoneType.BodyBones, "cf_J_LegLow01_s_R", "【小腿-靠近膝】右", ""));
            //BodyBones.Add("cf_J_LegLow02_s_L", new Bone(EBoneType.BodyBones, "cf_J_LegLow02_s_L", "【小腿-膝踝之间】左", ""));
            //BodyBones.Add("cf_J_LegLow02_s_R", new Bone(EBoneType.BodyBones, "cf_J_LegLow02_s_R", "【小腿-膝踝之间】右", ""));
            //BodyBones.Add("cf_J_LegLow03_s_L", new Bone(EBoneType.BodyBones, "cf_J_LegLow03_s_L", "【小腿-靠近踝】左", ""));
            //BodyBones.Add("cf_J_LegLow03_s_R", new Bone(EBoneType.BodyBones, "cf_J_LegLow03_s_R", "【小腿-靠近踝】右", ""));



            //BodyBones.Add("cf_N_height", new Bone(EBoneType.BodyBones, "cf_N_height", "【身高】", "整体，控制身体所有骨骼"));
            //BodyBones.Add("cf_J_sk_siri_dam", new Bone(EBoneType.BodyBones, "cf_J_sk_siri_dam", "【裙子后摆】", "需穿裙子才能看到效果"));
            //BodyBones.Add("cf_J_sk_top", new Bone(EBoneType.BodyBones, "cf_J_sk_top", "【裙子】", "可控制裙子前后左右，所有布料,需穿裙子才能看到效果。"));
            //BodyBones.Add("cf_J_sk_00_00_dam", new Bone(EBoneType.BodyBones, "cf_J_sk_00_00_dam", "【裙摆+正前】", "控制裙子布料。需穿裙子方能看到效果。"));
            //BodyBones.Add("cf_J_sk_01_00_dam", new Bone(EBoneType.BodyBones, "cf_J_sk_01_00_dam", "【裙摆+右前】", "控制裙子布料。需穿裙子方能看到效果。"));
            //BodyBones.Add("cf_J_sk_02_00_dam", new Bone(EBoneType.BodyBones, "cf_J_sk_02_00_dam", "【裙摆+右】", "控制裙子布料。需穿裙子方能看到效果。"));
            //BodyBones.Add("cf_J_sk_03_00_dam", new Bone(EBoneType.BodyBones, "cf_J_sk_03_00_dam", "【裙摆+右后】", "控制裙子布料。需穿裙子方能看到效果。"));
            //BodyBones.Add("cf_J_sk_04_00_dam", new Bone(EBoneType.BodyBones, "cf_J_sk_04_00_dam", "【裙摆+正后】", "控制裙子布料。需穿裙子方能看到效果。"));
            //BodyBones.Add("cf_J_sk_05_00_dam", new Bone(EBoneType.BodyBones, "cf_J_sk_05_00_dam", "【裙摆+左后】", "控制裙子布料。需穿裙子方能看到效果。"));
            //BodyBones.Add("cf_J_sk_06_00_dam", new Bone(EBoneType.BodyBones, "cf_J_sk_06_00_dam", "【裙摆+左】", "控制裙子布料。需穿裙子方能看到效果。"));
            //BodyBones.Add("cf_J_sk_07_00_dam", new Bone(EBoneType.BodyBones, "cf_J_sk_07_00_dam", "【裙摆+左前】", "控制裙子布料。需穿裙子方能看到效果。"));
            //BodyBones.Add("cf_hit_Mune02_s_L", new Bone(EBoneType.BodyBones, "cf_hit_Mune02_s_L", "【风-胸】左", "在左胸形成一个圆形的风，当x,y,z调大时，头发，裙子等会随风飘扬。"));
            //BodyBones.Add("cf_hit_Mune02_s_R", new Bone(EBoneType.BodyBones, "cf_hit_Mune02_s_R", "【风-胸】右", "在右胸形成一个圆形的风，当x,y,z调大时，头发，裙子等会随风飘扬。"));
            //BodyBones.Add("cf_hit_Kosi02_s", new Bone(EBoneType.BodyBones, "cf_hit_Kosi02_s", "【风-胯】", "在阴部形成风，当x,y,z调大时，头发，裙子等会随风飘扬。"));
            //BodyBones.Add("cf_hit_LegUp01_s_L", new Bone(EBoneType.BodyBones, "cf_hit_LegUp01_s_L", "【风-腿】左", "在左腿形成风，，当x,y,z调大时，头发，裙子等会随风飘扬。"));
            //BodyBones.Add("cf_hit_LegUp01_s_R", new Bone(EBoneType.BodyBones, "cf_hit_LegUp01_s_R", "【风-腿】右", "在右腿形成风，，当x,y,z调大时，头发，裙子等会随风飘扬。"));
            //BodyBones.Add("cf_hit_Siri_s_L", new Bone(EBoneType.BodyBones, "cf_hit_Siri_s_L", "【风-臀】左", "在左屁股形成风，，当x,y,z调大时，头发，裙子等会随风飘扬。"));
            //BodyBones.Add("cf_hit_Siri_s_R", new Bone(EBoneType.BodyBones, "cf_hit_Siri_s_R", "【风-臀】右", "在右屁股形成风，，当x,y,z调大时，头发，裙子等会随风飘扬。"));

            //BodyBones.Add("cf_J_Mune00_d_L", new Bone(EBoneType.BodyBones, "cf_J_Mune00_d_L", "【乳房-0层-D】左", "D层位于T,S层上。D层的旋转，尺寸变化，不影响T,S层，但影响1,2,3,4层"));
            //BodyBones.Add("cf_J_Mune00_d_R", new Bone(EBoneType.BodyBones, "cf_J_Mune00_d_R", "【乳房-0层-D】右", "D层位于T,S层上。D层的旋转，尺寸变化，不影响T,S层，但影响1,2,3,4层"));
            //BodyBones.Add("cf_J_Mune00_s_L", new Bone(EBoneType.BodyBones, "cf_J_Mune00_s_L", "【乳房-0层-S】左", "基于自身层，进行旋转，放大缩小等，不影响1,2,3,4层"));
            //BodyBones.Add("cf_J_Mune00_s_R", new Bone(EBoneType.BodyBones, "cf_J_Mune00_s_R", "【乳房-0层-S】右", "基于自身层，进行旋转，放大缩小等，不影响1,2,3,4层"));
            //BodyBones.Add("cf_J_Mune00_t_L", new Bone(EBoneType.BodyBones, "cf_J_Mune00_t_L", "【乳房-0层-T】左", "cf_J_Mune00_t 影响整个cf_J_Mune00层。影响D层及1,2,3,4层。\r\n换句话说，T层变化点在0层的最低点，而S层变化点在0层的中间。"));
            //BodyBones.Add("cf_J_Mune00_t_R", new Bone(EBoneType.BodyBones, "cf_J_Mune00_t_R", "【乳房-0层-T】右", "cf_J_Mune00_t 影响整个cf_J_Mune00层。影响D层及1,2,3,4层。\r\n换句话说，T层变化点在0层的最低点，而S层变化点在0层的中间。"));


            //BodyBones.Add("cf_J_Mune01_s_L", new Bone(EBoneType.BodyBones, "cf_J_Mune01_s_L", "【乳房-1层-S】 左", "受0层影响，但是不影响2,3,4层。"));
            //BodyBones.Add("cf_J_Mune01_s_R", new Bone(EBoneType.BodyBones, "cf_J_Mune01_s_R", "【乳房-1层-S】 右", "受0层影响，但是不影响2,3,4层。"));
            //BodyBones.Add("cf_J_Mune01_t_L", new Bone(EBoneType.BodyBones, "cf_J_Mune01_t_L", "【乳房-1层-T】 左", "cf_J_Mune01_t 影响整个cf_J_Mune01层。影响2,3,4层。\r\n换句话说，T层变化点在1层的最低点，而S层变化点在1层的中间。"));
            //BodyBones.Add("cf_J_Mune01_t_R", new Bone(EBoneType.BodyBones, "cf_J_Mune01_t_R", "【乳房-1层-T】 右", "cf_J_Mune01_t 影响整个cf_J_Mune01层。影响2,3,4层。\r\n换句话说，T层变化点在1层的最低点，而S层变化点在1层的中间。"));

            //BodyBones.Add("cf_J_Mune02_s_L", new Bone(EBoneType.BodyBones, "cf_J_Mune02_s_L", "【乳房-2层-S】左", "受0，1层影响，但是不影响3,4层。"));
            //BodyBones.Add("cf_J_Mune02_s_R", new Bone(EBoneType.BodyBones, "cf_J_Mune02_s_R", "【乳房-2层-S】右", "受0，1层影响，但是不影响3,4层。"));
            //BodyBones.Add("cf_J_Mune02_t_L", new Bone(EBoneType.BodyBones, "cf_J_Mune02_t_L", "【乳房-2层-T】左", "cf_J_Mune02_t 影响整个cf_J_Mune02层。影响3,4层。\r\n换句话说，T层变化点在2层的最低点，而S层变化点在2层的中间。"));
            //BodyBones.Add("cf_J_Mune02_t_R", new Bone(EBoneType.BodyBones, "cf_J_Mune02_t_R", "【乳房-2层-T】右", "cf_J_Mune02_t 影响整个cf_J_Mune02层。影响3,4层。\r\n换句话说，T层变化点在2层的最低点，而S层变化点在2层的中间。"));

            //BodyBones.Add("cf_J_Mune03_s_L", new Bone(EBoneType.BodyBones, "cf_J_Mune03_s_L", "【乳晕-下部】左", "受0，1，2层影响，影响4层。"));
            //BodyBones.Add("cf_J_Mune03_s_R", new Bone(EBoneType.BodyBones, "cf_J_Mune03_s_R", "【乳晕-下部】右", "受0，1，2层影响，影响4层。"));
            //BodyBones.Add("cf_J_Mune04_s_L", new Bone(EBoneType.BodyBones, "cf_J_Mune04_s_L", "【乳晕-上部】左", "受0，1，2，3层影响"));
            //BodyBones.Add("cf_J_Mune04_s_R", new Bone(EBoneType.BodyBones, "cf_J_Mune04_s_R", "【乳晕-上部】右", "受0，1，2，3层影响"));

        }

        public static Bone GetBoneByBoneName(string BoneName)
        {
            Bone rtn; 
            BodyBones.TryGetValue(BoneName,out rtn);
            if (rtn != null) { return rtn; }
            GlobalBones.TryGetValue(BoneName, out rtn);
            if (rtn != null) { return rtn; }
            HeadBones.TryGetValue(BoneName, out rtn);
            if (rtn != null) { return rtn; }
            if (rtn != null)
                return (Bone)rtn.Clone();
            else
                return null;

        }
    }
}
