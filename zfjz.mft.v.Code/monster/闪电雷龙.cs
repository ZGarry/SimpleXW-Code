using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.monster
{
    public class 闪电雷龙 : Monster
    {
        public 闪电雷龙() : base(
            name0: "闪电雷龙", XW0: 7000, basic0: 3000, Crazy0: 1000, Lucky0: 5,
            fuc0: "参战双方战力，均乘以疯狂值", lose0: "闪回石*22，缩小药水，忘忧草",
            icon0: "", level0: "首领")
        {
        }

        //在子类作用域隐藏父类变量
        public override void PlayWin(player.Player p)
        {
            p.StatusStr.Set(name, "击杀");
            //xx，成就的方法记载
            p.StatusStr.Set($"击杀{name}", "成就");
            p.SendMes($"你！战胜了{name}！？获得{lose}");
            p.Package.Add("闪回石", 22);
            p.Package.AddOne("缩小药水");
            p.Package.AddOne("忘忧草");
        }
        public override void Effect(Player p)
        {
            //p.SendMes($"你挑战的是，北境之主，被束缚的雷电之神，闪电掌控者——{name}！");

            //p.SendMes($"本次作战，双方的战力会乘上疯狂值");
            p.c = p.Crazy;
            c = Crazy;
        }
        public override void EffectLose(Player p)
        {
            p.c = 1;
        }
    }
}
