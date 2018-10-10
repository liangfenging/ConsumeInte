using Smart.API.Adapter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.API.Adapter.DataAccess.Core
{
    public class DepartmentDAL : DataBase
    {
        public DepartmentDAL()
            : base(DbName.SmartAPIAdapterCore, "Department", "ID")
        { }

        private static DepartmentDAL _ProxyInstance = null;
        private static object _ProxyInstanceLock = new object();
        /// <summary>
        /// 单例模式
        /// </summary>
        public static DepartmentDAL ProxyInstance
        {
            get
            {
                if (_ProxyInstance == null)
                {
                    lock (_ProxyInstanceLock)
                    {
                        if (_ProxyInstance == null)
                        {
                            _ProxyInstance = new DepartmentDAL();
                        }
                    }
                }
                return _ProxyInstance;
            }
        }

        public DepartmentModel GetDepartmentByDeptId(string deptId)
        {
            string sql = "select * from Department where DeptId = '" + deptId + "' and  Status = 0";
            return GetEnityBySqlString<DepartmentModel>(sql, null);
        }


        public DepartmentModel GetDepartmentByThirdDeptId(string thirdDeptId)
        {
            string sql = "select * from Department where ThirdDeptId = '" + thirdDeptId + "' and  Status = 0";
            return GetEnityBySqlString<DepartmentModel>(sql, null);
        }

        /// <summary>
        /// 部门是否已经被使用
        /// 被使用，不能删除
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public bool DepartHasUse(string deptId)
        {
            string sql = "select top 1 * from Person where DeptId = '" + deptId + "' and Status = 0";
            if (GetEnityBySqlString<PersonModel>(sql, null) != null)
            {
                return true;
            }
            return false;
        }
    }
}
