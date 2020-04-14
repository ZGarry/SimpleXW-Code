using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.items
{
    public class 饮料币 : Item
    {

        public 饮料币() : base(
             name0: "饮料币", priceLow0: 5, priceHigh0: 5,
            fuc: "获得5枚金币", icon: "",
            des: "经法定程序判决后，可以兑换一瓶饮料", level: "特殊")
        {
        }

        public override void EffectIn(Player p)
        {
            p.Gold += 5;
            p.SendMes($"你正在使用{name}！开心最重要不是么?金币+5。");
        }
    }
}
