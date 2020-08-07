using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.player;
using zfjz.mft.v.Code.shop;

namespace zfjz.mft.v.Code.items
{
    public class 疾跑药水 : Item
    {
        public 疾跑药水() : base(
            name0: "疾跑药水", priceLow0: 2, priceHigh0: 13,
            fuc: "重置今日签到次数", icon: "",
            des: "多喝些一氧化二氢吧！", level: "B")
        {

        }
        public override void EffectIn(Player p)
        {

            p.StatusInt.LoseOne("上次签到时间");
            p.SendMes($"你使用了{name}，腰不酸腿不疼了，上楼也有劲了！今日可以再签到一次~");



        }
    }
}
