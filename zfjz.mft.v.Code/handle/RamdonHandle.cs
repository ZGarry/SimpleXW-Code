using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;
using zfjz.mft.v.Code.shop;
using System.Linq;
using zfjz.mft.v.Code.items;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void RandomHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
            CQCode cqat = e.FromQQ.CQCode_At();
            var qq = e.FromQQ.Id;

            //获取个人信息
            if (!Game.Players.ContainsKey(qq))
            {
                FixStroy.WarnNoCreateUser(e);
                return;
            }
            var p = Game.Players[qq];
            p.SetEIn(e);

            //展示信息
            ItemList.Lottery(p);




        }
    }
}
