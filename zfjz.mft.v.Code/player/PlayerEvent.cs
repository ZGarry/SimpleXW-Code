using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.player
{
    //存储玩家事件
    //事件状态机制，完全被放弃，可能还是这个软件做的不够大，因而不需要。
    //用上委托后，有一个问题，委托如何序列化/
    static public class PlayerEvent
    {
        public const string SignIn = "签到";
        public const string Fight = "挑战";
        public const string BreakThrough = "突破";
        public const string StayInHome = "闭关";

        public const string GiveChoice = "做出选择";
    }
}
