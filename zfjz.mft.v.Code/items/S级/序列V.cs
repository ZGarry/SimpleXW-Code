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
    public class 序列V : Item
    {
        public int x = -1;
        public 序列V() : base(
            name0: "序列V", priceLow0: 999, priceHigh0: 999,
            fuc: "贪婪之神将为你服务！", icon: "",
            des: "想在舞会上击倒恶魔，需要一点点技巧", level: "S")
        {
        }

        public override void EffectIn(Player p)
        {
            p.SendMes($"药水的烟雾散去，这烟雾中，缓缓飘出一只。。。恶魔");
            DemonQuestionAsync(p);
        }

        //魔鬼的问答
        public async Task DemonQuestionAsync(Player p)
        {
            x += 1;
            p.SendMes($@"朋友~你又来了~这次，你想要什么？
------请在30s内做出选择------
输入'#1' - 随机道具
输入'#2' - 很多很多的钱
输入'#3' - 更加强大
输入'#4' - 辱骂恶魔
这次我将抽取你{x}点体质作为代价~");

            if (p.OnSomeHanppen == null)
            {
                p.OnSomeHanppen = Effect;
            }
            else
            {
                p.OnSomeHanppen += Effect;
            }

            //取消这个魔鬼问答
            await Task.Run(() =>
            {
                Thread.Sleep(1000*30);
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
            //这个魔鬼问答完毕
            p.OnSomeHanppen -= Effect;
            //开启一个新线程去执行这个任务

            //10s后做出答复
            switch (Choose)
            {
                case (1):
                    var ite="";
                    if (p.Jude(50))
                    {
                       ite = ItemList.RandomOne(ItemList.ItemsB).name;
                    }
                    else
                    {
                        ite = ItemList.RandomOne(ItemList.ItemsC).name;
                    }
                    p.Package.AddOne(ite);

                    p.SendMes($"实现了，{ite}已加入背包");
                    DemonQuestionAsync(p);
                    break;
                case (2):
                    p.SendMes("实现了，金币+4");
                    p.Gold += 4;
                    DemonQuestionAsync(p);
                    break;
                case (3):
                    p.SendMes("实现了，序列3已加入背包");
                    p.Package.AddOne("序列III");
                    DemonQuestionAsync(p);
                    break;

                case (4):
                    p.SendMes($"魔鬼卷成一团，在咒骂声中烟消云散");
                    x = -1;
                    break;
                //未进行选择
                default:
                    p.SendMes($"魔鬼卷成一团，在咒骂声中烟消云散");
                    x = -1;
                    break;
            }
        }


    }
}
