using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.cookies
{
    static public class ThatWords
    {
        // 记录游戏是否开始
        static public bool Running = false;
        // 词语
        static public string word = "";
        // who
        static public long qq = 0;

        //
        static public void Reset()
        {
            Running = false;
            word = "";
            qq = 0;
        }
    }
}
