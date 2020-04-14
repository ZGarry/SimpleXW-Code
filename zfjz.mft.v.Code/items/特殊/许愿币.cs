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
    public class 许愿币 : Item
    {

        public 许愿币() : base(
            name0: "许愿币", priceLow0: 1, priceHigh0: 1,
            fuc: "使用后，进行一次许愿", icon: "",
            des: "众知杯秘", level: "特殊")
        {
        }

        public override async void EffectIn(Player p)
        {
            p.SendMes(@$"朋友~你又来了~想要什么? 
------请在10s内做出选择------
输入'#1'-很多很多的钱
输入'#2'-更加强大
输入'#3'-还要三个愿望！");

            if (p.OnSomeHanppen == null)
            {
                p.OnSomeHanppen = Effect;
            }
            else
            {
                p.OnSomeHanppen += Effect;
            }
            await Task.Run(() =>
            {
                Thread.Sleep(10000);
                p.OnSomeHanppen -= Effect;
            });
        }



        public async void Effect(Player p, object Choose)
        {
            //如果事件不匹配，返回
            if (p.NowEvent != PlayerEvent.GiveChoice)
            {
                return;
            }

            //解析
            int i = (int)Choose;
            p.OnSomeHanppen -= Effect;
            //开启一个新线程去执行这个任务

            //10s后做出答复
            switch (Choose)
            {
                case (1):
                    p.SendMes("实现了，现在请拿走你的一枚小金箔~");
                    p.Package.AddOne("小金箔");
                    break;
                case (2):
                    p.SendMes("哦，当一个修炼者可真不容易，就让我送你一点修为吧~");
                    p.XW += 1;
                    break;
                case (3):
                    p.SendMes("从前我也向你这样贪心，后来，我因这份贪心在瓶子里关三百年。。。");
                    p.XW += 1;
                    break;
                //未进行选择
                default:
                    p.SendMes("很遗憾~，你没有做出任何选择~许愿之神化作风儿飘散");
                    break;
            }
        }
    }
}

