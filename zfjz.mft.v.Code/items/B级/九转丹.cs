using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.items
{
    public class 九转丹 : Item
    {
        public 九转丹() : base(
            name0: "九转丹", priceLow0: 137, priceHigh0: 317,
            fuc: "体质在60以下的+26，否则+13", icon: "",
            des: "昂贵，但十分有效", level: "B")
        {

        }
        public override void EffectIn(Player p)
        {
            if (p.Basic < 60) {
                p.Basic += 26;
                p.SendMes($"{name}让你脱胎换骨，体质+26");
            }
            else {
                p.Basic += 13;
                p.SendMes($"正在使用{name}，体质+13");
            }

        }      
    }
}
