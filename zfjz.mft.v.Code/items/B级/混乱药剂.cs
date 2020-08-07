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
    public class 混乱药剂 : Item
    {
        public 混乱药剂() : base(
            name0: "混乱药剂", priceLow0: 12, priceHigh0: 13,
            fuc: "立即使用一瓶随机药水", icon: "",
            des: "他们叫我加入，我就加入了！", level: "B")
        {

        }
        public override void EffectIn(Player p)
        {
            var itm = ItemList.RandomOne(ItemList.ItemsBill);
            p.SendMes($"{name}原来是...贴错了名字的{itm.name},但为时已晚，你已经全喝下去了");
            p.Package.AddOne(itm.name); //加一个用一个
            itm.UseBy(p);
        }      
    }
}
