using System;

namespace Smart.API.Adapter.Models.EastRiver
{
    /// <summary>
    /// 消费明细表
    /// </summary>
    public class MealRecordsModel
    {
        /// <summary>
        /// 卡交易流水号
        /// </summary>
        public int card_sequ
        {
            get;
            set;
        }

        /// <summary>
        /// 消费机号
        /// </summary>
        public int clock_id
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
        /// 卡号，必填
        /// </summary>
        public string card_id
        {
            get;
            set;
        }

        public DateTime sign_time
        {
            get;
            set;
        }
        /// <summary>
        /// 0正常消费
        /// 3消费冲正(退误扣款)
        /// 102 退款
        /// 104消费纠错
        /// 105消费补单
        /// 106清零退卡退补贴
        /// 201联机交易
        /// 202记账交易
        /// </summary>
        public int Flag
        {
            get;
            set;
        }

        /// <summary>
        /// 加卡次数
        /// </summary>
        public int card_times
        {
            get;
            set;
        }

        /// <summary>
        /// 消费额
        /// </summary>
        public float card_consume
        {
            get;
            set;
        }

        public float card_balance
        {
            get;
            set;
        }

        public int Passed
        {
            get;
            set;
        }

        /// <summary>
        /// 0 定额消费
        /// 1 计次
        /// </summary>
        public int Mealtype
        {
            get;
            set;
        }

        public DateTime op_vmd
        {
            get;
            set;
        }

        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime dAccDate
        {
            get;
            set;
        }

        /// <summary>
        /// 自增长序列号
        /// </summary>
        public int nRecSeq
        {
            get;
            set;
        }

        /// <summary>
        /// 实时交易流水号
        /// </summary>
        public int OnLineId
        {
            get;
            set;
        }

        /// <summary>
        /// 钱包号
        /// </summary>
        public int WalletFlag
        {
            get;
            set;
        }

        public int BusiType
        {
            get;
            set;
        }

        /// <summary>
        /// 1原依时利卡格式
        /// </summary>
        public int CardFormat
        {
            get;
            set;
        }

        /// <summary>
        /// 补贴余额
        /// </summary>
        public float AllowanceBalance
        {
            get;
            set;
        }

        public int other_id
        {
            get;
            set;
        }

        public int PushResult
        {
            get;
            set;
        }

    }


    public class reponseMealRecord
    {
        //t.emp_id,t.emp_fname,t.depart_id,t.depart_name, t.card_id,t.card_consume,t.sign_tim

        public int nRecSeq
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

        public string emp_fname
        {
            get;
            set;
        }

        public string depart_id
        {
            get;
            set;
        }

        public string depart_name
        {
            get;
            set;
        }

        /// <summary>
        /// 卡号，必填
        /// </summary>
        public string card_id
        {
            get;
            set;
        }

        /// <summary>
        /// 设备ID
        /// </summary>
        public string clock_id
        {
            get;
            set;
        }

        public string card_consume
        {
            get;
            set;
        }

        public DateTime sign_time
        {
            get;
            set;
        }
    }
}
