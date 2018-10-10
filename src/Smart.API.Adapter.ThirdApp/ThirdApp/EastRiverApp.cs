using Smart.API.Adapter.BizCore;
using Smart.API.Adapter.Models;
using Smart.API.Adapter.Models.EastRiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.API.Adapter.ThirdApp
{
    public class EastRiverApp : IThirdApp
    {
        public int DeptOpr(ref DepartmentModel requestData, int OprType, string thirdParentId, out string message)
        {
            message = "";
            int result = 0;
            DeptModel model = new DeptModel();
            model.depart_id = requestData.ThirdDeptId;
            model.depart_name = requestData.DeptName;


            switch (OprType)
            {
                case 1: //新增
                    if (string.IsNullOrWhiteSpace(thirdParentId))
                    {
                        thirdParentId = "0";

                    }
                    EastRiverBLL bll = new EastRiverBLL();
                    requestData.ThirdDeptId = model.depart_id = bll.GetNewDeptId(thirdParentId);
                    bll.InsertDept(model);

                    break;
                case 2: //更新
                    new EastRiverBLL().UpdateDept(model);
                    break;
                case 3: //删除
                    new EastRiverBLL().DeleteDept(model);
                    break;
                default:
                    break;
            }

            return result;
        }

        public int PersonOpr(ref PersonModel requestData, DepartmentModel Dept, int OprType, out string message)
        {
            message = "";
            int result = 0;
            EmployeeModel model = new EmployeeModel();
            model.card_id = "-1";
            model.depart_id = Dept.ThirdDeptId;
            model.emp_fname = requestData.PersonName;
            model.emp_id = requestData.PersonId;


            switch (OprType)
            {
                case 1: //新增
                    requestData.ThirdPersonId = model.emp_id;
                    new EastRiverBLL().InsertEmployee(model);
                    break;
                case 2: //更新
                    new EastRiverBLL().UpdateEmployee(model);
                    break;
                case 3: //删除
                    new EastRiverBLL().DeleteEmployee(model);
                    break;
                default:
                    break;
            }

            return result;
        }

        public int CardOpr(CardModel requestData, PersonModel person, DepartmentModel dept, int OprType, out string message)
        {
            message = "";
            int result = 0;
            EmployeeCardModel model = new EastRiverBLL().GetEmployeeCardByCarNo(requestData.CardNo);
            if (model == null)
            {
                model = new EmployeeCardModel();
            }
            model.card_id = requestData.CardNo;
            model.emp_id = person.ThirdPersonId;
            model.CardBegDate = requestData.BeginTime;
            model.CardEndDate = requestData.EndTime;


            EmployeeAccountModel accountModel = new EastRiverBLL().GetEmployeeAccountByCarNo(requestData.CardNo);
            if (accountModel == null)
            {
                accountModel = new EmployeeAccountModel();
            }
            accountModel.AppState = 1;
            accountModel.card_id = requestData.CardNo;
            accountModel.emp_id = person.ThirdPersonId;
            accountModel.ExpireDate = requestData.EndTime;

            switch (OprType)
            {
                case 1: //新增

                    model.issue_date = DateTime.Now;
                    model.UseFlag = 1;
                    model.CardState = 1;
                    new EastRiverBLL().InsertEmployeeCard(model);
                    //创建消费账户
                    accountModel.OpenDate = DateTime.Now;
                    new EastRiverBLL().InsertEmployeeAccount(accountModel);
                    break;
                case 2: //退卡
                    model.CardState = 5;//注销
                    float backmoney = 0;
                    float.TryParse(requestData.BackMoney, out backmoney);
                    model.card_balance = model.card_balance - backmoney;
                    new EastRiverBLL().UpdateEmployeeCard(model);

                    //更新消费账户
                    accountModel.card_balance = model.card_balance;
                    new EastRiverBLL().UpdateEmployeeAccount(accountModel);

                    break;
                case 3: //挂失
                    model.CardState = 2;//挂失
                    new EastRiverBLL().UpdateEmployeeCard(model);
                    break;
                case 5: //更新
                    new EastRiverBLL().UpdateEmployeeCard(model);

                    new EastRiverBLL().UpdateEmployeeAccount(accountModel);
                    break;
                default:
                    break;
            }


            return result;
        }

        public int CardChargeOpr(CardChargeModel requestData, int OprType, out string message)
        {
            message = "";
            int result = 0;
            float balance = 0;
            float.TryParse(requestData.AfterMoney, out balance);

            float preMoney = 0;
            float.TryParse(requestData.PreMoney, out preMoney);

            float oprMoney = 0;
            float.TryParse(requestData.OprMoney, out oprMoney);

            EmployeeCardModel model = new EastRiverBLL().GetEmployeeCardByCarNo(requestData.CardNo);
            if (model == null)
            {
                result = 1;
                message = "第三方系统未查询到卡号[" + requestData.CardNo + "]";
            }
            else
            {
                EmployeeAccountModel accountModel = new EastRiverBLL().GetEmployeeAccountByCarNo(requestData.CardNo);
                if (accountModel == null)
                {
                    result = 1;
                    message = "第三方系统消费账户未查询到卡号[" + requestData.CardNo + "]";
                }
                else
                {
                    model.card_balance = balance;
                    accountModel.card_balance = balance;
                    new EastRiverBLL().UpdateEmployeeCard(model);
                    new EastRiverBLL().UpdateEmployeeAccount(accountModel);

                    //TODO: 是否需要更新第三方的充值表 和 退款表
                    switch (OprType)
                    {
                        case 1: //充值

                            break;
                        case 2: //退款

                            break;
                        default:
                            break;
                    }
                }
            }
            return result;
        }

        public int SearchConsumeRecords(requestConsumeRecords requestData, ref responseConsumeRecords records, out string message)
        {
            message = "";
            int result = 0;
            int totalCount = 0;
            int pageCount = 0;
            ICollection<reponseMealRecord> IMealRecords = new EastRiverBLL().GetMealRecords(requestData, out totalCount, out pageCount);
            List<ConsumeRecords> LConsumeRecords = new List<ConsumeRecords>();
            if (IMealRecords != null && IMealRecords.Count > 0)
            {
                foreach (reponseMealRecord item in IMealRecords)
                {
                    ConsumeRecords record = new ConsumeRecords();
                    record.cardNo = item.card_id;
                    record.consumeAmount = item.card_consume.ToString();
                    record.consumeTime = item.sign_time.ToString("yyyy-MM-dd HH:mm:ss");
                    record.recordId = item.nRecSeq.ToString();
                    //record.personId = item.emp_id;//该第三方集成的人员ID为相同，其他的此处可能需要查询数据库获取
                    record.personName = item.emp_fname;
                    record.deptName = item.depart_name;

                    LConsumeRecords.Add(record);
                }
            }
            records.consumeRecords = LConsumeRecords;
            records.pageCount = pageCount;
            records.totalCount = totalCount;
            records.pageIndex = requestData.pageIndex;
            records.pageSize = requestData.pageSize;

            return result;
        }
    }
}
