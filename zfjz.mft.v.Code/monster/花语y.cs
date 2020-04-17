using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.monster
{
    public class 花语y : Monster
    {
        public 花语y() : base(
            name0: "花语y", XW0: 88888, basic0: 200, Crazy0: 40, Lucky0: 10,
            fuc0: "使用百宝箱！以及...随时跑路！", lose0: "花语y的百宝箱",
            icon0: "", level0: "首领")
        {
        }
        public override void Effect(Player p)
        {
            //看起来要写百宝箱功能，但懒得写了
            c *= 1.5;
        }
        public override void PlayWin(Player p)
        {
            if (DateTime.Now.Month == 12 || (DateTime.Now.Month == 11 && DateTime.Now.Day >= 23))
            {
                p.StatusStr.Set(name, "击杀");
                p.SendMes($"你击杀了！{name},去看看你背包里多了什么吧！");
                //10个c
                p.Package.Add(items.ItemList.RandomC(), 10);
                //5个b
                p.Package.Add(items.ItemList.RandomB(), 5);
                //2个a
                p.Package.Add(items.ItemList.RandomA(), 2);
                //一个s
                p.Package.Add(items.ItemList.RandomS(), 2);
            }
            else
            {
                p.SendMes($"你三下五除二就把{name}打到了，但TA一溜烟跑掉了");
            }


        }

    }
}
