using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.items;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.monster
{
    public class 地下迷宫 : Monster
    {
        public 地下迷宫() : base(
            name0: "地下迷宫", XW0: 1, basic0: 1, Crazy0: 1, Lucky0: 1,
            fuc0: "玩家必败！除非这是你第7*k（k∈N）次挑衅！", lose0: "随机S级道具",
            icon0: "", level0: "队长")
        {
        }
        public override void Effect(Player p)
        {
            p.StatusInt.AddOne("地下迷宫次数");
            p.SendMes($"这是你{p.StatusInt.Get("地下迷宫次数")}次走地下迷宫");
            if (p.StatusInt.Get("地下迷宫次数") % 7 == 0)
            {

                //玩家必胜
                c = 0;
                p.c = 1;
            }
            else
            {
                //玩家必败
                c = 1;
                p.c = 0;
            }
        }

        public override void PlayWin(player.Player p)
        {
            var itm = ItemList.RandomS();
            p.SendMes($"走出地下迷宫，揭破地下组织的阴谋，获得官方奖励的{itm}一个");
            p.Package.AddOne(itm);
        }

        public override void EffectLose(Player p)
        {
            c = 1;
            p.c = 1;
        }


    }
}
