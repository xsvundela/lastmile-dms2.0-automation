using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpo.Common.Configuration;
using Xpo.Common.XpoApiClient;
using System.Net;

namespace LM_DMS2._0_UI_Automation.LMAPI.ConsumerTrackingAPI.Common
{
    public class LMApiClient : XpoApiClientBase
    {
        public LMApiClient()          
        {
        }

        #region Members
        public static bool status = false;
        #endregion members
        // XPORates(RQ)_ApiAutomation
        protected Uri BaseUri;
        /// <summary>
        /// The URL
        /// </summary>
        private const string HostUri = "int-xlmapi.xpo.com";

        /// <summary>
        /// The supported regions
        /// </summary>
        private readonly IList<XpoRegion> SupportedRegions = new List<XpoRegion> { XpoRegion.US, XpoRegion.EU };

        /// <summary>
        /// The uris us
        /// </summary>
        private static readonly IDictionary<XpoEnvironment, Uri> UrisUS = new Dictionary<XpoEnvironment, Uri>()
        {
            { XpoEnvironment.Local, new Uri($"http://localhost/{HostUri}/") },
            { XpoEnvironment.Dev, new Uri($"http://xeawebdev01.devxpo.pvt/{HostUri}/") },
            { XpoEnvironment.Main, new Uri($"http://XEAWEBMAIN01.devxpo.pvt/{HostUri}/") },
            { XpoEnvironment.QA, new Uri($"http://xeaqa.xpo.com/{HostUri}/") },
            { XpoEnvironment.Uat, new Uri($"http://xeauat.xpo.com/{HostUri}/") },
            { XpoEnvironment.Perf, new Uri($"http://xeaperf.xpo.com/{HostUri}/") },
            { XpoEnvironment.Prod, new Uri($"http://xea.xpo.com/{HostUri}/") },
        };

        /// <summary>
        /// The uris eu
        /// </summary>
        private static readonly IDictionary<XpoEnvironment, Uri> UrisEU = new Dictionary<XpoEnvironment, Uri>()
        {
            {XpoEnvironment.Local, new Uri($"http://localhost/{HostUri}/")},
            {XpoEnvironment.Dev, new Uri($"http://xeaeu-dev.xpo.com/{HostUri}/")},
            {XpoEnvironment.QA, new Uri($"http://xeaeu-rec.xpo.com/{HostUri}/")},
            {XpoEnvironment.Uat, new Uri($"http://xeaeu-int.xpo.com/{HostUri}/")},
            {XpoEnvironment.Prod, new Uri($"http://xeaeu.xpo.com/{HostUri}/")}
        };

        private readonly Uri _baseUri;

        public LMApiClient(XpoEnvironment environment, XpoRegion region)
            : this(environment, region, null)
        {
        }

        public LMApiClient(XpoEnvironment environment, XpoRegion region, string baseUriConfigKey)
        {
            if (environment == null)
                throw new ArgumentNullException(nameof(environment));

            if (region == null || !SupportedRegions.Contains(region))
                region = XpoRegion.US;

            if (!string.IsNullOrWhiteSpace(baseUriConfigKey))
                Uri.TryCreate(ConfigurationManager.AppSettings[baseUriConfigKey], UriKind.Absolute, out _baseUri);

            if (_baseUri == null && region == XpoRegion.US && !UrisUS.TryGetValue(environment, out _baseUri))
                throw new ArgumentOutOfRangeException(nameof(environment), $"Could not retrieve url for environment: {environment.Name} and region: {region.Name}");

            if (_baseUri == null && region == XpoRegion.EU && !UrisEU.TryGetValue(environment, out _baseUri))
                throw new ArgumentOutOfRangeException(nameof(environment), $"Could not retrieve url for environment: {environment.Name} and region: {region.Name}");
        }

        public LMApiClient(Uri baseUri)
        {
            BaseUri = baseUri;
        }

        public static HttpStatusCode PingHost(string hostAddress)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(hostAddress);
                request.Timeout = 30000;
                request.AllowAutoRedirect = false; // find out if this host is up and don't follow a redirector  
                using (var response = request.GetResponse())
                {
                    return HttpStatusCode.OK;
                }
            }
            catch (Exception)
            {
                return HttpStatusCode.NotFound;
            }
        }
        public static void PingServerUrl(string hostAddress)
        {
            try
            {
                HttpStatusCode pingStatus = PingHost(hostAddress);
                if (pingStatus != HttpStatusCode.OK)
                {
                    if (status == false)
                    {
                       // LogWarning("The Server is down:-" + hostAddress);
                        status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex);
                throw;
            }
        }

    }
}
