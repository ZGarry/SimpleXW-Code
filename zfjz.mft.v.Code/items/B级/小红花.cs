using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.items
{
    public class 小红花 : Item
    {
        public 小红花() : base(
            name0: "小红花", priceLow0: 1, priceHigh0: 1,
            fuc: "立即做一件好事！", icon: "",
            des: "幼儿园里用来奖励好孩子的道具", level: "B")
        {

        }
        public override void EffectIn(Player p)
        {

            p.SendMes($"你扶着老奶奶过了马路，人品+1！老师奖励一朵{name}");
            p.VirtueJude();
        }
    }
}
