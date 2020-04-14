using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;
using System;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void RobustHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
            var qq = e.FromQQ.Id;
            var codes = e.Message.CQCodes;

            //无此人，直接返回           
            if (!Game.Players.ContainsKey(qq))
            {
                return;
            }
            var p = Game.Players[qq];
            p.SetEIn(e);

            //无此道具，提示返回
            if (!p.Package.Contain("神偷手套")) {
                p.SendMes("你没有神偷手套，无法偷取");
                return;
            }
          
            //异常处理
            if (codes.Count != 1)
            {
                p.SendMes("请选择唯一一个角色");
                return;
            }
           
            //获取被偷玩家
            long qq2 = long.Parse(codes[0].Items["qq"]);
            //如果这名玩家是自己
            if (p.QQ == qq2)
            {
                p.SendMes("请不要偷取自己");
                return;
            }
            if (!Game.Players.ContainsKey(qq2))
            {
                FixStroy.WarnNoUser(e);
                return;
            }
            var p2 = Game.Players[qq2];

            int num=p2.StatusInt.Get("修为增加数值");
            p.XW += num;
            p2.XW -= num;
            p.SendMes($"你成功从对方处偷取了修为{num}点");
            p.Package.LoseOne("神偷手套");
        }
    }
}
