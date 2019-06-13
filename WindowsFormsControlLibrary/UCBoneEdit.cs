using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using WindowsFormsControlLibrary.Threading;


namespace WindowsFormsControlLibrary
{
    public partial class UCBoneEdit: UserControl
    {
        private Bone _bone;
        public Bone bone {
            get { return _bone; }
            set
            {
                _bone = value;
                

            }
        }

        public SafeCallDelegateUpdateBoneByClass UpdateBoneByClass { get; set; }
        public UCBoneEdit()
        {
            InitializeComponent();
        }

        public UCBoneEdit(Bone abone) : this()
        {

            bone = abone;
        }
        public void UpdateValue(string value)
        {
            if (this.bone != null) { 
                this.bone.Update(value);
                RefreshEditor();
            }
        }

        public void RefreshEditor()
        {
            if (this.bone != null) { 
                this.lbBoneName.Text = _bone.BoneName;
                //this.NudSX.Value = _bone.ScalingX;
                //this.NudSY.Value = _bone.ScalingY;
                //this.NudSZ.Value = _bone.ScalingZ;

                //this.NudRX.Value = _bone.RotationX;
                //this.NudRY.Value = _bone.RotationY;
                //this.NudRZ.Value = _bone.RotationZ;

                //this.NudPX.Value = _bone.PositioningX;
                //this.NudPY.Value = _bone.PositioningY;
                //this.NudPZ.Value = _bone.PositioningZ;
                SetNumericUpDownControllValue(this.NudSX, EAction.Scaling, this.bone.ScalingX);
                SetNumericUpDownControllValue(this.NudSY, EAction.Scaling, this.bone.ScalingY);
                SetNumericUpDownControllValue(this.NudSZ, EAction.Scaling, this.bone.ScalingZ);

                SetNumericUpDownControllValue(this.NudRX, EAction.Rotation, this.bone.RotationX);
                SetNumericUpDownControllValue(this.NudRY, EAction.Rotation, this.bone.RotationY);
                SetNumericUpDownControllValue(this.NudRZ, EAction.Rotation, this.bone.RotationZ);

                SetNumericUpDownControllValue(this.NudPX, EAction.Positioning, this.bone.PositioningX);
                SetNumericUpDownControllValue(this.NudPY, EAction.Positioning, this.bone.PositioningY);
                SetNumericUpDownControllValue(this.NudPZ, EAction.Positioning, this.bone.PositioningZ);

                this.lbBoneTranslateName.Text = _bone.BoneTranslateName;
                this.rTxtDes.Text = _bone.BoneDescription;
            }
        }

        private void SetNumericUpDownControllValue(object sender,decimal value)
        {
            
            if (value > ((System.Windows.Forms.NumericUpDown)sender).Maximum)
            {
                ((System.Windows.Forms.NumericUpDown)sender).Value = ((System.Windows.Forms.NumericUpDown)sender).Maximum;   
            }
            else
            {
                if (value < ((System.Windows.Forms.NumericUpDown)sender).Minimum)
                    ((System.Windows.Forms.NumericUpDown)sender).Value = ((System.Windows.Forms.NumericUpDown)sender).Minimum;
                else
                    ((System.Windows.Forms.NumericUpDown)sender).Value = value;
            }
        }
        private void SetNumericUpDownControllValue(object sender, EAction eAction, decimal value)
        {

            if(eAction == EAction.Rotation)
            {
                SetNumericUpDownControllValue(sender, value % 360);
            }
            else
            {
                SetNumericUpDownControllValue(sender, value);
            }
        }

        private void UpdateDecimal(Decimal value, EAction action, string xyz)
        {
            if (this.bone == null) return;
            switch (action)
            {
                case EAction.Scaling:
                    switch (xyz.ToLower())
                    {
                        case "x":
                            this.bone.ScalingX = value;
                            this.NudSX.Value = value;
                            break;
                        case "y":
                            this.bone.ScalingY = value;
                            this.NudSY.Value = value;
                            break;
                        case "z":
                            this.bone.ScalingZ = value;
                            this.NudSZ.Value = value;
                            break;
                        default:
                            break;
                    }
                    break;
                case EAction.Rotation:
                    switch (xyz.ToLower())
                    {
                        case "x":
                            this.bone.RotationX = value;
                            this.NudRX.Value = value;
                            break;
                        case "y":
                            this.bone.RotationY = value;
                            this.NudRY.Value = value;
                            break;
                        case "z":
                            this.bone.RotationZ = value;
                            this.NudRZ.Value = value;
                            break;
                        default:
                            break;
                    }
                    break;
                case EAction.Positioning:
                    switch (xyz.ToLower())
                    {
                        case "x":
                            this.bone.PositioningX = value;
                            this.NudPX.Value = value;
                            break;
                        case "y":
                            this.bone.PositioningY = value;
                            this.NudPY.Value = value;
                            break;
                        case "z":
                            this.bone.PositioningZ = value;
                            this.NudPZ.Value = value;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        private void NudSX_ValueChanged(object sender, EventArgs e)
        {
            if (this.bone != null) {
                UpdateDecimal(((NumericUpDown)sender).Value,EAction.Scaling,"x");
                this.UpdateBoneByClass(this.bone, EAction.Scaling);
            }
        }

        private void NudSY_ValueChanged(object sender, EventArgs e)
        {
            if (this.bone != null)
            {
                UpdateDecimal(((NumericUpDown)sender).Value, EAction.Scaling, "y");
                this.UpdateBoneByClass(this.bone, EAction.Scaling);
            }

        }

        private void NudSZ_ValueChanged(object sender, EventArgs e)
        {
            if (this.bone != null)
            {
                UpdateDecimal(((NumericUpDown)sender).Value, EAction.Scaling, "z");
                this.UpdateBoneByClass(this.bone, EAction.Scaling);
            }

        }

        private void BtnSX_Click(object sender, EventArgs e)
        {
            UpdateDecimal(1, EAction.Scaling, "x");
        }

        private void BtnSY_Click(object sender, EventArgs e)
        {
            UpdateDecimal(1, EAction.Scaling, "y");
        }

        private void BtnSZ_Click(object sender, EventArgs e)
        {
            UpdateDecimal(1, EAction.Scaling, "z");
        }

        private void NudRX_ValueChanged(object sender, EventArgs e)
        {
            if (this.bone != null)
            {
                UpdateDecimal(((NumericUpDown)sender).Value, EAction.Rotation, "x");
                this.UpdateBoneByClass(this.bone, EAction.Rotation);
            }
        }

        private void NudRY_ValueChanged(object sender, EventArgs e)
        {
            if (this.bone != null)
            {
                UpdateDecimal(((NumericUpDown)sender).Value, EAction.Rotation, "y");
                this.UpdateBoneByClass(this.bone, EAction.Rotation);
            }

        }
        private void NudRZ_ValueChanged(object sender, EventArgs e)
        {
            if (this.bone != null)
            {
                UpdateDecimal(((NumericUpDown)sender).Value, EAction.Rotation, "z");
                this.UpdateBoneByClass(this.bone, EAction.Rotation);
            }
        }
        private void BtnRZ_Click(object sender, EventArgs e)
        {
            UpdateDecimal(0, EAction.Rotation, "z");
        }

        private void BtnRX_Click(object sender, EventArgs e)
        {
            UpdateDecimal(0, EAction.Rotation, "x");
        }

        private void BtnRY_Click(object sender, EventArgs e)
        {
            UpdateDecimal(0, EAction.Rotation, "y");
        }

        private void NudPX_ValueChanged(object sender, EventArgs e)
        {
            if (this.bone != null)
            {
                UpdateDecimal(((NumericUpDown)sender).Value, EAction.Positioning, "x");
                this.UpdateBoneByClass(this.bone, EAction.Positioning);
            }

        }

        private void NudPY_ValueChanged(object sender, EventArgs e)
        {
            if (this.bone != null)
            {
                UpdateDecimal(((NumericUpDown)sender).Value, EAction.Positioning, "y");
                this.UpdateBoneByClass(this.bone, EAction.Positioning);
            }
        }

        private void NudPZ_ValueChanged(object sender, EventArgs e)
        {
            if (this.bone != null)
            {
                UpdateDecimal(((NumericUpDown)sender).Value, EAction.Positioning, "z");
                this.UpdateBoneByClass(this.bone, EAction.Positioning);
            }
        }

        private void BtnPX_Click(object sender, EventArgs e)
        {
            UpdateDecimal(0, EAction.Positioning, "x");
        }

        private void BtnPY_Click(object sender, EventArgs e)
        {
            UpdateDecimal(0, EAction.Positioning, "y");
        }

        private void BtnPZ_Click(object sender, EventArgs e)
        {
            UpdateDecimal(0, EAction.Positioning, "z");
        }
    }
}
