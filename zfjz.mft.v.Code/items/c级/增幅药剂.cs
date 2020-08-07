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
             name0: "增幅药剂", priceLow0: 2, priceHigh0: 8,
            fuc: "疯狂+2，你下次获取修为的时候，翻倍", icon: "",
            des: "俗称“大力丸”", level: "C")
        {

        }

        public override void EffectIn(Player p)
        {
            //退货
            if (p.StatusStr.Get(name) == "on")
            {
                p.SendMes($"上一次{name}的效果还没有使用，本次无法服用{name}");
                p.Package.AddOne(name);
                return;
            }
            //正常使用
            p.StatusStr.Set(name, "on");
            p.StatusStr.Set($"{name}begin", DateTime.Today.ToString());

            p.SendMes($"服用了{name}，疯狂+2，你【下次获取修为翻倍】");

        }

    }
}
