using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.API.Adapter.Models
{
    public class ConsumeRecords
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        public string recordId
        {
            get;
            set;
        }


        //public string personId
        //{
        //    get;
        //    set;
        //}

        public string personName
        {
            get;
            set;
        }
        /// <summary>
        /// 消费机设备ID
        /// </summary>
        public string deviceId
        {
            get;
            set;
        }

        /// <summary>
        /// 消费机名称
        /// </summary>
        public string deviceName
        {
            get;
            set;
        }
        
        /// <summary>
        /// 餐厅ID
        /// </summary>
        public string dinRoomId
        {
            get;
            set;
        }

        /// <summary>
        /// 餐厅名称
        /// </summary>
        public string dinRoomName
        {
            get;
            set;
        }

        public string deptName
        {
            get;
            set;
        }

        /// <summary>
        /// 卡号
        /// </summary>
        public string cardNo
        {
            get;
            set;
        }

        /// <summary>
        /// 消费金额
        /// </summary>
        public string consumeAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 消费时间
        /// </summary>
        public string consumeTime
        {
            get;
            set;
        }
    }

    public class requestConsumeRecords : PagesBase
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public string cardNo
        {
            get;
            set;
        }

        public string personId
        {
            get;
            set;
        }

        public string personName
        {
            get;
            set;
        }

        public string deptId
        {
            get;
            set;
        }

        public string deptName
        {
            get;
            set;
        }

        /// <summary>
        /// 餐厅名称
        /// </summary>
        public string dinRoomName
        {
            get;
            set;
        }

        public string startTime
        {
            get;
            set;
        }

        public string endTime
        {
            get;
            set;
        }


        public string ThirdPersonId
        {
            get;
            set;
        }

        /// <summary>
        /// 集成第三方的部门标识
        /// </summary>
        public string ThirdDeptId
        {
            get;
            set;
        }

      
    }

    public class responseConsumeRecords : PagesBase
    {
        public List<ConsumeRecords> consumeRecords
        {
            get;
            set;
        }
    }
}
