using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace BonesTools.Design
{
    [ToolboxItemFilter("BonesTools.BonesBorder", ToolboxItemFilterType.Require)]
    [ToolboxItemFilter("BonesTools.BonesText", ToolboxItemFilterType.Require)]
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class UCBoneRootDesigner : System.Windows.Forms.Design.DocumentDesigner
    {
        public UCBoneRootDesigner()
        {
            Trace.WriteLine("UCBoneRootDesigner ctor");
        }
    }
}
