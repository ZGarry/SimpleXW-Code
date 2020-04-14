using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.items;
using zfjz.mft.v.Code.player;
using zfjz.mft.v.Code.common;

namespace zfjz.mft.v.Code.shop
{
    static class Shop
    {
        //购物中心永远有三件商品
        public static StringIntDic Items=new StringIntDic("{}");

        static public void ItemBuy(Player p, string name)
        {
            //如果没有
            if (!Items.Contain(name))
            {
                p.SendMes($"此商品在进货中");
                return;
            }
            //如果买不起
            if (p.Gold < Items.Get(name))
            {
                p.SendMes($"你买不起此商品，老板友善的把你赶了出来");
                return;
            }

            p.Gold -= Items.Get(name);
            p.Package.AddOne(name);
            p.SendMes($"支付了{Items.Get(name)}枚金币，购入{name},老板大气~");
            //移除此商品
            Items.Dic.Remove(name);
        }

        //降价一半
        static public void PriceLow()
        {
            Items.Dic = Items.Dic.ToDictionary(
                x => x.Key,
                x => x.Value/2);
        }
        

        //一次展示且只展示三个商品，并且为他们标定价格
        static public string Show()
        {
            if (Game.IntRecord.Get("上次访问商店时间") != DateTime.Now.DayOfYear)
            {
                Game.IntRecord.Set("上次访问商店时间", DateTime.Now.DayOfYear);
                PriceLow();
            }
            while (Items.Dic.Count < 3)
            {
                var item = ItemList.ChooseOne();
                //已经包括的，不加入
                if (Items.Contain(item.name))
                {
                    continue;
                }
                Items.Set(item.name, (new Random()).Next(item.priceLow, item.priceHigh + 1));
            }

            string temple = "能买道具的时候要尽量购买！";
            int times = 1;
            foreach (var c in Items.Dic)
            {
                temple += $"\n{times}/ {c.Key}, 价格：{c.Value}";
                times++;
            }
            return temple;
        }
    }
}
