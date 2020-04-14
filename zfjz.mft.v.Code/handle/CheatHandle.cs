using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using System.Linq;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;
using zfjz.mft.v.Code.shop;
using zfjz.mft.v.Code.items;
using System;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void CheatHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
            var qq = e.FromQQ.Id;
            //获取个人信息
            if (!Game.Players.ContainsKey(qq))
            {
                FixStroy.WarnNoCreateUser(e);
                return;
            }
            var p = Game.Players[qq];
            p.SetEIn(e);

            //
            if (p.StatusStr.Contain("作弊")) {
                p.SendMes("你已经使用过一次作弊码了");
                return;
            }

            //
            var input = int.Parse(e.Message.Text.Split('#')[1]);
            var all = 0;
            foreach (char c in qq.ToString()) {
                all += int.Parse(c.ToString());
            }

            //如果正确
            if (input == DateTime.Now.Day * all) {
                p.Gold += 3;
                var c=ItemList.RandomOne(ItemList.ItemsC).name;
                var b=ItemList.RandomOne(ItemList.ItemsB).name;
                p.Package.AddOne(c);
                p.Package.AddOne(b);
                p.StatusStr.Set("作弊", "True");
                p.SendMes($"你输入了正确的作弊码！奖励金币3个，一个{c}，一个{b}~");
            }
        }
    }
}
