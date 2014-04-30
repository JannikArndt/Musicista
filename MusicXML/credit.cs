[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class credit
{

    private string[] credittypeField;

    private link[] linkField;

    private bookmark[] bookmarkField;

    private object[] itemsField;

    private string pageField;


    [System.Xml.Serialization.XmlElementAttribute("credit-type", Order = 0)]
    public string[] credittype
    {
        get
        {
            return this.credittypeField;
        }
        set
        {
            this.credittypeField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("link", Order = 1)]
    public link[] link
    {
        get
        {
            return this.linkField;
        }
        set
        {
            this.linkField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("bookmark", Order = 2)]
    public bookmark[] bookmark
    {
        get
        {
            return this.bookmarkField;
        }
        set
        {
            this.bookmarkField = value;
        }
    }


    [System.Xml.Serialization.XmlElementAttribute("bookmark", typeof(bookmark), Order = 3)]
    [System.Xml.Serialization.XmlElementAttribute("credit-image", typeof(image), Order = 3)]
    [System.Xml.Serialization.XmlElementAttribute("credit-words", typeof(formattedtext), Order = 3)]
    [System.Xml.Serialization.XmlElementAttribute("link", typeof(link), Order = 3)]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }


    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
    public string page
    {
        get
        {
            return this.pageField;
        }
        set
        {
            this.pageField = value;
        }
    }
}