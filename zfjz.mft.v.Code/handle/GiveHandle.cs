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
        //来自群主的馈赠
        public static void GiveITHandle(CQGroupMessageEventArgs e)
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
            if (p.StatusStr.Contain("馈赠"))
            {
                p.SendMes("你已经领取过一次群主的馈赠了！");
                return;
            }

            if (p.XW <= 9000)
            {
                p.SendMes("你太弱了，不配领取群主的馈赠！");
                return;
            }

            //正常领取
            p.Package.AddOne("小树苗");
            p.Package.AddOne("疾跑药水");
            p.StatusStr.Set("馈赠", "True");
            p.SendMes($"请领取你的馈赠吧！一个小树苗，一个疾跑药水已入账！");
        }
    }
}
