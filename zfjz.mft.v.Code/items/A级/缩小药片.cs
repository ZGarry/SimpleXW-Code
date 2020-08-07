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
    public class 缩小药片 : Item
    {
        public 缩小药片() : base(
            name0: "缩小药片", priceLow0: 477, priceHigh0: 477,
            fuc: "修为减半！4h后你将复原！", icon: "",
            des: "头脑虽然变小了，身体却依旧灵活！", level: "A")
        {

        }
        public override async void EffectIn(Player p)
        {
            //退货
            if (p.StatusStr.Get(name) == "使用中")
            {
                p.SendMes($"上一次{name}的效果还在使用中，本次无法使用{name}");
                p.Package.AddOne(name);
                return;
            }
            //正常使用
            p.StatusStr.Set(name, "使用中");

            //执行减半
            p._XW /= 2;
            p.SendMes($"你使用了{name}，你的修为数值减半，1h后，你的修为将翻倍！");

            //加回来，同时移除状态
            await Task.Run(() =>
            {
                Thread.Sleep(1000 * 60 * 60 * 4);
                p.SendMes($"{name}时间过了！你复原啦！");
                p._XW *= 2;
                p.StatusStr.Dic.Remove(name);
            });
        }


    }
}
