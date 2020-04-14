using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.items;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.monster
{
    public class 深海女皇 : Monster
    {
        public 深海女皇() : base(
            name0: "深海女皇", XW0: 100000, basic0: 400, Crazy0: 40, Lucky0: 100,
            fuc0: "玩家疯狂+100。移除玩家身上所有状态！", lose0: "传家宝，金币*200",
            icon0: "", level0: "首领")
        {
        }
        public override void Effect(Player p)
        {
            p.Crazy += 100;
            p.StatusInt.Dic.Clear();
            p.StatusStr.Dic.Clear();
        }
        public override void PlayWin(Player p)
        {
            p.StatusStr.Set(name, "击杀");
            //xx，成就的方法记载
            p.StatusStr.Set($"击杀{name}", "成就");
            p.SendMes($"你！战胜了{name}！？获得{lose}");

            p.Gold += 200;
            p.Package.AddOne("传家宝");
        }
    }
}
