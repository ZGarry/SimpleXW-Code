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
    public class 序列III : Item
    {
        public 序列III() : base(
            name0: "序列III", priceLow0: 1, priceHigh0: 24,
            fuc: "修为+333", icon: "",
            des: "质朴", level: "B")
        {

        }
        public override void EffectIn(Player p)
        {
            p.XW += 333;
            p.SendMes($"修为+333。实事求是是{name}第一要义。");
        }
    }
}
