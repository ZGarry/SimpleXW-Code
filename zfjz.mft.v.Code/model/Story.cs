using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.player
{
    static public class Story
    {
        private static RangeMes[] TrainMes = new RangeMes[] {
           new RangeMes(-99999,0,new string[]{ "修炼时被他人打断", "修炼时差点走火入魔，幸好被及时发现","修炼不得要领","修炼遇到瓶颈"}),
            new RangeMes(1,60,new string[]{ "小有所得", "巩固基础","步步为营","滴水穿石"}),
             new RangeMes(60,125,new string[]{ "醍醐灌顶", "收获颇丰","获名师指点","仔细研读先人书籍，并大有所获"}),
              new RangeMes(126,250,new string[]{ "开宗立派", "游历了一番藏书阁"}),
              new RangeMes(251,500,new string[]{ "坠崖不死，发现秘诀", "友人相赠，传奇剑法一篇"}),
              new RangeMes(501,99999,new string[]{ "强者的世界，修炼只在吐息之间"})
        };
        public static string GetTrainStory(int i)
        {
            foreach (var c in TrainMes)
            {
                if (c.Contain(i))
                {

                    return c.SendRan();
                }
            }
            return "";
        }
    }
}
