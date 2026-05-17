using MSharp;
using Domain;

namespace Login
{
    public class DispatchPage : SubPage<LoginPage>
    {
        public DispatchPage()
        {
            OnStart(x =>
            {
                x.If(AppRole.Admin).Go("/home").RunServerSide();
                x.Go("/home").RunServerSide();
            });
        }
    }
}