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
            name0: "伤药", priceLow0: 2, priceHigh0: 8,
            fuc: "使用后抵消一次修为减少", icon: "",
            des: "务必理性用药", level: "C")
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
            p.StatusStr.Set("伤药begin", DateTime.Today.ToString());

            p.SendMes($"服用了{name}，你现在能【快速治疗】");
        }
        //可以设置一个trigger？好像也不大型



    }
}
