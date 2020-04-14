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
    public class 传家宝 : Item
    {

        public 传家宝() : base(
            name0: "传家宝", priceLow0: 999, priceHigh0:999,
            fuc: "立即获得当前商店中所有商品！", icon: "",
            des: "每个家庭都有一个传家宝，当然其中有一些可能是地摊货", level: "S")
        {
        }

        public override void EffectIn(Player p)
        {
            p.SendMes("你拿着你的传家宝来到商店~");
            shop.Shop.Show();

            var li = shop.Shop.Items.Dic.Keys.ToList();
            p.Package.AddOne(li[0]);
            p.Package.AddOne(li[1]);
            p.Package.AddOne(li[2]);
            shop.Shop.Items.Dic.Clear();

            p.SendMes($"用传家宝作为置换，你同时买下了{li[0]},{li[1]},{li[2]},老板看着你离去的背影，感慨道:'家里有矿，就是好呀'。");            
        }
    }
}
