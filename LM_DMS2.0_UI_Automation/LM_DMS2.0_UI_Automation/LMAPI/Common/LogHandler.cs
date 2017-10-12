#region References
using LastMile.Web.Automation.BRBaseObjects;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Xunit;
#endregion

namespace LM_DMS2._0_UI_Automation.LMAPI.Common
{
    /// <summary>
    /// This class is used for handling the LogHandler with log levels Exception,Information,Warning,Debug:-
    /// </summary>   
    public class LogHandler: BRAPIBaseTest, IClassFixture<BRAPIFixture>
    {
        #region Methods
        /// <summary>
        /// Logging the Exceptions
        /// </summary>
        /// <param name="ex"></param>
        public static void LogException(Exception ex)
        {            
            try
            {
                string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                message += Environment.NewLine;
                message += "-----------------------------------------------------------";
                message += Environment.NewLine;
                message += string.Format("Message: {0}", ex.Message);
                message += Environment.NewLine;
                message += string.Format("InnerException: {0}", ex.InnerException);
                message += Environment.NewLine;
                message += string.Format("StackTrace: {0}", ex.StackTrace);
                message += Environment.NewLine;
                message += string.Format("Source: {0}", ex.Source);
                message += Environment.NewLine;
                message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
                message += Environment.NewLine;
                message += string.Format("Error in TestMethod: {0}", new StackTrace(ex).GetFrames().Select(f => f.GetMethod()).First(m => m.Module.Assembly == Assembly.GetExecutingAssembly()).Name);
                message += Environment.NewLine;
                message += "-----------------------------------------------------------";
                message += Environment.NewLine;
                LogException("EXCEPTION: " + message);
                
            }
            catch (Exception)
            {
                throw;
            }
        }        
        #endregion
    }
}
