using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.monster
{
    public class 采集客 : Monster
    {
        public 采集客() : base(
            name0: "采集客", XW0: 1000, basic0: 100, Crazy0: 40, Lucky0: 60,
            fuc0: "对你使用一次‘神偷手套’", lose0: "随机B级道具",
            icon0: "", level0: "队长")
        {
        }
        public override void Effect(Player p)
        {
            int n = p.StatusInt.Get("修为增加数值");
            XW += n;
            p.XW -= n;
        }

    }
}
