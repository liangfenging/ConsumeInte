using Smart.API.Adapter.DataAccess.Core;
using Smart.API.Adapter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.API.Adapter.BizCore
{
    public class DepartmentBLL
    {
        /// <summary>
        /// 获取部门
        /// </summary>
        /// <param name="deptId">部门标识</param>
        /// <returns></returns>
        public DepartmentModel GetDepartmentByDeptId(string deptId)
        {
            return DepartmentDAL.ProxyInstance.GetDepartmentByDeptId(deptId);
        }

        public void Insert(DepartmentModel model)
        {
            model.CreateTime = DateTime.Now;
            model.ModifyTime = DateTime.Now;
            DepartmentDAL.ProxyInstance.Insert<DepartmentModel>(model);
        }

        public bool Update(DepartmentModel model)
        {
            model.ModifyTime = DateTime.Now;
           return  DepartmentDAL.ProxyInstance.Update<DepartmentModel>(model, model.ID.ToString());
        }

        public bool Delete(DepartmentModel model)
        {
            model.ModifyTime = DateTime.Now;
            model.Status = 1;
            return DepartmentDAL.ProxyInstance.Update<DepartmentModel>(model, model.ID.ToString());
        }

        public bool DepartHasUse(string deptId)
        {
            return DepartmentDAL.ProxyInstance.DepartHasUse(deptId);
        }
    }
}
