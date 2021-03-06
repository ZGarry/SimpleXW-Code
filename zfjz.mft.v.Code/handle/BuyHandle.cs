﻿using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;
using zfjz.mft.v.Code.items;
using zfjz.mft.v.Code.shop;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void BuyHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
            var qq = e.FromQQ.Id;

            //获取个人信息
            if (!Game.Players.ContainsKey(qq))
            {
                FixStroy.WarnNoCreateUser(e);
                return;
            }
            var p = Game.Players[qq];
            p.SetEIn(e);

            if (e.Message.Text.Contains("购买#"))
            {
                //展示信息
                var name = e.Message.Text.Split('#')[1];
                Shop.ItemBuy(p, name);
            }

            return;
        }



    }
}

