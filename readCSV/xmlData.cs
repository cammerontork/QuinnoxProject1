using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Xml2CSharp
{
    [XmlRoot(ElementName = "Property")]
    public class Property
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "ref")]
        public string Ref { get; set; }
        [XmlAttribute(AttributeName = "pref")]
        public string Pref { get; set; }
    }

    [XmlRoot(ElementName = "Object")]
    public class Object
    {
        [XmlElement(ElementName = "Property")]
        public List<Property> Property { get; set; }
        [XmlAttribute(AttributeName = "ref")]
        public string Ref { get; set; }
    }

    [XmlRoot(ElementName = "ObjectGroup")]
    public class ObjectGroup
    {
        [XmlElement(ElementName = "Object")]
        public Object Object { get; set; }
        [XmlAttribute(AttributeName = "ref")]
        public string Ref { get; set; }
    }

    [XmlRoot(ElementName = "Page")]
    public class Page
    {
        [XmlElement(ElementName = "ObjectGroup")]
        public List<ObjectGroup> ObjectGroup { get; set; }
        [XmlAttribute(AttributeName = "packageName")]
        public string PackageName { get; set; }
        [XmlAttribute(AttributeName = "ref")]
        public string Ref { get; set; }

    }

    [XmlRoot(ElementName = "Root")]
    public class Root
    {
        [XmlElement(ElementName = "Page")]
        public List<Page> Page { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "ref")]
        public string Ref { get; set; }
    }

}
