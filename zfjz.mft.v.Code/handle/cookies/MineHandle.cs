using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void MineHandle(CQGroupMessageEventArgs e)
        {
            e.FromGroup.SendGroupMessage($"你说了’{cookies.ThatWords.word}’，踩到地雷了！'负伤'加入物品栏！");
            //如果他没创建游戏，也没关系
            try
            {
                Game.Players[e.FromQQ.Id].Package.AddOne("负伤");
            }
            catch
            {
                e.FromGroup.SendGroupMessage("你还未开始游戏，物品栏未创建，输入‘签到’来开始");
            }
            cookies.ThatWords.Reset();



        }
    }
}
