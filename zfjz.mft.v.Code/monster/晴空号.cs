using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.monster
{
    public class 晴空号 : Monster
    {
        public 晴空号() : base(
            name0: "晴空号", XW0: 100, basic0: 40000, Crazy0: 0, Lucky0: 0,
            fuc0: "双方以体质与修为之比参战", lose0: "神偷手套*3",
            icon0: "", level0: "首领")
        {
        }

        //在子类作用域隐藏父类变量
        public override void PlayWin(player.Player p)
        {
            p.StatusStr.Set(name, "击杀");
            //xx，成就的方法记载
            p.StatusStr.Set($"焚毁晴空号！", "成就");
            p.SendMes($"你！战胜了{name}！？获得{lose}");

            p.Package.Add("神偷手套", 3);
        }
        public override void Effect(Player p)
        {
            if (p.XW / p.Basic > 400)
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
        public override void EffectLose(Player p)
        {
            c = 1;
            p.c = 1;
        }
    }
}
