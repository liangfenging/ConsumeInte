using Smart.API.Adapter.DataAccess.Core;
using Smart.API.Adapter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.API.Adapter.BizCore
{
    public class CardBLL
    {
        public void Insert(CardModel model)
        {
            model.CreateTime = DateTime.Now;
            model.ModifyTime = DateTime.Now;
            CardDAL.ProxyInstance.Insert<CardModel>(model);
        }

        public bool Update(CardModel model)
        {
            model.ModifyTime = DateTime.Now;
            return CardDAL.ProxyInstance.Update<CardModel>(model, model.ID.ToString());
        }

        public bool Delete(CardModel model)
        {
            model.ModifyTime = DateTime.Now;
            model.Status = 1;
            return CardDAL.ProxyInstance.Update<CardModel>(model, model.ID.ToString());
        }

        public CardModel GetCardByCardNo(string cardNo)
        {
            return CardDAL.ProxyInstance.GetCardByCardNo(cardNo);
        }
    }
}
