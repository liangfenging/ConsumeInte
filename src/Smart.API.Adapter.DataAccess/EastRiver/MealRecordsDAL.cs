
using Smart.API.Adapter.Models;
using Smart.API.Adapter.Models.EastRiver;
using System;
using System.Collections.Generic;
using System.Data;
namespace Smart.API.Adapter.DataAccess.EastRiver
{
    public class MealRecordsDAL : DataBase
    {
        public MealRecordsDAL()
            : base(DbName.EastRiver, "MealRecords", "nRecSeq")
        { }

        private static MealRecordsDAL _ProxyInstance = null;
        private static object _ProxyInstanceLock = new object();
        /// <summary>
        /// 单例模式
        /// </summary>
        public static MealRecordsDAL ProxyInstance
        {
            get
            {
                if (_ProxyInstance == null)
                {
                    lock (_ProxyInstanceLock)
                    {
                        if (_ProxyInstance == null)
                        {
                            _ProxyInstance = new MealRecordsDAL();
                        }
                    }
                }
                return _ProxyInstance;
            }
        }

        /// <summary>
        /// 获取消费记录
        /// </summary>
        /// <param name="requestData"></param>
        /// <param name="totalCount"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public ICollection<reponseMealRecord> GetMealRecords(requestConsumeRecords requestData, out int totalCount, out int pageCount)
        {
            totalCount = 0;
            pageCount = 0;
            if (requestData.pageIndex <= 0)
            {
                requestData.pageIndex = 1;
            }
            if (requestData.pageSize <= 0)
            {
                requestData.pageSize = 10;
            }

            int pageBegin = (requestData.pageIndex - 1) * requestData.pageSize;
            int pageEnd = requestData.pageIndex * requestData.pageSize;
            //获取消费明细
            string sql = @"select t.nRecSeq,t.clock_id, t.emp_id,t.emp_fname,t.depart_id,t.depart_name, t.card_id,t.card_consume,t.sign_time  from (select ROW_NUMBER() over( order by a.sign_time ) as row_id,a.nRecSeq,a.clock_id, a.emp_id,b.emp_fname,c.depart_id,c.depart_name, a.card_id,a.card_consume,a.sign_time 
                            FROM [MealRecords] a with(nolock) inner join  (select * from [Employee] with(nolock) where emp_fname like '%{0}%' {1} ) b on a.emp_id =b.emp_id
                            inner join  (select * from [Departs] with(nolock) where depart_name like '%{2}%' {3} ) c on b.depart_id = c.depart_id where a.sign_time >='{4}' and a.sign_time<='{5}' {6}) t where row_id> " + pageBegin + " and row_id<=" + pageEnd;

            string sql0 = string.IsNullOrWhiteSpace(requestData.personName) ? "" : requestData.personName.Trim();
            string sql1 = string.IsNullOrWhiteSpace(requestData.ThirdPersonId) ? "" : " and emp_id='" + requestData.ThirdPersonId.Trim() + "' ";
            string sql2 = string.IsNullOrWhiteSpace(requestData.deptName) ? "" : requestData.deptName.Trim();
            string sql3 = string.IsNullOrWhiteSpace(requestData.ThirdDeptId) ? "" : " and depart_id='" + requestData.ThirdDeptId.Trim() + "' ";
            string sql4 = string.IsNullOrWhiteSpace(requestData.startTime) ? DateTime.Now.ToShortDateString() : requestData.startTime;
            string sql5 = string.IsNullOrWhiteSpace(requestData.endTime) ? DateTime.Now.ToShortDateString() : requestData.endTime;
            string sql6 = string.IsNullOrWhiteSpace(requestData.cardNo) ? "" : " and a.card_id='" + requestData.cardNo.Trim() + "' ";
            sql = string.Format(sql, sql0, sql1, sql2, sql3, sql4, sql5, sql6);

            //获取总记录数
            string totalsql = @"select count(0) from [MealRecords]  a with(nolock) inner join  (select * from [Employee] with(nolock) where emp_fname like '%{0}%' {1} ) b on a.emp_id =b.emp_id
                            inner join  (select * from [Departs] with(nolock) where depart_name like '%{2}%' {3} ) c on b.depart_id = c.depart_id where a.sign_time >='{4}' and a.sign_time<='{5}'";
            totalsql = string.Format(totalsql, sql0, sql1, sql2, sql3, sql4, sql5, sql6);

            DataTable dt = GetDataTableBySqlString(totalsql, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                totalCount = int.Parse(dt.Rows[0][0].ToString());
            }

            pageCount = (totalCount + requestData.pageSize - 1) / requestData.pageSize;


            return GetEnityListBySqlString<reponseMealRecord>(sql, null);
        }
    }
}
