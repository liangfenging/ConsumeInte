using System;

namespace Smart.API.Adapter.Models.EastRiver
{
    public class EmployeeCardModel
    {
        /// <summary>
        /// 卡号，长度32
        /// 必填
        /// </summary>
        public string card_id
        {
            get;
            set;
        }

        /// <summary>
        /// 工号,长度32
        /// 必填
        /// </summary>
        public string emp_id
        {
            get;
            set;
        }

        /// <summary>
        /// 卡序列号,长度20
        /// 必填
        /// </summary>
        public string card_sn
        {
            get;
            set;
        }

        private int card_type = 1;
        /// <summary>
        /// 默认值1 ID卡
        /// 卡格式种类标识
        /// </summary>
        public int CardType
        {
            get { return card_type; }
            set { card_type = value; }
        }

        /// <summary>
        /// 卡余额，默认0
        /// 必填
        /// </summary>
        public float card_balance
        {
            get;
            set;
        }

        /// <summary>
        /// 启用标识
        /// 0：未启用
        /// 1：已启用
        /// </summary>
        public int UseFlag
        {
            get;
            set;
        }

        /// <summary>
        /// 01全国钱包
        /// 04省钱包
        /// 08企业钱包
        /// 默认0
        /// </summary>
        public int WalletFlag
        {
            get;
            set;
        }

        /// <summary>
        /// 开卡时所交押金
        /// </summary>
        public float DepositValue
        {
            get;
            set;
        }

        /// <summary>
        /// 职工标识
        /// 00非电信职工
        /// 01电信职工
        /// </summary>
        public int CustomerType
        {
            get;
            set;
        }

        /// <summary>
        /// 0初始
        /// 1正常
        /// 2挂失
        /// 3作废
        /// 4删除
        /// 5注销
        /// 6无卡注销
        /// 7挂失补卡
        /// 8坏卡补卡
        /// 9冻结
        /// 10冻结后注销
        /// </summary>
        public int CardState
        {
            get;
            set;
        }

        /// <summary>
        /// 发卡日期
        /// </summary>
        public DateTime issue_date
        {
            get;
            set;
        }

        /// <summary>
        /// 黑名单
        /// </summary>
        public bool is_black
        {
            get;
            set;
        }

        /// <summary>
        /// 黑名单次数
        /// </summary>
        public int black_sequ
        {
            get;
            set;
        }

        /// <summary>
        /// 卡启用日期
        /// </summary>
        public DateTime? CardBegDate
        {
            get;
            set;
        }

        /// <summary>
        /// 卡结束日期
        /// </summary>
        public DateTime? CardEndDate
        {
            get;
            set;
        }

        public int VisitState
        {
            get;
            set;
        }

        public int Allowance_sequ
        {
            get;
            set;
        }
    }
}
