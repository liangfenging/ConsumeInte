using Smart.API.Adapter.DataAccess.Core;
using Smart.API.Adapter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.API.Adapter.BizCore
{
    public class CardChargeBLL
    {
        public void Insert(CardChargeModel model)
        {
            model.CreateTime = DateTime.Now;
            model.ModifyTime = DateTime.Now;
            CardChargeDAL.ProxyInstance.Insert<CardChargeModel>(model);
        }
    }
}
