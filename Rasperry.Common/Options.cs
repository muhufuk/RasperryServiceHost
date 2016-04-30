using System;

namespace Ufuk.Rasperry.Common
{
    public class Options : IOptions
    {
        public string BindingType => "BasicHttpBinding";

        public int PortNumber => 6565;

        public string UriScheme => Uri.UriSchemeHttp;
    }
}
