using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using System.Linq;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;
using System;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void InhomeHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
            CQCode cqat = e.FromQQ.CQCode_At();
            var qq = e.FromQQ.Id;
            var codes = e.Message.CQCodes;
            //获取个人信息
            if (!Game.Players.ContainsKey(qq))
            {
                FixStroy.WarnNoCreateUser(e);
                return;
            }
            var p = Game.Players[qq];
            p.SetEIn(e);

            if (p.LevelNum < 6)
            {
                p.SendMes($"境界达到问灵境才可以闭关");
                return;
            }

            //执行闭关
            p.StatusStr.Set("闭关", "true");

            p.StatusInt.Set("入关年", DateTime.Now.Year);

            p.StatusInt.Set("入关月", DateTime.Now.Month);
            p.StatusInt.Set("入关日", DateTime.Now.Day);
            p.SendMes("你已经开始闭关，闭关期间，你无法进行各种活动。如果你是考生，祝你考试顺心如意；如果你要好好工作了~希望你可以实现自己的梦想！");
        }
    }
}
