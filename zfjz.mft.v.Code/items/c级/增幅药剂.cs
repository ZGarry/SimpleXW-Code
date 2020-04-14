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
    public class 增幅药剂 : Item
    {
        //绑定的执行器
        public static SomeHanppen Actioner;

        public 增幅药剂() : base(
             name0: "增幅药剂", priceLow0: 8, priceHigh0: 9,
            fuc: "疯狂+2，你下次获取修为的时候，翻倍", icon: "",
            des: "俗称“大力丸”", level: "C")
        {

        }

        public override void EffectIn(Player p)
        {
            //退货
            if (p.StatusStr.Get(name) == "使用中")
            {
                p.SendMes($"上一次{name}的效果还没有使用，本次无法服用{name}");
                p.Package.AddOne(name);
                return;
            }
            //正常使用
            p.StatusStr.Set(name, "使用中");

            p.Crazy += 2;
            p.SendMes($"服用了{name}，疯狂+2，你【下次获取修为翻倍】");
            if (p.OnSomeHanppen == null)
            {
                p.OnSomeHanppen = Effect;
            }
            else
            {
                p.OnSomeHanppen += Effect;
            }
        }

        //效果
        public async void Effect(Player p, object addXWNum)
        {
            //如果事件不匹配，返回
            if (p.NowSubEvent != PlayerSubEvent.XWAdd)
            {
                return;
            }

            //解析
            int i = (int)addXWNum;
            
            p.OnSomeHanppen -= Effect;
            p.StatusStr.Set(name, "药力消散");
            //开启一个新线程去执行这个任务（然后再去增加数据以免出错）
            await Task.Run(() =>
            {
                Thread.Sleep(100);
                p.Set_XW(p.XW + i);
                p.SendMes($"消耗{name}，修为额外增加{i}点");
            });
        }
    }
}
