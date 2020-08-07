using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        //显示当前所有违禁品
        public static void ForbinHandle(CQGroupMessageEventArgs e)
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

            //展示信息
            var s = @"易章大帝敕令-356号
以下物品，部分因效果强大对党国安全造成不可忽略的威胁，部分因效果过于薄弱，存在欺骗消费者的嫌疑，予以禁止。
";
            foreach (var c in items.ItemList.Forbin.Keys)
            {
                s += "\n" + c;
            }
            p.SendMes(s);






        }
    }
}
