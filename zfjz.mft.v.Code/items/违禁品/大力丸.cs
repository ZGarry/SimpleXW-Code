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
    public class 大力丸 : Item
    {
        public 大力丸() : base(
            name0: "大力丸", priceLow0: 17, priceHigh0: 27,
            fuc: "下一次战斗战力*1.3（可以服用多颗）", icon: "",
            des: "连吃13颗可以毁天灭地！", level: "违禁")
        {

        }
        public override void EffectIn(Player p)
        {
            //多吃了一颗
            p.StatusInt.AddOne(name);
            p.SendMes($"你现在服用了{p.StatusInt.Get(name)}颗{name}，下一次战斗战力乘以{Math.Pow(1.3, p.StatusInt.Get(name))}倍");

            if (p.OnSomeHanppen == null)
            {
                p.OnSomeHanppen = Effect;
            }
            else
            {
                p.OnSomeHanppen += Effect;
            }
            p.OnSomeHanppen += EffectLose;
        }

        //效果
        public void Effect(Player p, object not_)
        {
            //如果事件不匹配，返回
            if (p.NowEvent != PlayerEvent.Fight && p.NowSubEvent == PlayerSubEvent.GetATK)
            {
                return;
            }
            p.c *= Math.Pow(1.3, p.StatusInt.Get(name));
            p.OnSomeHanppen -= Effect;
            p.SendMes($"{name}让你如有神助，本次战力乘以{Math.Pow(1.3, p.StatusInt.Get(name))}");
        }

        //效果消失
        public void EffectLose(Player p, object not_)
        {
            //如果事件不匹配，返回
            if (p.NowEvent != PlayerEvent.Fight && p.NowSubEvent == PlayerSubEvent.GetATKEnd)
            {
                return;
            }

            //改回c同时删除物品，并取绑自身
            p.c /= Math.Pow(1.3, p.StatusInt.Get(name));
            p.OnSomeHanppen -= EffectLose;
            p.StatusInt.Dic.Remove(name);

        }
    }
}
