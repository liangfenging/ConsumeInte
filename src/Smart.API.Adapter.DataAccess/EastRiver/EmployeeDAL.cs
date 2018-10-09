
using Smart.API.Adapter.Models.EastRiver;

namespace Smart.API.Adapter.DataAccess.EastRiver
{
    public class EmployeeDAL: DataBase
    {
        public EmployeeDAL()
            : base(DbName.EastRiver, "Employee", "emp_id", false)
        { }

        private static EmployeeDAL _ProxyInstance = null;
        private static object _ProxyInstanceLock = new object();
        /// <summary>
        /// 单例模式
        /// </summary>
        public static EmployeeDAL ProxyInstance
        {
            get
            {
                if (_ProxyInstance == null)
                {
                    lock (_ProxyInstanceLock)
                    {
                        if (_ProxyInstance == null)
                        {
                            _ProxyInstance = new EmployeeDAL();
                        }
                    }
                }
                return _ProxyInstance;
            }
        }

        public void InsertEmployee(EmployeeModel model)
        { 
            
        }
    }
}
