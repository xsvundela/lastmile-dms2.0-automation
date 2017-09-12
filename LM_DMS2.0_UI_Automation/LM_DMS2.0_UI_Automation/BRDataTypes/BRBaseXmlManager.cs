using System;
using System.Collections.Generic;
using System.Xml;

namespace LastMile.Web.Automation.BRDataTypes
{
    public class BRBaseXmlManager
    {
        #region MemberVars
        private string m_fileName = "UnNamed";
        private string m_path = string.Empty;
        private XmlDocument m_doc = null;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public virtual string FileName
        {
            get { return m_fileName; }
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <value>The file path.</value>
        public virtual string FilePath
        {
            get { return m_path; }
        }

        /// <summary>
        /// Gets the name of the path and file.
        /// </summary>
        /// <value>The name of the path and file.</value>
        public virtual string PathAndFileName
        {
            get
            {
                if (!FilePath.EndsWith("\\"))
                {
                    return FilePath + "\\" + FileName;
                }
                else
                {
                    return FilePath + FileName;
                }
            }
        }

        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <value>The document.</value>
        public virtual XmlDocument Document
        {
            get
            {
                if (m_doc == null)
                {
                    m_doc = new XmlDocument();
                    m_doc.Load(FilePath + FileName);
                }

                return m_doc;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="XMLManager"/> class.
        /// </summary>
        /// <param name="xmlPathAndFileName">Name of the XML path and file.</param>
        public BRBaseXmlManager(string xmlPathAndFileName)
        {
            string localConfig = Environment.CurrentDirectory + "\\Tests.xml";

            if (System.IO.File.Exists(localConfig))
            {
                m_fileName = localConfig.Substring(localConfig.LastIndexOf("\\") + 1);
                m_path = localConfig.Substring(0, localConfig.LastIndexOf("\\") + 1);
            }
            else
            {
                m_fileName = xmlPathAndFileName.Substring(xmlPathAndFileName.LastIndexOf("\\") + 1);
                m_path = xmlPathAndFileName.Substring(0, xmlPathAndFileName.LastIndexOf("\\") + 1);
            }

            if (!System.IO.File.Exists(PathAndFileName))
            {
                CreateDoc();
            }
        }


        #endregion

        #region Methods
        /// <summary>
        /// Creates the doc.
        /// </summary>
        public virtual void CreateDoc()
        {
            // Create the xml document containe
            XmlDocument doc = new XmlDocument();
            // Create the XML Declaration, and append it to XML document
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);
            // Create the root element
            XmlElement root = doc.CreateElement("Session");
            doc.AppendChild(root);
            doc.Save(PathAndFileName);
        }

        /// <summary>
        /// Gets the XML node.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <returns></returns>
        public virtual XmlNode GetXmlNode(string tagName)
        {
            //return Document.SelectSingleNode(tagName);
            XmlNodeList nodes = Document.GetElementsByTagName(tagName);

            // try this
            System.Threading.Thread.Sleep(1 * 1000);
            // ugh

            if (nodes.Count > 0)
            {
                return nodes[0];
            }
            else
            {
                throw new Exception("Node '" + tagName + "' not found!");
            }
        }

        /// <summary>
        /// Gets the XML node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public virtual XmlNode GetXmlNode(XmlNode parent, string tagName, string value)
        {
            foreach (XmlNode n in GetXmlNodeChildren(parent))
            {
                if (GetNodeValue(n, tagName) == value)
                {
                    return n;
                }
            }

            return null;

        }

        /// <summary>
        /// Reads the XML doc and returns a node list of the child nodes.
        /// </summary>
        /// <param name="tagName">Name of the tag to read.</param>
        /// <returns>XmlNodeList of child nodes</returns>
        public virtual XmlNodeList ReadXMLDoc(string tagName)
        {
            return Document.GetElementsByTagName(tagName);
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns></returns>
        public virtual List<string> GetChildren(XmlNode parent, string nodeName)
        {
            List<string> nodes = new List<string>();

            foreach (XmlNode t in parent.ChildNodes)
            {
                if (string.Compare(t.Name, nodeName, true) == 0)
                {
                    nodes.Add(t.InnerText);
                }
            }

            return nodes;
        }

        /// <summary>
        /// Gets the XML node children.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns></returns>
        public virtual List<XmlNode> GetXmlNodeChildren(XmlNode parent, string nodeName)
        {
            List<XmlNode> nodes = new List<XmlNode>();

            foreach (XmlNode t in parent.ChildNodes)
            {
                if (string.Compare(t.Name, nodeName, true) == 0)
                {
                    nodes.Add(t);
                }
            }

            return nodes;
        }


        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns></returns>
        public virtual List<string> GetChildren(XmlNode parent)
        {
            List<string> nodes = new List<string>();

            foreach (XmlNode t in parent.ChildNodes)
            {
                nodes.Add(t.InnerText);
            }

            return nodes;
        }

        /// <summary>
        /// Gets the XML node children.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns></returns>
        public virtual List<XmlNode> GetXmlNodeChildren(XmlNode parent)
        {
            List<XmlNode> nodes = new List<XmlNode>();

            foreach (XmlNode t in parent.ChildNodes)
            {
                nodes.Add(t);
            }

            return nodes;
        }

        /// <summary>
        /// Gets the node value.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <returns></returns>
        public virtual string GetNodeValue(string tagName)
        {
            return GetXmlNode(tagName).InnerText;
        }

        /// <summary>
        /// Gets the XML node.
        /// </summary>
        /// <param name="currentNode">The current node.</param>
        /// <param name="tagName">Name of the tag.</param>
        /// <returns></returns>
        public virtual string GetNodeValue(XmlNode currentNode, string tagName)
        {
            foreach (XmlNode n in currentNode.ChildNodes)
            {
                if (string.Compare(n.Name, tagName, true) == 0)
                {
                    return n.InnerText;
                }
            }

            return null;
        }

        /// <summary>
        /// Creates the node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="newNode">The new node.</param>
        public virtual void CreateNode(XmlNode parent, XmlNode newNode)
        {
            parent.AppendChild(newNode);
            Document.Save(PathAndFileName);
        }

        /// <summary>
        /// Creates the node.
        /// </summary>
        /// <param name="parentTagName">Name of the parent tag.</param>
        /// <param name="newNode">The new node.</param>
        public virtual void CreateNode(string parentTagName, XmlNode newNode)
        {
            CreateNode(GetXmlNode(parentTagName), newNode);
        }

        /// <summary>
        /// Creates the node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="newTagName">New name of the tag.</param>
        /// <param name="newTagValue">The new tag value.</param>
        public virtual void CreateNode(XmlNode parent, string newTagName, string newTagValue)
        {
            XmlNode newNode = Document.CreateNode(XmlNodeType.Element, newTagName, null);
            newNode.InnerText = newTagValue;

            CreateNode(parent, newNode);
        }

        /// <summary>
        /// Creates the node.
        /// </summary>
        /// <param name="parentTagName">Name of the parent tag.</param>
        /// <param name="newTagName">New name of the tag.</param>
        /// <param name="newTagValue">The new tag value.</param>
        public virtual void CreateNode(string parentTagName, string newTagName, string newTagValue)
        {
            XmlNode newNode = Document.CreateNode(XmlNodeType.Element, newTagName, null);
            newNode.InnerText = newTagValue;

            CreateNode(GetXmlNode(parentTagName), newNode);
        }

        /// <summary>
        /// Updates the value.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="value">The value.</param>
        public virtual void UpdateNodeValue(XmlNode tag, string value)
        {
            tag.InnerText = value;
            Document.Save(PathAndFileName);
        }

        /// <summary>
        /// Updates the node value.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="value">The value.</param>
        public virtual void UpdateNodeValue(string tagName, string value)
        {
            GetXmlNode(tagName).InnerText = value;
            Document.Save(PathAndFileName);
        }

        /// <summary>
        /// Removes the node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="nodeToBeRemoved">The node to be removed.</param>
        public virtual void RemoveNode(XmlNode parent, XmlNode nodeToBeRemoved)
        {
            parent.RemoveChild(nodeToBeRemoved);
            Document.Save(PathAndFileName);
        }

        /// <summary>
        /// Removes the node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="nodeTagToBeRemoved">The node tag to be removed.</param>
        public virtual void RemoveNode(XmlNode parent, string nodeTagToBeRemoved)
        {
            parent.RemoveChild(GetXmlNode(nodeTagToBeRemoved));
            Document.Save(PathAndFileName);
        }

        /// <summary>
        /// Removes the node.
        /// </summary>
        /// <param name="nodeToBeRemoved">The node to be removed.</param>
        public virtual void RemoveNode(XmlNode nodeToBeRemoved)
        {
            Document.RemoveChild(nodeToBeRemoved);
            Document.Save(PathAndFileName);
        }

        /// <summary>
        /// Removes the node.
        /// </summary>
        /// <param name="nodeTagToBeRemoved">The node tag to be removed.</param>
        public virtual void RemoveNode(string nodeTagToBeRemoved)
        {
            XmlNode victim = GetXmlNode(nodeTagToBeRemoved);
            XmlNode parent = victim.ParentNode;
            parent.RemoveChild(victim);
            //Document.RemoveChild(GetXmlNode(nodeTagToBeRemoved));
            Document.Save(PathAndFileName);
        }

        /// <summary>
        /// Removes all children.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public virtual void RemoveAllChildren(XmlNode parent)
        {
            parent.RemoveAll();
            Document.Save(PathAndFileName);
        }

        /// <summary>
        /// Transforms the XML text.
        /// </summary>
        /// <param name="xmlText">The XML text.</param>
        /// <returns></returns>
        public virtual string TransformXmlText(string xmlText)
        {
            xmlText = xmlText.Trim();
            xmlText = xmlText.Replace("&", "&amp;");
            xmlText = xmlText.Replace("<br />", "\r\n");
            xmlText = xmlText.Replace("<BR />", "\r\n");

            return xmlText;
        }
        public void DeleteDoc ()
        {
            if (System.IO.File.Exists(PathAndFileName))
            {
                System.IO.File.Delete(PathAndFileName);
            }
        }
        #endregion
    }
}