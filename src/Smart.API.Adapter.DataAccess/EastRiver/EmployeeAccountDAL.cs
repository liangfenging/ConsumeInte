
namespace Smart.API.Adapter.DataAccess.EastRiver
{
    public class EmployeeAccountDAL : DataBase
    {
        public EmployeeAccountDAL()
            : base(DbName.EastRiver, "EmployeeAccount", "card_id", false)
        { }

        private static EmployeeAccountDAL _ProxyInstance = null;
        private static object _ProxyInstanceLock = new object();
        /// <summary>
        /// 单例模式
        /// </summary>
        public static EmployeeAccountDAL ProxyInstance
        {
            get
            {
                if (_ProxyInstance == null)
                {
                    lock (_ProxyInstanceLock)
                    {
                        if (_ProxyInstance == null)
                        {
                            _ProxyInstance = new EmployeeAccountDAL();
                        }
                    }
                }
                return _ProxyInstance;
            }
        }
    }
}
