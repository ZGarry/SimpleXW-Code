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
    public class 润肺露 : Item
    {

        public 润肺露() : base(
            name0: "润肺露", priceLow0: 12, priceHigh0: 15,
            fuc: "增加一定体质（随月份），疯狂-1，修为+5", icon: "",
            des: "春斗酒，夏读书，秋结社，冬染病", level: "C")
        {
        }

        public override void EffectIn(Player p)
        {
            p.Basic += DateTime.Now.Month;
            p.Crazy -= 1;
            p.XW += 5;
            p.SendMes($"感冒的人确实需要{name},也需要陪伴,体质+{DateTime.Now.Month},疯狂-1，修为+5");
        }
    }
}
