using Smart.API.Adapter.BizCore;
using Smart.API.Adapter.Common;
using Smart.API.Adapter.Models;
using Smart.API.Adapter.ThirdApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.API.Adapter.Biz
{
    public class ConsumeBaseBLL
    {

        /// <summary>
        /// 组织，部门同步操作
        /// </summary>
        /// <param name="requestData"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int DeptOpr(DepartmentModel requestData, out string message)
        {
            message = "";
            int result = 0;

            int OprType = 0;

            if (string.IsNullOrWhiteSpace(requestData.DeptId))
            {
                result = 1;
                message = "参数DeptId不能为空";
                return result;
            }
            if (string.IsNullOrWhiteSpace(requestData.DeptName))
            {
                result = 1;
                message = "参数DeptName不能为空";
                return result;
            }

            //查询是否存在部门
            DepartmentModel deptModel = new DepartmentBLL().GetDepartmentByDeptId(requestData.DeptId);
            if (deptModel != null)
            {
                requestData.ID = deptModel.ID;
                requestData.ThirdDeptId = deptModel.ThirdDeptId;

                OprType = 2;//更新
            }
            else
            {
                OprType = 1;//新增
                if (requestData.Status == 1)
                {
                    result = 1;
                    message = "deptId[" + requestData.DeptId + "]不存在，或已删除";
                    return result;
                }
            }
            if (requestData.Status == 1)
            {
                OprType = 3;//删除
                if (new DepartmentBLL().DepartHasUse(requestData.DeptId))
                {
                    result = 1;
                    message = "deptId[" + requestData.DeptId + "]已被使用，不能删除";
                    return result;
                }
            }
            string thirdParentId = "";
            //判断父节点是否存在
            if (!string.IsNullOrWhiteSpace(requestData.ParentId))
            {
                if (OprType == 2 && deptModel.ParentId != requestData.ParentId)
                {
                    result = 1;
                    message = "deptId[" + requestData.DeptId + "]的父节点不允许进行变更操作";
                    return result;
                }
                DepartmentModel deptParentModel = new DepartmentBLL().GetDepartmentByDeptId(requestData.ParentId);
                if (deptParentModel == null)
                {
                    result = 1;
                    message = "ParentId[" + requestData.ParentId + "]不存在，或已删除";
                    return result;
                }
                else
                {
                    thirdParentId = deptParentModel.ThirdDeptId;
                }
            }

            IThirdApp thirdApp = ThirdAppFactory.Create(Common.CommonSettings.ThirdApp);
            if (thirdApp != null)
            {
                thirdApp.DeptOpr(ref requestData, OprType, thirdParentId, out message);
            }

            switch (OprType)
            {
                case 1: //新增
                    new DepartmentBLL().Insert(requestData);
                    break;
                case 2: //更新
                    new DepartmentBLL().Update(requestData);
                    break;
                case 3: //删除
                    new DepartmentBLL().Delete(requestData);
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// 人员信息同步操作
        /// </summary>
        /// <param name="requestData"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int PersonOpr(PersonModel requestData, out string message)
        {
            message = "";
            int result = 0;

            if (string.IsNullOrWhiteSpace(requestData.PersonId))
            {
                result = 1;
                message = "参数PersonId不能为空";
                return result;
            }



            if (requestData.PersonId.Length > 32)
            {
                result = 1;
                message = "参数PersonId长度不能超过32";
                return result;
            }
            PersonBLL bll = new PersonBLL();
            PersonModel model = bll.GetPersonByPersonId(requestData.PersonId);
            int OprType = 0;
            if (model == null)
            {
                OprType = 1;//新增

            }
            else
            {
                requestData.ThirdPersonId = model.ThirdPersonId;//这些属性不能改变
                requestData.CreateTime = model.CreateTime;
                OprType = 2;//更新
            }
            if (requestData.Status == 1)//删除
            {
                OprType = 3;//删除操作
                if (model == null)
                {
                    result = 1;
                    message = "PersonId[" + requestData.PersonId + "]不存在或已删除";
                    return result;
                }
            }
            if (OprType == 1 || OprType == 2)
            {
                if (string.IsNullOrWhiteSpace(requestData.PersonName))
                {
                    result = 1;
                    message = "参数PersonName不能为空";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(requestData.DeptId))
                {
                    result = 1;
                    message = "参数DeptId不能为空";
                    return result;
                }

                if (requestData.PersonName.Length > 20)
                {
                    result = 1;
                    message = "参数PersonName长度不能超过20";
                    return result;
                }
            }


            DepartmentModel depart = new DepartmentBLL().GetDepartmentByDeptId(requestData.DeptId);
            if (depart == null)
            {
                if (OprType == 1 || OprType == 2)
                {
                    result = 1;
                    message = "DeptId[" + requestData.DeptId + "]不存在，或已删除";
                    return result;
                }
            }

            IThirdApp thirdApp = ThirdAppFactory.Create(Common.CommonSettings.ThirdApp);
            if (thirdApp != null)
            {
                thirdApp.PersonOpr(ref requestData, depart, OprType, out message);
            }

            switch (OprType)
            {
                case 1: //新增
                    new PersonBLL().Insert(requestData);
                    break;
                case 2: //更新
                    new PersonBLL().Update(requestData);
                    break;
                case 3: //删除
                    new PersonBLL().Delete(requestData);
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// 卡操作
        /// </summary>
        /// <param name="requestData"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int CardOpr(requestCardOpr requestData, out string message)
        {
            message = "";
            int result = 0;
            if (string.IsNullOrWhiteSpace(requestData.CardNo))
            {
                result = 1;
                message = "参数CardNo不能为空";
                return result;
            }

            if (string.IsNullOrWhiteSpace(requestData.PersonId))
            {
                //result = 1;
                //message = "参数PersonId不能为空";
                requestData.PersonId = requestData.CardNo.Trim();
                LogHelper.Info("卡操作：传递的参数PersonID为空。使用CardNo进行人事登记");
                //return result;
            }
            string deptId = "00000000-0000-0000-0000-000000000000";
            if (!string.IsNullOrWhiteSpace(requestData.DeptId))
            {
                deptId = requestData.DeptId.Trim();
            }


            DepartmentModel depart = null;
            PersonBLL bll = new PersonBLL();
            PersonModel person = bll.GetPersonByPersonId(requestData.PersonId);
            if (person == null)
            {
                //创建部门和人事资料

                PersonModel requestPerson = new PersonModel();
                requestPerson.PersonName = string.IsNullOrWhiteSpace(requestData.PersonName) ? requestData.PersonId : requestData.PersonName;

                requestPerson.DeptId = deptId;
                DepartmentModel requestDetp = new DepartmentModel();
                requestDetp.DeptId = deptId;
                depart = new DepartmentBLL().GetDepartmentByDeptId(requestDetp.DeptId);
                if (depart == null)
                {
                    requestDetp.DeptName = string.IsNullOrWhiteSpace(requestData.DeptName) ? "默认部门" : requestData.DeptName;
                    requestDetp.DeptNo = deptId;
                    result = DeptOpr(requestDetp, out message);
                    if (result != 0)
                    {
                        return result;
                    }
                }
                result = PersonOpr(requestPerson, out message);
                if (result != 0)
                {
                    return result;
                }
                //result = 1;
                //message = "PersonId[" + requestData.PersonId + "]不存在或已删除";
                //return result;
            }
            if (depart == null)
            {
                depart = new DepartmentBLL().GetDepartmentByDeptId(person.DeptId);
            }
            int OprType = 0;//1:新增发行， 2：退卡, 3:挂失，4，更新
            if (requestData.Status == 1)
            {
                OprType = 2;//退卡
            }
            else if (requestData.Status == 2)
            {
                OprType = 3;//挂失
            }


            CardModel cardModel = new CardBLL().GetCardByCardNo(requestData.CardNo);
            if (OprType != 1)
            {
                if (cardModel == null)
                {
                    result = 1;
                    message = "CardNo[" + requestData.CardNo + "]不存在或已删除";
                    return result;
                }
            }
            if (cardModel == null)
            {
                OprType = 1;
                cardModel = new CardModel();//发行
                cardModel.BackMoney = "";
                cardModel.Balance = "0";
                cardModel.BeginTime = requestData.BeginTime;
                cardModel.CardCost = requestData.CardCost;
                cardModel.CardNo = requestData.CardNo;
                cardModel.EndTime = requestData.EndTime;
                cardModel.PersonId = requestData.PersonId;
                cardModel.Status = requestData.Status;
            }
            else
            {
                OprType = 4;//更新
                cardModel.BeginTime = requestData.BeginTime;
                cardModel.EndTime = requestData.EndTime;
                cardModel.PersonId = requestData.PersonId;
                cardModel.Status = requestData.Status;
                cardModel.CardCost = requestData.CardCost;
            }

            IThirdApp thirdApp = ThirdAppFactory.Create(Common.CommonSettings.ThirdApp);
            if (thirdApp != null)
            {
                thirdApp.CardOpr(cardModel, person, depart, OprType, out message);
            }

            switch (OprType)
            {
                case 1: //新增
                    new CardBLL().Insert(cardModel);
                    break;
                case 2: //退卡
                    float balance = 0;
                    float backmoney = 0;
                    float.TryParse(cardModel.Balance, out balance);
                    float.TryParse(cardModel.BackMoney, out backmoney);
                    cardModel.Balance = (balance - backmoney).ToString();
                    new CardBLL().Delete(cardModel);

                    CardChargeModel chargeModel = new CardChargeModel();
                    chargeModel.CardNo = cardModel.CardNo;
                    chargeModel.AfterMoney = (balance - backmoney).ToString();
                    chargeModel.OprMoney = cardModel.BackMoney;
                    chargeModel.OprType = 2;
                    chargeModel.PreMoney = cardModel.Balance;
                    chargeModel.Remark = "退卡退回金额" + cardModel.BackMoney;

                    new CardChargeBLL().Insert(chargeModel);
                    break;
                case 3: //挂失
                    requestData.Status = 2;
                    new CardBLL().Update(cardModel);
                    break;
                case 4: //更新
                    new CardBLL().Update(cardModel);
                    break;
                default:
                    break;
            }


            return result;
        }

        /// <summary>
        /// 卡充值退款操作
        /// </summary>
        /// <param name="requestData"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int CardChargeOpr(requestCardCharge requestData, out string message)
        {
            message = "";
            int result = 0;
            if (string.IsNullOrWhiteSpace(requestData.CardNo))
            {
                result = 1;
                message = "参数CardNo不能为空";
                return result;
            }

            CardModel cardModel = new CardBLL().GetCardByCardNo(requestData.CardNo);
            if (cardModel == null)
            {
                result = 1;
                message = "CardNo[" + requestData.CardNo + "]不存在或已删除";
                return result;
            }

            int OprType = requestData.OprType;

            IThirdApp thirdApp = ThirdAppFactory.Create(Common.CommonSettings.ThirdApp);
            if (thirdApp == null)
            {
                LogHelper.Error("ThirdApp未配置");
            }

            switch (OprType)
            {
                case 1: //充值
                    CardChargeModel chargeModel = new CardChargeModel();
                    chargeModel.CardNo = cardModel.CardNo;
                    float balance = 0;
                    float oprmoney = 0;
                    float.TryParse(cardModel.Balance, out balance);
                    float.TryParse(requestData.OprMoney, out oprmoney);

                    chargeModel.AfterMoney = (balance + oprmoney).ToString();
                    chargeModel.OprMoney = requestData.OprMoney;
                    chargeModel.OprType = 1;
                    chargeModel.PreMoney = cardModel.Balance;
                    chargeModel.Remark = requestData.Remark;

                    result = thirdApp.CardChargeOpr(chargeModel, OprType, out message);
                    if (result == 0)
                    {
                        new CardChargeBLL().Insert(chargeModel);

                        cardModel.Balance = chargeModel.AfterMoney;
                        new CardBLL().Update(cardModel);
                    }


                    break;
                case 2: //退款
                    CardChargeModel chargeModel2 = new CardChargeModel();
                    chargeModel2.CardNo = cardModel.CardNo;
                    float balance2 = 0;
                    float oprmoney2 = 0;
                    float.TryParse(cardModel.Balance, out balance2);
                    float.TryParse(requestData.OprMoney, out oprmoney2);

                    chargeModel2.AfterMoney = (balance2 - oprmoney2).ToString();
                    chargeModel2.OprMoney = requestData.OprMoney;
                    chargeModel2.OprType = 2;
                    chargeModel2.PreMoney = cardModel.Balance;
                    chargeModel2.Remark = requestData.Remark;

                    result = thirdApp.CardChargeOpr(chargeModel2, OprType, out message);
                    if (result == 0)
                    {
                        new CardChargeBLL().Insert(chargeModel2);
                        cardModel.Balance = chargeModel2.AfterMoney;
                        new CardBLL().Update(cardModel);
                    }
                    break;
                default:
                    break;
            }



            return result;
        }


        /// <summary>
        /// 查询消费记录
        /// </summary>
        /// <param name="requestData"></param>
        /// <param name="records"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int SearchConsumeRecords(requestConsumeRecords requestData, ref responseConsumeRecords records, out string message)
        {
            int result = 0;
            message = "";
            IThirdApp thirdApp = ThirdAppFactory.Create(Common.CommonSettings.ThirdApp);
            if (thirdApp == null)
            {
                result = 1;
                LogHelper.Error("ThirdApp未配置");
            }
            else
            {
                result = thirdApp.SearchConsumeRecords(requestData, ref records, out message);
            }
            return result;
        }

    }
}
