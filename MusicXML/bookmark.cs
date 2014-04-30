[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class bookmark
{

    private string idField;

    private string nameField;

    private string elementField;

    private string positionField;


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "token")]
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string element
    {
        get
        {
            return this.elementField;
        }
        set
        {
            this.elementField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
    public string position
    {
        get
        {
            return this.positionField;
        }
        set
        {
            this.positionField = value;
        }
    }
}