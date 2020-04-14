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
    public class 伤药 : Item
    {
        public 伤药() : base(
            name0: "伤药", priceLow0: 4, priceHigh0: 8,
            fuc: "使用后抵消一次修为减少", icon: "",
            des: "务必理性用药", level: "C")
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

            p.SendMes($"服用了{name}，你现在能【快速治疗】");
            if (p.OnSomeHanppen == null)
            {
                p.OnSomeHanppen = Effect;
            }
            else
            {
                p.OnSomeHanppen += Effect;
            }
        }

        //效果-利用系数C来配合完成工作
        public async void Effect(Player p, object loseXWNum)
        {
            //如果事件不匹配，返回
            if (p.NowSubEvent != PlayerSubEvent.XWLose)
            {
                return;
            }

            //解析
            int i = (int)loseXWNum;
           
            p.OnSomeHanppen -= Effect;
            p.StatusStr.Set(name, "药力消散");
            //开启一个新线程去执行这个任务（避免同时对数据进行操作）
            await Task.Run(() =>
            {
                Thread.Sleep(100);
                p.Set_XW(p.XW + i);
                p.SendMes($"消耗{name}，修为回复{i}点");
            });           
        }

       
    }
}
