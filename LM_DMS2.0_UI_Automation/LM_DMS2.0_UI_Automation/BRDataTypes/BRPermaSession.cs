using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace LastMile.Web.Automation.BRDataTypes
{
    class BRPermaSession : BRBaseXmlManager
    {
        #region MemberVars

        #endregion

        #region Properties

        /// <summary>
        /// Gets the root node.
        /// </summary>
        /// <value>The root node.</value>
        public XmlNode RootNode
        {
            get { return base.GetXmlNode("Session"); }
        }

        /// <summary>
        /// Gets or sets the LCSM id.
        /// </summary>
        /// <value>The LCSM id.</value>
        public int LastHighlightedElement
        {
            get { return GetSessionIntValue("LastHighlightedElement"); }
            set { SetSessionValue("LastHighlightedElement", value.ToString(), true); }
        }

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>The current user.</value>
        public string CurrentUser
        {
            get { return GetSessionValue("XPOCurrentUser"); }
            set { SetSessionValue("XPOCurrentUser", value, true); }
        }

        public string CurrentOrderNumber
        {
            get { return GetSessionValue("XPOCurrentOrderNumber"); }
            set { SetSessionValue("XPOCurrentOrderNumber", value, true); }
        }

        public string CurrentCarrier
        {
            get { return GetSessionValue("FOCurrentCarrier"); }
            set { SetSessionValue("FOCurrentCarrier", value, true); }
        }

        public string CurrentWorkspace
        {
            get { return GetSessionValue("FOCurrentWorkspace"); }
            set { SetSessionValue("FOCurrentWorkspace", value, true); }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PermaSession"/> class.
        /// </summary>
        //public PermaSession() : base(System.Environment.CurrentDirectory + "\\Session.xml")
        //Make dir configurable
        public BRPermaSession() : base("C:\\BUILD_AUTOMATION\\Session.xml")
        {
            if (Document.FirstChild.Value == null)
            {
                ResetDefaultVals();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Initialize()
        {
            //m_session = new Dictionary<string, string>();
            RemoveAllChildren(RootNode);
            System.Threading.Thread.Sleep(500);
            ResetDefaultVals();
        }

        /// <summary>
        /// Creates the doc.
        /// </summary>
        public override void CreateDoc()
        {
            base.CreateDoc();
            ResetDefaultVals();
        }

        /// <summary>
        /// Resets the default vals.
        /// </summary>
        public void ResetDefaultVals()
        {
            LastHighlightedElement = -1;
        }

        /// <summary>
        /// Gets the XML session.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetXmlSession()
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();

            foreach (XmlNode n in base.GetXmlNodeChildren(RootNode))
            {
                temp.Add(n.Name, n.InnerText);
            }

            return temp;
        }

        /// <summary>
        /// Gets the session value.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <returns></returns>
        public string GetSessionValue(string keyName)
        {
            return GetNodeValue(keyName);
        }

        /// <summary>
        /// Adds the session value.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="val">The val.</param>
        public void AddSessionValue(string keyName, string val)
        {
            base.CreateNode(RootNode, keyName, val);
        }

        /// <summary>
        /// Sets the session value.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="val">The val.</param>
        public void SetSessionValue(string keyName, string val)
        {
            SetSessionValue(keyName, val, false);
        }

        /// <summary>
        /// Sets the session value.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="val">The val.</param>
        /// <param name="createIfNotExist">if set to <c>true</c> [create if not exist].</param>
        public void SetSessionValue(string keyName, string val, bool createIfNotExist)
        {
            XmlNode x = null;
            try
            {
                x = GetXmlNode(keyName);
            }
            catch (Exception oops)
            {
                if (createIfNotExist)
                {
                    CreateNode(RootNode, keyName, val);
                    return;
                }
                else
                {
                    throw oops;
                }
            }

            UpdateNodeValue(x, val);
        }

        /// <summary>
        /// Sets the session value as a pipe separateList.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="val">The val.</param>
        public void SetSessionListValue(string keyName, List<string> list)
        {
            SetSessionListValue(keyName, list, false);
        }

        /// <summary>
        /// Sets the session value as a pipe separateList.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="val">The val.</param>
        /// <param name="createIfNotExist">if set to <c>true</c> [create if not exist].</param>
        public void SetSessionListValue(string keyName, List<string> list, bool createIfNotExist)
        {
            string val = String.Join("^", list.ToArray());
            SetSessionValue(keyName, val, createIfNotExist);
        }

        /// <summary>
        /// Removes the session key value pair.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        public void RemoveSessionKeyValuePair(string keyName)
        {
            RemoveNode(keyName);
        }

        /// <summary>
        /// Gets the int value.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="defaultVal">The default val.</param>
        /// <returns></returns>
        public int GetSessionIntValue(string tagName, int defaultVal)
        {
            int id = defaultVal;

            try
            {
                id = int.Parse(GetSessionValue(tagName));
            }
            catch
            {
                id = defaultVal;
            }

            return id;
        }

        /// <summary>
        /// Gets the int value.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <returns></returns>
        public int GetSessionIntValue(string tagName)
        {
            return GetSessionIntValue(tagName, -1);
        }

        /// <summary>
        /// Gets the session date time value.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="defaultVal">The default val.</param>
        /// <returns></returns>
        public DateTime? GetSessionDateTimeValue(string tagName, DateTime? defaultVal)
        {
            DateTime? dt = defaultVal;

            try
            {
                dt = DateTime.Parse(GetSessionValue(tagName));
            }
            catch
            {
                dt = defaultVal;
            }

            return dt;
        }

        /// <summary>
        /// Gets the session date time value.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <returns></returns>
        public DateTime? GetSessionDateTimeValue(string tagName)
        {
            return GetSessionDateTimeValue(tagName, null);
        }

        /// <summary>
        /// Gets the list of strings value.
        /// The string is stored a piped separated list, and converted to a List of strings
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="defaultVal">The default val.</param>
        /// <returns></returns>
        public List<string> GetSessionListValue(string tagName, List<string> defaultVal)
        {
            List<string> ls = new List<string>();
            try
            {
                string[] lsArray = GetSessionValue(tagName).Split('^');
                ls = lsArray.ToList<string>();
            }
            catch
            {
                ls = defaultVal;
            }

            return ls;
        }

        /// <summary>
        /// Gets the list of strings value.
        /// The string is stored a piped separated list, and converted to a List of strings
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <returns></returns>
        public List<string> GetSessionListValue(string tagName)
        {
            return GetSessionListValue(tagName, null);
        }

        /// <summary>
        /// Sets the current user.
        /// </summary>
        /// <param name="user">The user.</param>
        //public void SetCurrentUser(XPOUser user)
        //{
        //    SetSessionValue("CurrentUserId", user.ID.ToString(), true);
        //    SetSessionValue("CurrentUserLogin", user.UserName.ToString(), true);
        //    SetSessionValue("CurrentUserFirstName", user.FirstName.ToString(), true);
        //    SetSessionValue("CurrentUserLastName", user.LastName.ToString(), true);

        //}

        ///// <summary>
        ///// Gets the current user.
        ///// </summary>
        ///// <param name="userName">Name of the user.</param>
        ///// <returns></returns>
        //public XPOUser GetCurrentUser(string userName)
        //{
        //    string login = GetSessionValue("CurrentUserLogin");

        //    if (login.ToLower() == userName.ToLower())
        //    {
        //        return new XPOUser(login, GetSessionValue("CurrentUserFirstName"), GetSessionValue("CurrentUserLastName"), GetSessionIntValue("CurrentUserId"));
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <returns></returns>
        //public XPOUser GetCurrentUser()
        //{
        //    string login = GetSessionValue("CurrentUserLogin");
        //    if (string.IsNullOrEmpty(login))
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return new XPOUser(login, GetSessionValue("CurrentUserFirstName"), GetSessionValue("CurrentUserLastName"), GetSessionIntValue("CurrentUserId"));
        //    }
        //}


        /// <summary>
        /// Clears the current user.
        /// </summary>
        public void ClearCurrentUser()
        {
            try
            {
                RemoveNode("CurrentUserId");
                RemoveNode("CurrentUserLogin");
                RemoveNode("CurrentUserFirstName");
                RemoveNode("CurrentUserLastName");
            }
            catch
            {

            }
        }

        #endregion

        #region Statics

        #endregion
    }
}