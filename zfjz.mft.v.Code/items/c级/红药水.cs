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
    public class 红药水 : Item
    {

        public 红药水() : base(
            name0: "红药水", priceLow0: 9, priceHigh0: 11,
            fuc: "疯狂+3，体质+9", icon: "",
            des: "疯狂，躁动，反应", level: "C")
        {
        }

        public override void EffectIn(Player p)
        {
            p.Crazy += 3;
            p.Basic += 9;
            p.SendMes($"你正在使用{name}，疯狂+3，体质+9");
        }
    }
}
