[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName = "frame-note")]
public partial class framenote
{

    private @string stringField;

    private fret fretField;

    private fingering fingeringField;

    private barre barreField;


    public @string @string
    {
        get
        {
            return this.stringField;
        }
        set
        {
            this.stringField = value;
        }
    }


    public fret fret
    {
        get
        {
            return this.fretField;
        }
        set
        {
            this.fretField = value;
        }
    }


    public fingering fingering
    {
        get
        {
            return this.fingeringField;
        }
        set
        {
            this.fingeringField = value;
        }
    }


    public barre barre
    {
        get
        {
            return this.barreField;
        }
        set
        {
            this.barreField = value;
        }
    }
}