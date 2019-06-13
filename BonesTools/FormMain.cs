using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using WindowsFormsControlLibrary.Threading;
using System.Threading;

using WindowsFormsControlLibrary;

namespace BonesTools
{
    public partial class FormMain : Form
    {
        string DisplayText1 = BonesResources.GetMaxBoneTranslateName() + " ";
        string DisplayText2 = BonesResources.GetMaxBoneName() + " ";
        string DisplayText3 = "缩放 ";
        string DisplayText4 = "旋转 ";
        string DisplayText5 = "位移";
        private Task task;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();


        string CharactorFileName = "";
        string SaveCharactorFileName = "";

        public FormMain()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            foreach (KeyValuePair<string, Bone> bone in BonesResources.GlobalBones)
            {
                this.listBox1.Items.Add(bone.Value);
            }
            foreach (KeyValuePair<string, Bone> bone in BonesResources.BodyBones)
            {
                this.listBox1.Items.Add(bone.Value);
            }
            foreach (KeyValuePair<string, Bone> bone in BonesResources.HeadBones)
            {
                this.listBox1.Items.Add(bone.Value);
            }
            this.listBox1.EndUpdate();
            this.ucBoneEdit1.UpdateBoneByClass = new SafeCallDelegateUpdateBoneByClass(this.UpdateOneBone);
        }

       

        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //lstConsole_DrawItem
            // just in case the list is empty...
            if (e.Index == -1)
                return;

            // prefixes are drawed bold
            Font prefixFont = new Font(e.Font, FontStyle.Bold);

            Bone li = (Bone)((ListBox)sender).Items[e.Index];

            Brush brBlack = new SolidBrush(System.Drawing.Color.Black);
            Brush brRed = new SolidBrush(System.Drawing.Color.Red);

            

            // calculate the width of BoneName

            int BoneTranslateNameWidth = (int)e.Graphics.MeasureString(DisplayText1, e.Font, e.Bounds.Width, StringFormat.GenericDefault).Width;

            int BoneNameWidth = (int)e.Graphics.MeasureString(DisplayText2 , e.Font, e.Bounds.Width, StringFormat.GenericDefault).Width;
            // calculate the width of the longest prefix
            
            int ScalingWidth = (int)e.Graphics.MeasureString(DisplayText3, e.Font, e.Bounds.Width, StringFormat.GenericDefault).Width;
            int RatationWidth = (int)e.Graphics.MeasureString(DisplayText4, e.Font, e.Bounds.Width, StringFormat.GenericDefault).Width;
            //int PostioningWidth = (int)e.Graphics.MeasureString("|位移" + li.BoneTranslateName, prefixFont, e.Bounds.Width, StringFormat.GenericDefault).Width;

            
            e.DrawBackground();
            Rectangle newBounds = new Rectangle(e.Bounds.Location, e.Bounds.Size);
            string Text1 = li.BoneTranslateName;
            string Text2 = li.BoneName;

            // draw the time
            e.Graphics.DrawString(Text1, e.Font, brBlack, newBounds, StringFormat.GenericDefault);
            // calculate the new rectangle
            newBounds.X += BoneTranslateNameWidth;
            newBounds.Width -= BoneTranslateNameWidth;

            // draw the prefix
            e.Graphics.DrawString(Text2, e.Font, brBlack, newBounds, StringFormat.GenericDefault);
            // calculate the new rectangle
            newBounds.X += BoneNameWidth;
            newBounds.Width -= BoneNameWidth;

            // draw the text
            e.Graphics.DrawString(
                DisplayText3, e.Font, li.IsScalingModified()?brRed:brBlack, newBounds.X, newBounds.Y,
                StringFormat.GenericDefault);
            newBounds.X += ScalingWidth;
            newBounds.Width -= ScalingWidth;

            e.Graphics.DrawString(
                DisplayText4, e.Font, li.IsRotationModified() ? brRed : brBlack, newBounds.X, newBounds.Y,
                StringFormat.GenericDefault);
            newBounds.X += RatationWidth;
            newBounds.Width -= RatationWidth;

            e.Graphics.DrawString(
                DisplayText5, e.Font, li.IsPositioningModified() ? brRed : brBlack, newBounds.X, newBounds.Y,
                StringFormat.GenericDefault);
            
            
            // draw the focus
            e.DrawFocusRectangle();

            
        }

        private void ListBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        { 
            Bone lvsDisp =(Bone) ((ListBox)sender).Items[e.Index];
            SizeF lvSize = e.Graphics.MeasureString(DisplayText1 + DisplayText2 + DisplayText3 + DisplayText4 + DisplayText5, ((ListBox)sender).Font);
            if (((ListBox)sender).HorizontalExtent < lvSize.Width)
            { 
                ((ListBox)sender).HorizontalExtent = (int)lvSize.Width;
            }
            e.ItemHeight = (int)lvSize.Height;
            e.ItemWidth = (int)lvSize.Width;

        }

        private async void BtnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
            await RunThread(ThreadTypes.UpdateBoneData);
            
        }

        private void OpenFile()
        {
            if(this.openFileDL.ShowDialog() == DialogResult.OK)
            {
                CharactorFileName = this.openFileDL.FileName;
                this.lbFileName.Text = System.IO.Path.GetFileNameWithoutExtension(CharactorFileName);
            }
        }
        private void SaveFile()
        {
            if (this.saveFileDL.ShowDialog() == DialogResult.OK)
            {
                SaveCharactorFileName = this.saveFileDL.FileName;
                //this.lbFileName.Text = System.IO.Path.GetFileNameWithoutExtension(CharactorFileName);
            }
        }
        private void UpdateOneBone(string lineValue)
        {
            if (this.listBox1.InvokeRequired)
            {
                var d = new WindowsFormsControlLibrary.Threading.SafeCallDelegateUpdateBoneByString(UpdateOneBone);
                this.Invoke(d, new object[] { lineValue });

            }
            else
            {
                //string BoneName = Bone.GetBoneName(lineValue);
                //List<Bone> arrayBone= this.listBox1.Items.Cast<Bone>().ToList();
                //Bone bone = arrayBone.FirstOrDefault<Bone>(p => p.BoneName == BoneName);

                //if (bone != null)
                //{
                //    if (bone.IsNeedUpdate(lineValue)) { 
                //        bone.Update(lineValue);
                //        int index  = this.listBox1.Items.IndexOf(bone);
                //        //this.listBox1.BeginUpdate();
                //        this.listBox1.Items.RemoveAt(index);
                //        this.listBox1.Items.Insert(index, bone);
                //    }
                //    //this.listBox1.EndUpdate();
                //}
                EAction eAction;
                Bone bone = Bone.GetBoneByString(lineValue, out eAction);
                if (bone != null)
                {
                    UpdateOneBone(bone, eAction);
                }
                
            }                
        }
        private void UpdateOneBone(Bone value,EAction eAction )
        {
            if (this.listBox1.InvokeRequired)
            {
                var d = new WindowsFormsControlLibrary.Threading.SafeCallDelegateUpdateBoneByClass(UpdateOneBone);
                this.Invoke(d, new object[] { value,eAction });

            }
            else
            {
                string BoneName = value.BoneName;
                List<Bone> arrayBone = this.listBox1.Items.Cast<Bone>().ToList();
                Bone bone = arrayBone.FirstOrDefault<Bone>(p => p.BoneName == BoneName);

                if (bone != null)
                {
                    if(bone.IsNeedUpdate(value, eAction)) {

                        int index = this.listBox1.Items.IndexOf(bone);
                        bone.Update(value.GetLineValue(eAction));
                        //this.listBox1.BeginUpdate();
                        this.listBox1.Items.RemoveAt(index);
                        this.listBox1.Items.Insert(index, bone);
                        //this.listBox1.EndUpdate();
                    }
                }

            }
        }
        private void UpdateOneBoneMainFunktion(string Bone)
        {

        }
        private async void Button2_Click(object sender, EventArgs e)
        {
            SaveFile();
            await RunThread(ThreadTypes.WriteBoneData);
        }


        private UpdateBoneDataParameter GetUpdateBoneDataParameter()
        {
            UpdateBoneDataParameter param = new UpdateBoneDataParameter(this.CharactorFileName, new SafeCallDelegateUpdateBoneByString(this.UpdateOneBone));
            return param;

        }
        private WriteBoneDataParameter GetWriteBoneDataParameter()
        {
            WriteBoneDataParameter param = new WriteBoneDataParameter(this.SaveCharactorFileName);
            if (radioButton1.Checked) { param.BoneSaveSettting = ESaveBoneSetting.OnlyChanged; }
            else { param.BoneSaveSettting = ESaveBoneSetting.All; }

            List<string> lines = new List<string>();
            foreach (Bone item in this.listBox1.Items)
            {
                if (param.BoneSaveSettting == ESaveBoneSetting.OnlyChanged)
                {
                    if (item.IsScalingModified()) { lines.Add(item.GetLineValue(EAction.Scaling)); }
                    if (item.IsRotationModified()) { lines.Add(item.GetLineValue(EAction.Rotation)); }
                    if (item.IsPositioningModified()) { lines.Add(item.GetLineValue(EAction.Positioning)); }
                }
                else
                {
                    lines.Add(item.GetLineValue(EAction.Scaling));
                }
                

            }
            param.lines = new List<string>();
            param.lines = param.lines.Concat(lines).ToList();
            return param;

        }
        private void CancelTask()
        {
            if (tokenSource != null)
            {
                if (tokenSource.IsCancellationRequested == false)
                {
                    tokenSource.Cancel();
                }
            }
        }
        private CancellationTokenSource StartNewTask()
        {
            tokenSource = new CancellationTokenSource();
            // token = tokenSource.Token;
            return tokenSource;
        }

        private async Task RunThread(ThreadTypes ThreadName, object[] objects)
        {

            DateTime dt1, dt2;
            dt1 = System.DateTime.Now;
            try
            {

                // this.SetButtonStatus(ThreadName, false);
                ThreadContext threadContext = null;
                CancellationTokenSource tokenSource = StartNewTask();
                ICloneable param = GetParameter(ThreadName);
                // param = DecoratorParameter(ThreadName, param, objects);
                threadContext = new ThreadContext(ThreadName,tokenSource, param);

                task = threadContext.ThreadRun();
                await task;
                //
            }
            catch (Exception ex)
            {
                //log.RecordError(ex.Message);
                //this.SetFolderButtonStatus(true);
            }
            finally
            {
                //this.SetButtonStatus(ThreadName, true);
                dt2 = System.DateTime.Now;
                //log.Log("Finished task[" + ThreadName + ". Time is " + (dt2 - dt1).ToString());
            }
        }


        private async Task RunThread(ThreadTypes ThreadName)
        {
            await RunThread(ThreadName, null);
        }
        private ICloneable GetParameter(ThreadTypes ThreadName)
        {
            ICloneable param = null;
            switch (ThreadName)
            {
                case ThreadTypes.UpdateBoneData:
                    param = this.GetUpdateBoneDataParameter();
                    break;
                case ThreadTypes.WriteBoneData:
                    param = this.GetWriteBoneDataParameter();
                    break;
                default:
                    break;
            }
            return param;
        }

        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Bone lvsDisp = (Bone)((ListBox)sender).SelectedItem;
            if(lvsDisp != null)
            {
                this.ucBoneEdit1.bone = (Bone)lvsDisp.Clone();
                this.ucBoneEdit1.RefreshEditor();
            }
        }
    }
}
