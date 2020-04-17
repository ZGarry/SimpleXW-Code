using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;
using System;
using zfjz.mft.v.Code.monster;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        //援助-吸收疯狂
        public static void HelpHandle(CQGroupMessageEventArgs e)
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

            if (Math.Abs(p.StatusInt.Get("援助时间") - DateTime.Now.DayOfYear) < 7) {
                p.SendMes("七天之内只能援助一次~");
                return;
            }

            //异常处理
            if (codes.Count != 1)
            {
                p.SendMes("请选择唯一一个角色");
                return;
            }
            //疯狂高于50
            if (p.Crazy >= 50)
            {
                p.SendMes("请先照顾好自己！");
                return;
            }

            //获取被偷玩家
            long qq2 = long.Parse(codes[0].Items["qq"]);
            //如果这名玩家是自己
            if (p.QQ == qq2)
            {
                p.SendMes("请不要援助自己");
                return;
            }
            if (!Game.Players.ContainsKey(qq2))
            {
                FixStroy.WarnNoUser(e);
                return;
            }

            var p2 = Game.Players[qq2];
            if (p2.Crazy < 50)
            {
                p.SendMes("对方疯狂少于50，无法援助");
                return;
            }
            p.SendMes("患难见真情，对方疯狂-5，你疯狂+6");
            p2.Crazy -= 5;
            p.Crazy += 6;

            p.StatusInt.Set("援助时间", DateTime.Now.DayOfYear);
        }
    }
}
