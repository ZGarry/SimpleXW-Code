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
    public class 忘忧草 : Item
    {

        public 忘忧草() : base(
            name0: "忘忧草", priceLow0: 123, priceHigh0: 123,
            fuc: "重置体质为50，疯狂为5", icon: "",
            des: "从头再来", level: "违禁")
        {
        }

        public override void EffectIn(Player p)
        {
            p.Basic = 50;
            p.Crazy = 5;
            p.SendMes($"你正在使用{name}！各项数值重置。");
        }
    }
}
