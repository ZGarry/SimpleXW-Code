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
    public class 灵芝 : Item
    {

        public 灵芝() : base(
            name0: "灵芝", priceLow0: 15, priceHigh0: 24,
            fuc: "体质-13，疯狂-13。失去700修为，获得700点修为。", icon: "",
            des: "活血清毒，激发潜能", level: "C")
        {
        }

        public override void EffectIn(Player p)
        {
            p.Basic -= 13;          
            p.XW -= 700;           
            p.SendMes($"你正在使用{name}！体质-13,失去700点修为");
            p.Crazy -= 13; 
            p.XW += 700;
            p.SendMes($"经过料理的你感觉分外舒心，修为+700，疯狂-13");
        }
    }
}
