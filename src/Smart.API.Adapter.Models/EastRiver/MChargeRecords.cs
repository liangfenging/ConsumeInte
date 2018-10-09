using System;

namespace Smart.API.Adapter.Models.EastRiver
{
    /// <summary>
    /// 充值表
    /// </summary>
    public class MChargeRecords
    {
        public string emp_id
        {
            get;
            set;
        }

        public string card_id
        {
            get;
            set;
        }

        /// <summary>
        /// 充值金额
        /// </summary>
        public float charge_money
        {
            get;
            set;
        }

        public float card_balance
        {
            get;
            set;
        }

        public int card_times
        {
            get;
            set;
        }

        public int card_sequ
        {
            get;
            set;
        }

        /// <summary>
        /// 现金充值，0发卡,1
        /// 2累加补贴
        /// 3批量充值
        /// 4充值退款
        /// 6出纳机充值
        /// 7充值优惠
        /// 8清零补贴
        /// 9消费灰记录转充值
        /// 10补贴灰记录转充值
        /// 13充值灰记录转充值
        /// 11补卡清零补贴
        /// </summary>
        public int Kind
        {
            get;
            set;
        }

        public DateTime op_vmd
        {
            get;
            set;
        }

        public string op_user
        {
            get;
            set;
        }

        public string remark
        {
            get;
            set;
        }

        public int difine_sequ
        {
            get;
            set;
        }
    }
}
