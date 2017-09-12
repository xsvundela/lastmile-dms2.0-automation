using LastMile.Web.Automation.BRDataTypes;
using Xpo.Common.Configuration;

namespace LastMile.Web.Automation.BRUtilities
{
    public static class CurrentEnvironment
    {
        public static XpoEnvironment GetTestEnvirontment()
        {
            XpoEnvironment env = null;

            if (BRGlobalVars.ISMAIN)
            {
                env = XpoEnvironment.Main;
            }
            else if (BRGlobalVars.ISUAT)
            {
                env = XpoEnvironment.Uat;
            }

            else if (BRGlobalVars.ISQA)
            {
                env = XpoEnvironment.QA;
            }

            return env;
        }

    }
}
