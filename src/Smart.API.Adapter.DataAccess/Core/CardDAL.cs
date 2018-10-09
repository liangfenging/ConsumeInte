using Smart.API.Adapter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.API.Adapter.DataAccess.Core
{
    public class CardDAL : DataBase
    {
        public CardDAL()
            : base(DbName.SmartAPIAdapterCore, "Card", "ID")
        { }

        private static CardDAL _ProxyInstance = null;
        private static object _ProxyInstanceLock = new object();
        /// <summary>
        /// 单例模式
        /// </summary>
        public static CardDAL ProxyInstance
        {
            get
            {
                if (_ProxyInstance == null)
                {
                    lock (_ProxyInstanceLock)
                    {
                        if (_ProxyInstance == null)
                        {
                            _ProxyInstance = new CardDAL();
                        }
                    }
                }
                return _ProxyInstance;
            }
        }

        public CardModel GetCardByCardNo(string cardNo)
        {
            string sql = "select * from Card where CardNo = '" + cardNo + "' ";
            return GetEnityBySqlString<CardModel>(sql, null);
        }
    }
}
