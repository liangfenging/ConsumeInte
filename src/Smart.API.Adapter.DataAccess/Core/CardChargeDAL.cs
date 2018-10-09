using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.API.Adapter.DataAccess.Core
{
    public class CardChargeDAL : DataBase
    {

        public CardChargeDAL()
            : base(DbName.SmartAPIAdapterCore, "CardCharge", "ID")
        { }

        private static CardChargeDAL _ProxyInstance = null;
        private static object _ProxyInstanceLock = new object();
        /// <summary>
        /// 单例模式
        /// </summary>
        public static CardChargeDAL ProxyInstance
        {
            get
            {
                if (_ProxyInstance == null)
                {
                    lock (_ProxyInstanceLock)
                    {
                        if (_ProxyInstance == null)
                        {
                            _ProxyInstance = new CardChargeDAL();
                        }
                    }
                }
                return _ProxyInstance;
            }
        }
    }
}
