using Native.Sdk.Cqp;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void GameHandle(CQGroupMessageEventArgs e)
        {
            if (cookies.ThatWords.Running)
            {
                e.FromGroup.SendGroupMessage("上一个游戏还在进行，设置地雷的人为", CQApi.CQCode_At(cookies.ThatWords.qq));
            }
            else
            {
                e.FromGroup.SendGroupMessage(@"游戏：蜘蛛地雷
1. 发起者私聊面粉团，设置一个词语，作为地雷
2. 后续说出这个词语的玩家，将踩雷");
                //设置当前玩家
                cookies.ThatWords.qq = e.FromQQ.Id;
                e.FromQQ.SendPrivateMessage("嘿~小家伙，请说出你要设置的词语（2-4个字）");
            }


        }
    }
}
