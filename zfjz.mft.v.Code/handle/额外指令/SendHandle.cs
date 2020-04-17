using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;
using System;
using zfjz.mft.v.Code.monster;
using System.Text.RegularExpressions;

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

            if (!items.ItemList.ALLItem.ContainsKey(name)) {
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
