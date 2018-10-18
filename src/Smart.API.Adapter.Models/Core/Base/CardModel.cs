using System;

namespace Smart.API.Adapter.Models
{

    public class requestCardOpr
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo
        {
            get;
            set;
        }

        /// <summary>
        /// 人员标识
        /// </summary>
        public string PersonId
        {
            get;
            set;
        }

        public string PersonName
        {
            get;
            set;
        }

        /// <summary>
        /// 部门标识
        /// </summary>
        public string DeptId
        {
            get;
            set;
        }

        public string DeptName
        {
            get;
            set;
        }

        /// <summary>
        /// 卡成本
        /// </summary>
        public string CardCost
        {
            get;
            set;
        }

        /// <summary>
        /// 状态
        /// 0：正常
        /// 1：退卡
        /// 2：挂失
        /// </summary>
        public int Status
        {
            get;
            set;
        }

        /// <summary>
        /// 退回金额
        /// </summary>
        public string BackMoney
        {
            get;
            set;
        }

        /// <summary>
        /// 启用开始时间
        /// </summary>
        public DateTime? BeginTime
        {
            get;
            set;
        }

        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime? EndTime
        {
            get;
            set;
        }
    }


    public class requestCardInfo
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo
        {
            get;
            set;
        }
    }


    public class CardModel
    {
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo
        {
            get;
            set;
        }

        /// <summary>
        /// 人员标识
        /// </summary>
        public string PersonId
        {
            get;
            set;
        }

        /// <summary>
        /// 余额
        /// </summary>
        public string Balance
        {
            get;
            set;
        }

        /// <summary>
        /// 卡成本
        /// </summary>
        public string CardCost
        {
            get;
            set;
        }

        /// <summary>
        /// 状态
        /// 0：正常
        /// 1：退卡
        /// 2：挂失
        /// </summary>
        public int Status
        {
            get;
            set;
        }

        /// <summary>
        /// 退回金额
        /// </summary>
        public string BackMoney
        {
            get;
            set;
        }

        /// <summary>
        /// 启用开始时间
        /// </summary>
        public DateTime? BeginTime
        {
            get;
            set;
        }

        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime? EndTime
        {
            get;
            set;
        }

        public DateTime CreateTime
        {
            get;
            set;
        }

        public DateTime ModifyTime
        {
            get;
            set;
        }
    }
}
