using System;

using Android.App;
using Android.Widget;
using Android.OS;
using RasperryClient.Droid._DependencyInjection;
using RasperryClient.Droid.Client;
using System.ServiceModel;

namespace RasperryClient.Droid
{
	[Activity (Label = "RasperryClient.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        private readonly IProxyFactory m_ProxyFactory;
        private IRasperryClientContainer m_Container;    

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Click += Button_Click;
        }

        public MainActivity()
        {
            m_Container = new RasperryClientContainer();
            m_ProxyFactory = m_Container.Resolve<IProxyFactory>();
            m_ProxyFactory.AddClient();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            RasperryServiceClient sd = new RasperryServiceClient(new BasicHttpBinding(), new EndpointAddress( new UriBuilder(Uri.UriSchemeHttp, "localhost",6565, "wcf").Uri));
            sd.DummyMethod();
            //m_ProxyFactory.GetClient().DummyMethod();
        }


    }
}


