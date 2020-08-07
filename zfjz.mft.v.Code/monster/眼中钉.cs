using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.items;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.monster
{
    public class 眼中钉 : Monster
    {
        public 眼中钉() : base(
            name0: "眼中钉", XW0: 8, basic0: 0, Crazy0: 0, Lucky0: 0,
            fuc0: "战斗仅比较修为尾数", lose0: "随机A级道具",
            icon0: "", level0: "小兵")
        {
        }
        public override void Effect(Player p)
        {

            if (p.XW % 10 >= 8)
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
            var itm = ItemList.RandomA();
            p.SendMes($"你悄无声息的走出了监视区域，成功收集到了暗黑组织犯罪的证据，获得官方奖励的{itm}一个");
            p.Package.AddOne(itm);
        }

        public override void EffectLose(Player p)
        {
            c = 1;
            p.c = 1;
        }


    }
}
