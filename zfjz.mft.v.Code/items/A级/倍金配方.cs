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
    public class 倍金配方 : Item
    {

        public 倍金配方() : base(
             name0: "倍金配方", priceLow0: 200, priceHigh0: 200,
            fuc: "投入一枚金币进行研究，成功获得100枚金币。失败再次获得此配方", icon: "",
            des: "参悟成功即可点石成金", level: "A")
        {
        }

        public override async void EffectIn(Player p)
        {
            if (p.Gold < 1) {
                p.Package.AddOne(name);
                p.SendMes($"{name}需要投入一枚金币");
                return;
            }
            p.Gold -= 1;
            p.SendMes("你小心翼翼的向坩埚中投入一枚金币，等待结果发生~,请1h后来查看结果");

            // 成功率
            var c = 5 - p.Crazy / 2;
           
            await Task.Run(() =>
            {
                //等待1h
                Thread.Sleep(1000 * 60 * 60);
                if (p.Jude(c))
                {
                    p.Gold += 100;
                    p.SendMes($"参悟成功！你获得了100枚金币！");
                }
                else
                {
                    p.Package.AddOne(name);
                    p.SendMes($"参悟失败！换个思路再试试吧！你再次获得{name}");
                }
            });

            
        }
    }
}
