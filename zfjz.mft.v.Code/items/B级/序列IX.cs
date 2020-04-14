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
    public class 序列IX : Item
    {
        public 序列IX() : base(
            name0: "序列IX", priceLow0: 1, priceHigh0: 14,
            fuc: "体质-9，幸运+1", icon: "",
            des: "薄幸", level: "B")
        {

        }
        public override void EffectIn(Player p)
        {
            p.Basic -= 9;
            p.Lucky += 1;
            p.SendMes($"{name}包装华丽，效果纯粹，严重影响身体，体质-9，幸运+1");
        }
    }
}
