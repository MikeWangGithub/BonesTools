using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary
{
    public partial class UCBonePreview : UserControl
    {
        private Bone _bone;
        public Bone bone
        {
            get { return _bone; }
            set
            {
                _bone = value;

                RefreshPreview();
            }
        }

        public UCBonePreview()
        {
            InitializeComponent();
        }
        public UCBonePreview(Bone abone) : this()
        {

            bone = abone;
        }

        public void UpdateValue(string value)
        {
            this.bone.Update(value);
            RefreshPreview();
        }

        private void RefreshPreview()
        {
            this.lbBoneName.Text = _bone.BoneName;
            this.lbBoneTranslateName.Text = bone.BoneTranslateName;
            this.lbScaling.BackColor = bone.IsScalingModified() ? Color.Yellow : Color.Transparent;
            this.lbRotation.BackColor = bone.IsRotationModified() ? Color.Yellow : Color.Transparent;
            this.lbPositioning.BackColor = bone.IsPositioningModified() ? Color.Yellow : Color.Transparent;
            this.lbScaling.Text = "缩放";
            this.lbRotation.Text = "旋转";
            this.lbPositioning.Text = "位移";
        }

        public override string ToString()
        {

            return "UCBonePreview" + base.ToString();
        }
    }
}
