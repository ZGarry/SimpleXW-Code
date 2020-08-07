using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using System.Linq;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void InjuredHandle(CQGroupMessageEventArgs e)
        {
            //从高往低
            var up = Game.Players.Values.ToList().OrderBy(x => -x.Package.Get("负伤")).ToList();
            //找出你在其中的位置
            int i = 0;
            for (; i < up.Count; i++)
            {
                if (up[i].QQ == e.FromQQ.Id)
                {
                    break;
                }
            }

            //展示信息
            string template = $@"负伤排行榜-言多必失！
昵称-负伤次数
1.{e.CQApi.GetStrangerInfo(up[0].QQ).Nick} | {up[0].Package.Get("负伤")} |
2.{e.CQApi.GetStrangerInfo(up[1].QQ).Nick} | {up[1].Package.Get("负伤")} |
3.{e.CQApi.GetStrangerInfo(up[2].QQ).Nick} | {up[2].Package.Get("负伤")} |
4.{e.CQApi.GetStrangerInfo(up[3].QQ).Nick} | {up[3].Package.Get("负伤")} |
5.{e.CQApi.GetStrangerInfo(up[4].QQ).Nick} | {up[4].Package.Get("负伤")} |";

            if (0 <= i && i <= 4)
            {
                template += "\n你在榜上！再接再厉少水群！";
            }
            else if (i == up.Count - 1)
            {
                template += @$"
......
{i - 1 + 1}. {e.CQApi.GetStrangerInfo(up[i - 1].QQ).Nick} | {up[i - 1].Package.Get("负伤")} |
{i + 1}. {e.CQApi.GetStrangerInfo(up[i].QQ).Nick} | {up[i].Package.Get("负伤")} |
你是最后一名，加油！";
            }
            else
            {
                template += @$"
......
{i - 1 + 1}. {e.CQApi.GetStrangerInfo(up[i - 1].QQ).Nick} | {up[i - 1].Package.Get("负伤")} |
{i + 1}. {e.CQApi.GetStrangerInfo(up[i].QQ).Nick} | {up[i].Package.Get("负伤")} |
{i + 1 + 1}. {e.CQApi.GetStrangerInfo(up[i + 1].QQ).Nick} | {up[i + 1].Package.Get("负伤")} |";
            }

            e.FromGroup.SendGroupMessage(template);
        }
    }
}
