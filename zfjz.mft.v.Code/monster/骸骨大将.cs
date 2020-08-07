using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.monster
{
    public class 骸骨大将 : Monster
    {
        public 骸骨大将() : base(
            name0: "骸骨大将", XW0: -7000, basic0: 1000, Crazy0: 100, Lucky0: 0,
            fuc0: "计算战力时，双方修为均乘以-1", lose0: "焚血",
            icon0: "", level0: "首领")
        {
        }

        //在子类作用域隐藏父类变量
        public override void PlayWin(player.Player p)
        {
            p.StatusStr.Set(name, "击杀");
            //xx，成就的方法记载
            p.StatusStr.Set($"令其死亡！", "成就");
            p.SendMes($"你！战胜了{name}！？获得{lose}");

            p.Package.AddOne("焚血");
        }
        public override void Effect(Player p)
        {
            //p.SendMes($"你挑战的是，北境之主，被束缚的雷电之神，闪电掌控者——{name}！");

            //p.SendMes($"本次作战，双方的战力会乘上疯狂值");
            p.c = -1;
            c = -1;
        }
        public override void EffectLose(Player p)
        {
            //复原
            p.c = 1;
        }
    }
}
