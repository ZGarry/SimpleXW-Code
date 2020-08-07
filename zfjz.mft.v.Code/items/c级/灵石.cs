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
    public class 灵石 : Item
    {

        public 灵石() : base(
            name0: "灵石", priceLow0: 1, priceHigh0: 7,
            fuc: "修为+100，欧皇+300", icon: "",
            des: "其中蕴含着灵气，只是不大好消化", level: "C")
        {
        }

        public override void EffectIn(Player p)
        {
            int addNum = p.Jude(30) ? 300 : 100;
            p.XW += addNum;
            p.SendMes($"一番修炼，{name}中的灵气也吸收殆尽。修为+{addNum}");
        }
    }
}
