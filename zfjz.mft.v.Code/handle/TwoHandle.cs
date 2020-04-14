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
        public static void TwoHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
            CQCode cqat = e.FromQQ.CQCode_At();
            var qq = e.FromQQ.Id;
            var codes = e.Message.CQCodes;
            //获取个人信息
            if (!Game.Players.ContainsKey(qq))
            {
                FixStroy.WarnNoCreateUser(e);
                return;
            }
            var p = Game.Players[qq];
            p.SetEIn(e);

            if (p.LevelNum < 4)
            {
                p.SendMes($"境界达到唤灵境才可以双修");
                return;
            }

            if (codes.Count == 0)
            {
                p.SendMes("请选择一个双修的对象");
                return;
            }

            if (codes.Count > 1)
            {
                e.FromGroup.SendGroupMessage(cqat, " ", "等到你变得更强的时候，再来和更多人一起双修吧！");
                return;
            }

            if (p.StatusInt.Get("上次双修时间") == DateTime.Now.DayOfYear)
            {
                e.FromGroup.SendGroupMessage(cqat, " ", "你今天已经*修过啦~");
                return;
            }

            //获取被双修玩家
            long qq2 = long.Parse(codes[0].Items["qq"]);

            //如果这名玩家是自己
            if (p.QQ == qq2)
            {
                e.FromGroup.SendGroupMessage(cqat, " ", "请不要和自己双修~");
                return;
            }

            if (!Game.Players.ContainsKey(qq2))
            {
                FixStroy.WarnNoUser(e);
                return;
            }

            var p2 = Game.Players[qq2];

            //更新双修日期
            p.StatusInt.Set("上次双修时间", DateTime.Now.DayOfYear);

            //上次的
            var p1str = p.QQ.ToString();
            var p1ChooseStr = p.StatusStr.Get("双修对象");
            var p1time = p.StatusInt.Get("上次双修时间");
            //这次选择的
            var p2str = p2.QQ.ToString();
            var p2ChooseStr = p2.StatusStr.Get("双修对象");
            var p2time = p2.StatusInt.Get("上次双修时间");


            //有且仅有一种情况加，双方今日都选了对方作为双修对象
            if (p2ChooseStr == p1str && p1time == p2time)
            {
                //设置一个上限！
                if (p.StatusInt.Get("双修分") < (p.LevelNum + p2.LevelNum) * 10)
                {
                    p.StatusInt.Add("双修分", 5);
                    p2.StatusInt.Add("双修分", 5);
                }

                var r = p.StatusInt.Get("双修分");

                p.XW += r;
                p2.XW += r;
                e.FromGroup.SendGroupMessage(cqat, $"[CQ:at,qq={qq2}]", " ", $"你们两人一番云雨，水到渠成,功力各增加{r}点");
            }
            else
            {
                //如果你坚持了同一个双修对象
                if (p2str == p1ChooseStr)
                {
                    e.FromGroup.SendGroupMessage(cqat, " ", $"对方还没有回应你的双修~等待机会吧");
                }
                //第一次选择角色，或换角色
                else
                {
                    p.StatusInt.Set("双修分", 0);
                    p.StatusStr.Set("双修对象", p2str);
                    e.FromGroup.SendGroupMessage(cqat, " ", $"你选择了一个新的双修对象");
                }
            }

        }
    }
}
