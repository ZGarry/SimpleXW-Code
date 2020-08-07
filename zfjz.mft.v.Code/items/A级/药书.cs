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
    public class 药书 : Item
    {

        public 药书() : base(
            name0: "药书", priceLow0: 22, priceHigh0: 88,
            fuc: "将你的每枚金币都变成一颗灵芝", icon: "",
            des: "看上去是个医生的呱太", level: "A")
        {
        }

        public override void EffectIn(Player p)
        {
            int num = p.Gold;
            p.Gold = 0;
            p.Package.Add("灵芝", num);
            p.SendMes($"最良好的{name}，教人辨认药品。支付{num}G，获得{num}个灵芝");
        }
    }
}
