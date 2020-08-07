using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.items;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.monster
{
    public class 蝙蝠群 : Monster
    {
        public 蝙蝠群() : base(
            name0: "蝙蝠群", XW0: 400, basic0: 70, Crazy0: 100, Lucky0: 0,
            fuc0: "你可能面对一群蝙蝠！", lose0: "0.1G/每只蝙蝠",
            icon0: "", level0: "队长")
        {
        }
        public override void Effect(Player p)
        {
            //最多一千只蝙蝠
            c = Common.Random.Next(1000) + 1;
        }

        public override void PlayWin(player.Player p)
        {
            p.SendMes($"你击杀了{c}只蝙蝠，获得{(int)c / 10}枚金币");

            p.Gold += (int)c / 10;
        }

        public override void EffectLose(Player p)
        {
            //复原
            p.c = 1;
        }
    }
}
