using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;
using System;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void FightHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
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

            //异常处理
            if (codes.Count == 0)
            {
                FixStroy.WarnUnserFightWind(e);
                return;
            }
            if (codes.Count > 1)
            {
                p.SendMes("等到你变得更强的时候，再来挑战多人吧！");
                return;
            }
            if (p.StatusInt.Get("上次挑战时间") == DateTime.Now.DayOfYear)
            {
                p.SendMes("你今天已经挑战过啦~");
                return;
            }

            //获取被挑战玩家
            long qq2 = long.Parse(codes[0].Items["qq"]);
            //如果这名玩家是自己
            if (p.QQ == qq2)
            {
                p.SendMes("请不要挑战自己~");
                return;
            }
            if (!Game.Players.ContainsKey(qq2))
            {
                FixStroy.WarnNoUser(e);
                return;
            }
            var p2 = Game.Players[qq2];
            //r如果选了一个闭关的人呢
            if (p2.StatusStr.Contain("闭关"))
            {
                p.SendMes("请不要挑战闭关中的修炼者");
                return;
            }

            //
            p.Fight(p2);

            //
            p.StatusInt.Set("上次挑战时间", DateTime.Now.DayOfYear);
        }
    }
}
