using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.items
{
    public class 神偷手套 : Item
    {

        public 神偷手套() : base(
            name0: "神偷手套", priceLow0: 8, priceHigh0: 68,
            fuc: " '偷取@一名角色' \n-- 立即偷取对方上次获得的修为", icon: "",
            des: "金霞山论极谁主英雄", level: "A")
        {
        }

        public override void EffectIn(Player p)
        {
            //正常使用一定退货，通过关键词使用
            p.Package.AddOne(name);
            p.SendMes($"{name}为你开放了一个新指令'偷取',使用'查看#{name}'了解");



        }
    }
}
