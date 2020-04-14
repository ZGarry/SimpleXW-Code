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
    public class 回气丹 : Item
    {

        public 回气丹() : base(
            name0: "回气丹", priceLow0: 5, priceHigh0: 12,
            fuc: "体质+5", icon: "",
            des: "修炼者必备，用于快速回复", level: "C")
        {
        }

        public override void EffectIn(Player p)
        {
            p.Basic += 5;
            p.SendMes($"你正在使用{name}！体质+5");
        }
    }
}
