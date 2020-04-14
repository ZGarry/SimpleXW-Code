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
    public class 圣水 : Item
    {

        public 圣水() : base(
            name0: "圣水", priceLow0: 123, priceHigh0: 123,
            fuc: "如果疯狂刚好等于1，幸运+1，修为+800，否则疯狂-11", icon: "",
            des: "服用即庇护", level: "A")
        {
        }

        public override void EffectIn(Player p)
        {
            if (p.Crazy == 1)
            {
                p.Lucky += 1;
                p.XW += 800;
                p.SendMes($"{name}让你升华！幸运+1，修为+800");
            }
            else {
                p.Crazy -= 11;
                p.SendMes($"{name}让你净化！疯狂-11");
            }

           
        }
    }
}
