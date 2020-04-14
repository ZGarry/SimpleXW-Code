using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using System.Linq;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void AcheHandle(CQGroupMessageEventArgs e)
        {
            string tem = @"    成绩榜！ 
-------------------
每一个实现过成就的人，都是修仙史上的一段传奇";
            string b = "";
            //显示所有成就
            foreach (var p in Game.Players.Values)
            {
                var li = p.StatusStr.Dic.Keys.ToList();
                foreach (var c in li)
                {
                    if (p.StatusStr.Dic[c] == "成就")
                    {
                        b += $"\n{e.FromGroup.GetGroupMemberInfo(p.QQ).Nick} | {c}";
                    }
                }
            }
            if (b == "") {
                b = "\n目前成就榜单为空";
            }

            e.FromGroup.SendGroupMessage(tem+b);
        }
    }
}
