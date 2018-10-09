
namespace Smart.API.Adapter.DataAccess.EastRiver
{
    public class MRefundDAL: DataBase
    {
        public MRefundDAL()
            : base(DbName.EastRiver, "MRefund", "id")
        { }

        private static MRefundDAL _ProxyInstance = null;
        private static object _ProxyInstanceLock = new object();
        /// <summary>
        /// 单例模式
        /// </summary>
        public static MRefundDAL ProxyInstance
        {
            get
            {
                if (_ProxyInstance == null)
                {
                    lock (_ProxyInstanceLock)
                    {
                        if (_ProxyInstance == null)
                        {
                            _ProxyInstance = new MRefundDAL();
                        }
                    }
                }
                return _ProxyInstance;
            }
        }
    }
}
