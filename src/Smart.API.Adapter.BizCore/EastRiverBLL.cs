using Smart.API.Adapter.DataAccess.EastRiver;
using Smart.API.Adapter.Models;
using Smart.API.Adapter.Models.EastRiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.API.Adapter.BizCore
{
    public class EastRiverBLL
    {
        public string GetNewDeptId(string parentId)
        {
            return DeptDAL.ProxyInstance.GetNewDeptId(parentId);
        }

        public DeptModel GetDept(string dept_id)
        {
            return DeptDAL.ProxyInstance.FindByKey<DeptModel>(dept_id);
        }
        /// <summary>
        /// 新增组织
        /// </summary>
        /// <param name="model"></param>
        public void InsertDept(DeptModel model)
        {
            DeptDAL.ProxyInstance.InsertDept(model);
        }

        /// <summary>
        /// 更新组织
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateDept(DeptModel model)
        {
            return DeptDAL.ProxyInstance.UpdateDept(model);
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteDept(DeptModel model)
        {
            return DeptDAL.ProxyInstance.DeleteDept(model);
        }

        /// <summary>
        /// 新增人员
        /// </summary>
        /// <param name="model"></param>
        public void InsertEmployee(EmployeeModel model)
        {
            EmployeeDAL.ProxyInstance.Insert<EmployeeModel>(model);
        }

        /// <summary>
        /// 更新人员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateEmployee(EmployeeModel model)
        {
            return EmployeeDAL.ProxyInstance.Update<EmployeeModel>(model, model.emp_id);
        }

        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteEmployee(EmployeeModel model)
        {
            model.status_id = "DE";//离职
            model.leave_date = DateTime.Now;
            model.dimission_type_id = "1";
            return EmployeeDAL.ProxyInstance.Update<EmployeeModel>(model, model.emp_id);
        }



        /// <summary>
        /// 发行新卡
        /// </summary>
        /// <param name="model"></param>
        public void InsertEmployeeCard(EmployeeCardModel model)
        {
            EmployeeCardDAL.ProxyInstance.Insert<EmployeeCardModel>(model);
        }

        /// <summary>
        /// 更新卡
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateEmployeeCard(EmployeeCardModel model)
        {
            return EmployeeCardDAL.ProxyInstance.Update<EmployeeCardModel>(model, model.card_id);
        }

        /// <summary>
        /// 通过卡号 获取卡信息
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public EmployeeCardModel GetEmployeeCardByCardNo(string cardNo)
        {
            return EmployeeCardDAL.ProxyInstance.FindByKey<EmployeeCardModel>(cardNo);
        }

        /// <summary>
        /// 创建消费账户
        /// </summary>
        /// <param name="model"></param>
        public void InsertEmployeeAccount(EmployeeAccountModel model)
        {
            EmployeeAccountDAL.ProxyInstance.Insert<EmployeeAccountModel>(model);
        }

        /// <summary>
        /// 更新消费账户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateEmployeeAccount(EmployeeAccountModel model)
        {
            return EmployeeAccountDAL.ProxyInstance.Update<EmployeeAccountModel>(model, model.card_id);
        }

        /// <summary>
        /// 通过卡号获取消费账户
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public EmployeeAccountModel GetEmployeeAccountByCardNo(string cardNo)
        {
            return EmployeeAccountDAL.ProxyInstance.FindByKey<EmployeeAccountModel>(cardNo);
        }

        public ICollection<reponseMealRecord> GetMealRecords(requestConsumeRecords requestData, out int totalCount, out int pageCount)
        {
            return MealRecordsDAL.ProxyInstance.GetMealRecords(requestData, out totalCount, out pageCount);
        }

    }
}
