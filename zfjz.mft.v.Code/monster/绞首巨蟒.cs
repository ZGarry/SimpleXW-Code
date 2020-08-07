using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.items;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.monster
{
    public class 绞首巨蟒 : Monster
    {
        public 绞首巨蟒() : base(
            name0: "绞首巨蟒", XW0: 370, basic0: 100, Crazy0: 10, Lucky0: 0,
            fuc0: "此怪物战力会乘上挑衅者物品数", lose0: "随机B/C级道具",
            icon0: "", level0: "小兵")
        {
        }
        public override void Effect(Player p)
        {
            //翻倍系数
            c = p.Package.Dic.Values.Sum();
        }

        public override void PlayWin(player.Player p)
        {
            var itm = p.Jude(50) ? ItemList.RandomC() : ItemList.RandomB();
            p.SendMes($"为名除害消灭{name},获得{itm}");
            p.Package.AddOne(itm);
        }


    }
}
