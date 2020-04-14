using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.monster
{
    public class 小雷龙 : Monster
    {
        public 小雷龙() : base(
            name0: "小雷龙", XW0: 1000, basic0: 100, Crazy0: 10, Lucky0: 5,
            fuc0: "无", lose0: "闪回石",
            icon0: "", level0: "小兵")
        {
        }

        //在子类作用域隐藏父类变量
        public override void PlayWin(player.Player p)
        {
            p.SendMes($"你击杀了{name},获得一枚闪回石");
            p.Package.AddOne("闪回石");
        }
    }
}
