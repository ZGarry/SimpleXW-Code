using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.player;
using zfjz.mft.v.Code.shop;

namespace zfjz.mft.v.Code.items
{
    public class 窃贼指环 : Item
    {
        public 窃贼指环() : base(
            name0: "窃贼指环", priceLow0: 11, priceHigh0: 22,
            fuc: "商店最低价商品和最高价商品，交换价格", icon: "",
            des: "是...是置换反应！", level: "B")
        {

        }
        public override void EffectIn(Player p)
        {

            p.SendMes($"你使用了{name}，偷偷更换了商店两个价码牌，希望你的行为能不被发现！");
            var max = -10000;
            var maxk = "";
            var min = 10000;
            var mink = "";
            foreach (var c in Shop.Items.Dic.Keys)
            {
                if (Shop.Items.Dic[c] >= max)
                {
                    max = Shop.Items.Dic[c];
                    maxk = c;
                }
                if (Shop.Items.Dic[c] <= min)
                {
                    min = Shop.Items.Dic[c];
                    mink = c;
                }
            }

            shop.Shop.Items.Set(maxk, min);
            shop.Shop.Items.Set(mink, max);



        }
    }
}
