using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;
using zfjz.mft.v.Code.items;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        /// <summary>
        /// 赠送
        /// </summary>
        /// <param name="e"></param>
        public static void GiveHandle(CQGroupMessageEventArgs e)
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

            if (p.LevelNum < 7)
            {
                p.SendMes("境界达到寻灵境才可以赠送东西给伴侣物品");
                return;
            }

            if (e.Message.Text == "赠送")
            {
                //展示信息
                p.SendMes("使用‘赠送#物品名’来把自己背包中的一个道具，赠送给自己的伴侣");
                return;
            }

            if (e.Message.Text.Contains("赠送#"))
            {
                //展示信息
                var name = e.Message.Text.Split('#')[1];
                if (!p.Package.Contain(name))
                {
                    p.SendMes("请不要送出你没有的物品");
                    return;
                }


                if (p.StatusInt.Get("双修分") < 50)
                {
                    p.SendMes("清热分还不到50，还不能赠送物品~请再接再厉");
                    return;
                }
                p.Package.LoseOne(name);
                var p2 = Game.Players[long.Parse(p.StatusStr.Get("双修对象"))];
                //获得
                p2.Package.AddOne(name);
                p.SendMes($"你失去了{name},对方获得了{name}");

            }

            return;
        }



    }
}

