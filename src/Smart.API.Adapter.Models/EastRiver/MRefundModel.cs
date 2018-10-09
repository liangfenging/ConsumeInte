using System;

namespace Smart.API.Adapter.Models.EastRiver
{
    /// <summary>
    /// 退款明细表
    /// </summary>
    public class MRefundModel
    {
        /// <summary>
        /// 自增长
        /// </summary>
        public int id
        {
            get;
            set;
        }

        /// <summary>
        /// 工号
        /// </summary>
        public string emp_id
        {
            get;
            set;
        }

        /// <summary>
        /// 卡号
        /// </summary>
        public string card_id
        {
            get;
            set;
        }

        /// <summary>
        /// 原卡余额
        /// </summary>
        public float old_card_balance
        {
            get;
            set;
        }

        /// <summary>
        /// 退款金额
        /// </summary>
        public float back_money
        {
            get;
            set;
        }

        /// <summary>
        /// 退后余额
        /// </summary>
        public float card_balance
        {
            get;
            set;
        }

        /// <summary>
        /// 卡次
        /// </summary>
        public int card_times
        {
            get;
            set;
        }

        /// <summary>
        /// 当退卡时退卡的成本金额
        /// </summary>
        public float card_cost
        {
            get;
            set;
        }
        /// <summary>
        /// 0退款
        /// 1退卡
        /// </summary>
        public int kind
        {
            get;
            set;
        }

        public string op_user
        {
            get;
            set;
        }

        public DateTime op_date
        {
            get;
            set;
        }
    }
}
