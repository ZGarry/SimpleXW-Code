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
    public class 灵火 : Item
    {
        public 灵火() : base(
            name0: "灵火", priceLow0: 37, priceHigh0: 37,
            fuc: "体质-2，今天内每次失去修为，体质都+1", icon: "",
            des: "伤痛，是最好的特效药", level: "违禁")
        {

        }
        public override void EffectIn(Player p)
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
            p.StatusInt.Set("灵火使用时间", DateTime.Now.DayOfYear);

            p.SendMes($"{name}四溅！有志者成！你被灼伤，体质-2。今天的每次疼痛都将让你更加强大！");
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
        public async void Effect(Player p, object loseXWNum)
        {
            //如果事件不匹配，返回
            if (p.NowSubEvent != PlayerSubEvent.XWLose)
            {
                return;
            }
            if (p.StatusInt.Get("灵火使用时间") == DateTime.Now.DayOfYear)
            {
                p.Basic += 1;
                await Task.Run(() =>
                {
                    Thread.Sleep(100);
                    p.SendMes($"{name}的烤炙让你更加强大！体质+1");
                });
            }
            else
            {
                p.OnSomeHanppen -= Effect;
                p.StatusStr.Set(name, "药力消散");
            }
        }
    }
}
