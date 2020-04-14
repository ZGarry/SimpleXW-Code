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
    public class 放大药水 : Item
    {
        public 放大药水() : base(
            name0: "放大药水", priceLow0: 133, priceHigh0: 146,
            fuc: "进入放大状态！1h后你将复原！", icon: "",
            des: "配合巨化术可以8000斩", level: "C")
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
            p.Basic *= 2;
            p.Crazy *= 2;
            p._XW *= 2;
            p.SendMes($"你使用了{name}，你的各项数值翻倍，1h后，你的各项数值将减半！");

            //加回来，同时移除状态
            await Task.Run(() =>
            {
                Thread.Sleep(1000*60*60);
                p.SendMes($"{name}时间过了！你复原啦！");
                p.Basic /= 2;
                p.Crazy /= 2;
                p._XW /= 2;
                p.StatusStr.Dic.Remove(name);
            });
        }

       
    }
}
