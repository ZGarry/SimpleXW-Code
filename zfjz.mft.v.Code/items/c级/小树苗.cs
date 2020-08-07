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
    public class 小树苗 : Item
    {
        public 小树苗() : base(
            name0: "小树苗", priceLow0: 2, priceHigh0: 9,
            fuc: "种下五天后，小树苗就会成熟", icon: "",
            des: "众所周知这是个收菜游戏", level: "C")
        {

        }
        public override void EffectIn(Player p)
        {
            //退货
            if (p.StatusInt.Contain(name))
            {
                p.SendMes($"同一段时间内，不要栽种多颗{name}哦");
                p.Package.AddOne(name);
                return;
            }
            //正常使用
            p.StatusInt.Set("树苗大小", 0);
            p.SendMes($"你种下了一颗小树苗~别忘了每天签到来栽培它哦~");
        }
    }
}
