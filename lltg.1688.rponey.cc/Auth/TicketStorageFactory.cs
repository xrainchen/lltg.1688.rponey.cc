using lltg._1688.rponey.cc.Auth.Imp;

namespace lltg._1688.rponey.cc.Auth
{
    /// <summary>
    /// 票据存储工厂
    /// </summary>
    public class TicketStorageFactory
    {
        public static ITicketStorage<T> InstanceTicketStorage<T>()
        {
            return (ITicketStorage<T>)new UserCookieTickStorage();
        }
    }
}