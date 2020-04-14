using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.common
{
    public class Level
    {
        public int LevelNum;
        public string LevelName;
        public int LowNum;
        public string Slogan;
        //这个数字是乘以100倍后的结果
        public int Rate;
        public int Punish;
        public Level(int LevelNum0, string LevelName0, int LowNum0, string Slogan0, int Rate0, int Punish0)
        {
            LevelNum = LevelNum0;
            LevelName = LevelName0;
            LowNum = LowNum0;
            Slogan = Slogan0;
            Rate = Rate0;
            Punish = Punish0;
        }
    }


}
