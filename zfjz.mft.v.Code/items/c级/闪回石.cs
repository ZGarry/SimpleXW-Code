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
    public class 闪回石 : Item
    {

        public 闪回石() : base(
            name0: "闪回石", priceLow0: 1, priceHigh0: 7,
            fuc: "疯狂-7，超过部分加体质", icon: "",
            des: "其上有闪电回文", level: "C")
        {
        }

        public override void EffectIn(Player p)
        {
                p.Crazy -= 7;
                p.SendMes($"正在摩挲{name}，疯狂-7！");           
        }
    }
}

