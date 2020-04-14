using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.items;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.monster
{
    public class 小海妖 : Monster
    {
        public 小海妖() : base(
            name0: "小海妖", XW0: 1000, basic0: 200, Crazy0: 40, Lucky0: 80,
            fuc0: "玩家疯狂+10(永久)", lose0: "随机B级道具",
            icon0: "", level0: "队长")
        {
        }
        public override void Effect(Player p)
        {
            p.Crazy += 10;
        }
    }
}
