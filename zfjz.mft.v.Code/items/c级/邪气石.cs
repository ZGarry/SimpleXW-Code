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
    public class 邪气石 : Item
    {

        public 邪气石() : base(
             name0: "邪气石", priceLow0: 1, priceHigh0: 2,
            fuc: "疯狂+3，每有5点疯狂，金币+1（不超过10）", icon: "",
            des: "黑暗府邸的产物", level: "C")
        {
        }

        public override void EffectIn(Player p)
        {
            p.Crazy += 3;
            int gold_add = p.Crazy / 5;
            if (gold_add >= 10)
            {
                gold_add = 10;
            }
            p.Gold += gold_add;
            p.SendMes($"你正在使用{name},疯狂+3,金币+{gold_add}");
        }
    }
}
