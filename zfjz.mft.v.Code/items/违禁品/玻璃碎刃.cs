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
    public class 玻璃碎刃 : Item
    {
        public 玻璃碎刃() : base(
            name0: "玻璃碎刃", priceLow0: 1, priceHigh0: 1,
            fuc: "疯狂+5，下一次攻击必定暴击", icon: "",
            des: "谁还没有小时候踢球踢碎过一面镜子呢", level: "违禁")
        {

        }

        //直接嵌入到主流程-暴击解算
        public override void EffectIn(Player p)
        {
            //退货
            if (p.StatusStr.Get(name) == "使用中")
            {
                p.SendMes($"上一次{name}的效果还没有使用，本次无法使用{name}");
                p.Package.AddOne(name);
                return;
            }
            //正常使用
            p.Crazy += 5;
            p.StatusStr.Set(name, "使用中");

            p.SendMes($"你使用了{name},下次攻击必定暴击。疯狂+5");

        }


      
    }
}
