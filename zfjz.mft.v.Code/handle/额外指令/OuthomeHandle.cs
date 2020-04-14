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

        //出关
        public static void OuthomeHandle(CQGroupMessageEventArgs e)
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

            if (!p.StatusStr.Contain("闭关"))
            {
                p.SendMes("不闭关如何出关");
                return;
            }


            //直接使用c#的时间构造和时间求差

            var ago = new DateTime(p.StatusInt.Get("入关年"), p.StatusInt.Get("入关月"), p.StatusInt.Get("入关日"));
            var num = (DateTime.Now - ago).Days;
            if (num < 10)
            {
                p.SendMes("至少需要闭关十天！");
                return;
            }
            p.StatusStr.Dic.Remove("闭关");
            p.Basic += num;
            p.XW += num * num;
            p.SendMes($"恭喜出关！你闭关了长达{num}天，获得体质{num}点，修为{num * num}点");
        }
    }
}
