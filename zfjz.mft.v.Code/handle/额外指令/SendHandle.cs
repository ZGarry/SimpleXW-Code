using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;
using System;
using zfjz.mft.v.Code.monster;
using System.Text.RegularExpressions;
using System.Linq;
using Native.Sdk.Cqp;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        //奖励#邪气石@角色
        public static void SendHandle(CQGroupMessageEventArgs e)
        {

            //解析参数
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


            //如果不是我
            long a = 1160564525;
            if (p.QQ != a)
            {
                p.SendMes("你并无此权限");
                return;
            }


            if (e.Message.Text == "奖励#临别赠言")
            {
                e.FromGroup.SendGroupMessage(CQApi.CQCode_AtAll(), "感谢大家这么多天的陪伴，现在，我要休息一会儿了;世界很大，我们有缘再会~");
                e.FromGroup.SendGroupMessage("大家最后的数据，会通过私发消息的方式发给大家，再见！");

                foreach (var p0 in Game.Players.Values)
                {
                    try
                    {
                        //文档位置
                        e.CQApi.SendPrivateMessage(p0.QQ,
                            "百科全书地址：https://zgarry.github.io/SimpleXiuXian/_site/story/index.html");

                        //因一些原因
                        e.CQApi.SendPrivateMessage(p0.QQ,
                            @"这是一封告别信。因为QQ考虑到机器人常用来做一些灰产，封停了所有机器人。我们的机器人，面粉团，也不例外。2020.8.7日上午8: 00，我们将正式关闭面粉团。我们坚信，未来的世界会产生更多连接，生活更加美好！面粉团，再见！");

                        //展示信息
                        string template = @$"{p0.Level.Slogan}
境界: {p0.Level.LevelName} LV.{p0.LevelNum}
修为: {p0.XW}
金币: {p0.Gold}
三相: 体质{p0.Basic} | 疯狂{p0.Crazy} | 幸运{p0.Lucky}
物品: {p0.Package.Show()}";


                        e.CQApi.SendPrivateMessage(p0.QQ, template);

                        //最后，我们也送你一个小道具，希望你不忘初心，继续前行！
                        var itm = items.ItemList.RandomOne(items.ItemList.ALLItem).name;
                        e.CQApi.SendPrivateMessage(p0.QQ,
                            "最后，我们也送你一个小道具，希望你不忘初心，继续前行！");
                        e.CQApi.SendPrivateMessage(p0.QQ,
                            $"{itm}已加入背包！");
                        p0.Package.AddOne(itm);
                    }
                    catch { }

                }
                return;
            }

            //异常处理
            if (codes.Count != 1)
            {
                p.SendMes("请选择唯一一个角色");
                return;
            }

            long qq2 = long.Parse(codes[0].Items["qq"]);
            if (!Game.Players.ContainsKey(qq2))
            {
                FixStroy.WarnNoUser(e);
                return;
            }
            var p2 = Game.Players[qq2];


            //删除消息内code码
            var content = e.Message.Text;
            //删除中括号内内容
            content = Regex.Replace(content, "\\[.*\\]", "");

            //获取要奖励的物品
            var name = content.Split('#')[1].Trim();

            if (!items.ItemList.ALLItem.ContainsKey(name))
            {
                p.SendMes($"不要提供不存在的物品作为奖励~");
                return;
            }

            //
            p2.Package.AddOne(name);

            //e事件中决定了谁被@           
            p.SendMes($"指令已进行");


        }
    }
}
