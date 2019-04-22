using SeleniumExtras.PageObjects;

namespace TestFramework.Pages
{
    public static class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browser.Driver, page);

            return page;
        }

        public static NavigationPage Navigation
        {
            get { return GetPage<NavigationPage>(); }
        }

        public static LoginPage Login
        {
            get { return GetPage<LoginPage>(); }
        }

        public static DashboardPage Dashboard
        {
            get { return GetPage<DashboardPage>(); }
        }

        public static MusicianProfilePage MusicianProfile
        {
            get { return GetPage<MusicianProfilePage>(); }
        }

        public static AdsPage Ads
        {
            get { return GetPage<AdsPage>(); }
        }
    }
}
