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
        //禁止玩家操作（闭关）
        public static void FORBINHandle(CQGroupMessageEventArgs e)
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


            //抛出异常来禁止任何出关以外的操作
            if (p.StatusStr.Contain("闭关"))
            {
                throw new Exception();
            }

        }
    }
}
