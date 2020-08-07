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
    public class 小钱袋 : Item
    {

        public 小钱袋() : base(
            name0: "小钱袋", priceLow0: 1, priceHigh0: 6,
            fuc: "投一颗骰子（1-6），获得等量金币与疯狂", icon: "",
            des: "嘿，这是我的自来水厂", level: "C")
        {
        }

        public override void EffectIn(Player p)
        {
            var num = (new Random()).Next(1, 7);
            p.Gold += num;
            p.Crazy += num;
            p.SendMes($"打开{name}！你可以投一次🎲~。来决定你能获取的金币数量");
            p.SendMes($"你投出了{num},获得{num}枚金币，疯狂+{num}");
            if (num == 1 || num == 6)
            {
                p.Package.AddOne("小钱袋");
                p.SendMes("你再次获得了小钱袋");
            }

        }
    }
}
