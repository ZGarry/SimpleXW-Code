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
    public class 序列I : Item
    {

        public 序列I() : base(
            name0: "序列I", priceLow0: 2, priceHigh0: 2,
            fuc: "中概率金币+4，小概率幸运+1，极小概率金币+100", icon: "",
            des: "梦幻", level: "C")
        {
        }


        public override void EffectIn(Player p)
        {
            var temp = $"";
            if (p.Jude(50))
            {
                temp += "金币+4";
                p.Gold += 4;
            }
            if (p.StrictJude(10))
            {
                temp += "幸运+1";
                p.Lucky += 1;
            }
            if (p.StrictJude(1))
            {
                if (p.Jude(20)) {
                    temp += "金币+100";
                    p.Gold += 100;
                }
                
            }
            if (temp == "")
            {
                temp = "但你一无所获";
            }
            p.SendMes($"{name}是梦幻的感觉,{temp}");
        }
    }
}
