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
    public class 小猪钱罐 : Item
    {
        public 小猪钱罐() : base(
            name0: "小猪钱罐", priceLow0: 200, priceHigh0: 200,
            fuc: "现在你每次签到，都有50%机会获得2枚金币。使用金币后失效", icon: "",
            des: "谁还不是一个有梦想的人呢", level: "A")
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
            p.StatusStr.Set(name, "使用中");

        }


      
    }
}
