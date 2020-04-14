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
    public class 小金箔 : Item
    {

        public 小金箔() : base(
             name0: "小金箔", priceLow0: 1, priceHigh0: 1,
            fuc: "熔断后，刚好价值一个金币", icon: "",
            des: "为了荣誉而赠。", level: "特殊")
        {
        }

        public override void EffectIn(Player p)
        {
            p.Gold += 1;
            p.SendMes($"你正在使用{name}！感谢你为开发做出的贡献。金币+1");
        }
    }
}
