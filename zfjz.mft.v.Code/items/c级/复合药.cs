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
    public class 复合药 : Item
    {
        public 复合药() : base(
            name0: "复合药", priceLow0: 1, priceHigh0: 1,
            fuc: "体质+2，疯狂-2，修为+10", icon: "",
            des: "家中常备", level: "C")
        {
        }

        public override void EffectIn(Player p)
        {
            p.Crazy -= 2;
            p.Basic += 2;
            p.XW += 10;
            p.SendMes($"{name}让你心旷神怡！体质+2，疯狂-2，修为+10");
        }
    }
}
