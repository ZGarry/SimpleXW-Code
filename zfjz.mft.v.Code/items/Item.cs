using Native.Sdk.Cqp.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.items
{
    public abstract class Item
    {
        public string name;
        public int priceLow;
        public int priceHigh;
        public string ICon;
        public string Describle;
        public string Level;
        public string Fuc;

        public Item(string name0, int priceLow0, int priceHigh0, string icon, string des, string level,string fuc)
        {
            name = name0;
            priceLow = priceLow0;
            priceHigh = priceHigh0;
            ICon = icon;
            Describle = des;
            Level = level;
            Fuc = fuc;
        }

        public void UseBy(Player p)
        {
            if (p.Package.LoseOne(name))
            {
                EffectIn(p);
            }
            else
            {
                p.SendMes($"你并无此物品");
            }
        }

        public abstract void EffectIn(Player p);

        public string Report()
        {
            return $@"
{name} {Level}级 {priceLow}-{priceHigh}G
功能: {Fuc}
描述: {Describle}";
        }
    }
}
