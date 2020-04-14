using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using System.Linq;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void LookUpHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
            CQCode cqat = e.FromQQ.CQCode_At();
            var qq = e.FromQQ.Id;

            //提示没有角色
            if (!Game.Players.ContainsKey(qq))
            {
                FixStroy.WarnNoCreateUser(e);
                return;
            }

            //排序
            var up = Game.Players.Values.ToList().OrderBy(x => -x.XW).ToList();
            //找出你在其中的位置
            int i = 0;
            for (; i < up.Count; i++)
            {
                if (up[i].QQ == qq)
                {
                    break;
                }
            }

            //展示信息
            string template = $@"修为排行榜-像大佬学习！
1.{e.FromGroup.GetGroupMemberInfo(up[0].QQ).Nick} | {up[0].XW} |
2.{e.FromGroup.GetGroupMemberInfo(up[1].QQ).Nick} | {up[1].XW} |
3.{e.FromGroup.GetGroupMemberInfo(up[2].QQ).Nick} | {up[2].XW} |
4.{e.FromGroup.GetGroupMemberInfo(up[3].QQ).Nick} | {up[3].XW} |
5.{e.FromGroup.GetGroupMemberInfo(up[4].QQ).Nick} | {up[4].XW} |";
            if (0 <= i && i <= 4)
            {
                template += "\n你在榜上！再接再厉！";
            }
            else if (i == up.Count - 1)
            {
                template += @$"
......
{i - 1 + 1}. {e.FromGroup.GetGroupMemberInfo(up[i - 1].QQ).Nick} | {up[i - 1].XW} |
{i + 1}. {e.FromGroup.GetGroupMemberInfo(up[i].QQ).Nick} | {up[i].XW} |
你是最后一名，加油！";
            }
            else
            {
                template += @$"
......
{i - 1 + 1}. {e.FromGroup.GetGroupMemberInfo(up[i - 1].QQ).Nick} | {up[i - 1].XW} |
{i + 1}. {e.FromGroup.GetGroupMemberInfo(up[i].QQ).Nick} | {up[i].XW} |
{i + 1 + 1}. {e.FromGroup.GetGroupMemberInfo(up[i + 1].QQ).Nick} | {up[i + 1].XW} |";
            }

            e.FromGroup.SendGroupMessage(template);
        }
    }
}
