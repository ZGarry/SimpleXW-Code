using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void SayGoodHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
            CQCode cqat = e.FromQQ.CQCode_At();
            var qq = e.FromQQ.Id;

            //获取个人信息
            if (!Game.Players.ContainsKey(qq))
            {
                FixStroy.WarnNoCreateUser(e);
                return;
            }
            var p = Game.Players[qq];
            p.SetEIn(e);

            //展示信息
            p.XW += 1;
            foreach (var c in Common.Word)
            {

                if (e.Message.Text.Contains(c))
                {
                    e.FromGroup.SendGroupMessage(cqat, " ", "夸群主的都是好人！修为+1");
                    return;
                }
            }
        }
    }
}
