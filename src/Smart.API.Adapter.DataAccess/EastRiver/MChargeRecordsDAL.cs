
namespace Smart.API.Adapter.DataAccess.EastRiver
{
    public class MChargeRecordsDAL: DataBase
    {
        public MChargeRecordsDAL()
            : base(DbName.EastRiver, "MChargeRecords", "nRecSeq")
        { }

        private static MChargeRecordsDAL _ProxyInstance = null;
        private static object _ProxyInstanceLock = new object();
        /// <summary>
        /// 单例模式
        /// </summary>
        public static MChargeRecordsDAL ProxyInstance
        {
            get
            {
                if (_ProxyInstance == null)
                {
                    lock (_ProxyInstanceLock)
                    {
                        if (_ProxyInstance == null)
                        {
                            _ProxyInstance = new MChargeRecordsDAL();
                        }
                    }
                }
                return _ProxyInstance;
            }
        }
    }
}
