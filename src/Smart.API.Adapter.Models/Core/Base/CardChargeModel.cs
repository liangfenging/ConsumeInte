using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.API.Adapter.Models
{
    public class CardChargeModel
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
        /// 操作类型
        /// 1：充值
        /// 2:退款
        /// </summary>
        public int OprType
        {
            get;
            set;
        }

        /// <summary>
        /// 操作前卡余额
        /// </summary>
        public string PreMoney
        {
            get;
            set;
        }

        /// <summary>
        /// 操作金额
        /// </summary>
        public string OprMoney
        {
            get;
            set;
        }

        /// <summary>
        /// 操作后卡余额
        /// </summary>
        public string AfterMoney
        {
            get;
            set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
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


    public class requestCardCharge
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
        /// 操作类型
        /// 1：充值
        /// 2:退款
        /// </summary>
        public int OprType
        {
            get;
            set;
        }


        /// <summary>
        /// 操作金额
        /// </summary>
        public string OprMoney
        {
            get;
            set;
        }



        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get;
            set;
        }
        
    }
}
