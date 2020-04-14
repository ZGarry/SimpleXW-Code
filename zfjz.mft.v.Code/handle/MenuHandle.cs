using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using System;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void MenuHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
            CQCode cqat = e.FromQQ.CQCode_At();

            //展示信息
            e.FromGroup.SendGroupMessage(cqat, " ", Face.RandomFace(), @"
签到 挑战@一个玩家 查看
查看#物品名 装备栏 看大佬
使用#物品名 购买#物品名 商店
双修@一个玩家");
        }
    }
}
