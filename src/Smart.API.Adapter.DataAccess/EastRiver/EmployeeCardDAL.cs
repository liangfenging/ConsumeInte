
namespace Smart.API.Adapter.DataAccess.EastRiver
{
    public class EmployeeCardDAL: DataBase
    {
        public EmployeeCardDAL()
            : base(DbName.EastRiver, "EmployeeCard", "card_id", false)
        { }

        private static EmployeeCardDAL _ProxyInstance = null;
        private static object _ProxyInstanceLock = new object();
        /// <summary>
        /// 单例模式
        /// </summary>
        public static EmployeeCardDAL ProxyInstance
        {
            get
            {
                if (_ProxyInstance == null)
                {
                    lock (_ProxyInstanceLock)
                    {
                        if (_ProxyInstance == null)
                        {
                            _ProxyInstance = new EmployeeCardDAL();
                        }
                    }
                }
                return _ProxyInstance;
            }
        }
    }
}
