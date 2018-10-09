using Smart.API.Adapter.Models.EastRiver;

namespace Smart.API.Adapter.DataAccess.EastRiver
{
    public class DeptDAL : DataBase
    {
        public DeptDAL()
            : base(DbName.EastRiver, "Departs", "depart_id", false)
        { }


        private static DeptDAL _ProxyInstance = null;
        private static object _ProxyInstanceLock = new object();
        /// <summary>
        /// 单例模式
        /// </summary>
        public static DeptDAL ProxyInstance
        {
            get
            {
                if (_ProxyInstance == null)
                {
                    lock (_ProxyInstanceLock)
                    {
                        if (_ProxyInstance == null)
                        {
                            _ProxyInstance = new DeptDAL();
                        }
                    }
                }
                return _ProxyInstance;
            }
        }

        public void InsertDept(DeptModel model)
        {
            Insert<DeptModel>(model);
        }

        public bool DeleteDept(DeptModel model)
        {
            return DeleteByKey(model.depart_id);
        }

        public bool UpdateDept(DeptModel model)
        {
            return Update<DeptModel>(model, model.depart_id);
        }

        /// <summary>
        /// 生成depart_id
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public string GetNewDeptId(string parentId)
        {
            string sql = "select Top 1 * from Departs where len(depart_id)=" + (parentId.Length + 2) + " order by depart_id desc";
            DeptModel model = GetEnityBySqlString<DeptModel>(sql, null);
            if (model != null)
            {
                int tempId = 0;
                int.TryParse(model.depart_id, out tempId);
                return (tempId + 1).ToString().PadLeft(parentId.Length + 2, '0');
            }
            else
            {
                return parentId + "01";
            }
        }
    }
}
