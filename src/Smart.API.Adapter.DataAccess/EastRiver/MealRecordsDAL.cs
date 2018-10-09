
namespace Smart.API.Adapter.DataAccess.EastRiver
{
    public class MealRecordsDAL: DataBase
    {
        public MealRecordsDAL()
            : base(DbName.EastRiver, "MealRecords", "nRecSeq")
        { }

        private static MealRecordsDAL _ProxyInstance = null;
        private static object _ProxyInstanceLock = new object();
        /// <summary>
        /// 单例模式
        /// </summary>
        public static MealRecordsDAL ProxyInstance
        {
            get
            {
                if (_ProxyInstance == null)
                {
                    lock (_ProxyInstanceLock)
                    {
                        if (_ProxyInstance == null)
                        {
                            _ProxyInstance = new MealRecordsDAL();
                        }
                    }
                }
                return _ProxyInstance;
            }
        }
    }
}
