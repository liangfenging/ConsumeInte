using System;

namespace Smart.API.Adapter.Models.EastRiver
{
    public class EmployeeAccountModel
    {
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

        public int AccountID
        {
            get;
            set;
        }

        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime? ExpireDate
        {
            get;
            set;
        }

        /// <summary>
        /// 卡余额
        /// </summary>
        public float card_balance
        {
            get;
            set;
        }

        /// <summary>
        /// 卡交易流水号
        /// </summary>
        public int card_sequ
        {
            get;
            set;
        }

        /// <summary>
        /// 超额消费密码
        /// </summary>
        public string over_pwd
        {
            get;
            set;
        }

        /// <summary>
        /// 默认0
        /// </summary>
        public float EpOverDraft
        {
            get;
            set;
        }

        /// <summary>
        /// 联机最大金额
        /// 默认0
        /// </summary>
        public float OnLineMaxJe
        {
            get;
            set;
        }

        /// <summary>
        /// 0未锁定
        /// 1已锁定
        /// </summary>
        public bool IsLock
        {
            get;
            set;
        }

        /// <summary>
        /// 0:未洗卡
        /// 1：已洗卡
        /// </summary>
        public bool IsWash
        {
            get;
            set;
        }

        public DateTime OpenDate
        {
            get;
            set;
        }

        public int AppState
        {
            get;
            set;
        }

        /// <summary>
        /// 超过异常记录处理等待天数上限
        /// </summary>
        public int bOverDiffPeriod
        {
            get;
            set;
        }

        public float nAccountBalance
        {
            get;
            set;
        }

        public bool UsePwd
        {
            get;
            set;
        }

        /// <summary>
        /// 0
        /// </summary>
        public float AllowanceBalance
        {
            get;
            set;
        }
    }
}
