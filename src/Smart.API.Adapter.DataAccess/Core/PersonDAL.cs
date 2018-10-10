using Smart.API.Adapter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.API.Adapter.DataAccess.Core
{
    public class PersonDAL : DataBase
    {
        public PersonDAL()
            : base(DbName.SmartAPIAdapterCore, "Person", "ID")
        { }

        private static PersonDAL _ProxyInstance = null;
        private static object _ProxyInstanceLock = new object();
        /// <summary>
        /// 单例模式
        /// </summary>
        public static PersonDAL ProxyInstance
        {
            get
            {
                if (_ProxyInstance == null)
                {
                    lock (_ProxyInstanceLock)
                    {
                        if (_ProxyInstance == null)
                        {
                            _ProxyInstance = new PersonDAL();
                        }
                    }
                }
                return _ProxyInstance;
            }
        }

        public PersonModel GetPersonByPersonId(string personId)
        {
            string sql = "select * from Person where PersonId = '" + personId + "' and  Status = 0";
            return GetEnityBySqlString<PersonModel>(sql, null);
        }


        public PersonModel GetPersonByThirdPersonId(string thirdPersonId)
        {
            string sql = "select * from Person where ThirdPersonId = '" + thirdPersonId + "' and  Status = 0";
            return GetEnityBySqlString<PersonModel>(sql, null);
        }
    }
}
