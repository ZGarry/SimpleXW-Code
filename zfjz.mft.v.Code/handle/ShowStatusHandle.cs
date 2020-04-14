using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using System;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void ShowStatusHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
            CQCode cqat = e.FromQQ.CQCode_At();

            //展示信息
            e.FromGroup.SendGroupMessage(cqat, " ", Face.RandomFace(), Game.IntRecord.Report());
        }
    }
}
