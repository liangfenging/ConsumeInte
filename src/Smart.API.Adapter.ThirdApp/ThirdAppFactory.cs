
namespace Smart.API.Adapter.ThirdApp
{
    public class ThirdAppFactory
    {
        public static IThirdApp Create(int type)
        {
            IThirdApp iThirdApp = null;
            switch (type)
            {      
                case (int)enumAppType.EastRiver:
                    iThirdApp = new EastRiverApp();
                    break;
                default:
                    break;
            }

            return iThirdApp;
        }
    }
}
