[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class root
{

    private rootstep rootstepField;

    private rootalter rootalterField;


    [System.Xml.Serialization.XmlElementAttribute("root-step")]
    public rootstep rootstep
    {
        get
        {
            return this.rootstepField;
        }
        set
        {
            this.rootstepField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("root-alter")]
    public rootalter rootalter
    {
        get
        {
            return this.rootalterField;
        }
        set
        {
            this.rootalterField = value;
        }
    }
}