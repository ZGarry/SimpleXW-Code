using Native.Sdk.Cqp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.player
{
    /// <summary>
    /// 用于一些方面的固定消息
    /// </summary>
    static public class FixStroy
    {
        //random one
        static private string RandomChoose(string[] strs)
        {
            return strs[Common.Random.Next(strs.Length)];
        }
        //挑战空气
        static private string[] FightWindStory = new string[] {
            "你挑战的是，不存在的强者，空气之主，The KING of WIND，奥脱墨斯菲尔！",
            "我的意思是，你为什么不@一个玩家呢？",
            "墙可不会还手",
            "悄悄告诉你，空气中含量最高的成分不是氧气"
        };

        /// <summary>
        /// 用户警告用户挑战空气
        /// </summary>
        static public void WarnUnserFightWind(Native.Sdk.Cqp.EventArgs.CQGroupMessageEventArgs e)
        {
            CQCode cqat = e.FromQQ.CQCode_At();
            e.FromGroup.SendGroupMessage(cqat, " ", RandomChoose(FightWindStory));
        }

        //查无此用户
        static private string[] NoFighterUserStroy = new string[] {
            "查无此人",
            "啊，貂蝉玩家还在赶来的路上",
            "你挑战的对象还没创建角色，如果你愿意，我们可以安排Dio来让你挑战",
            "你挑战的玩家还没有创建角色，就像你喜欢的番剧总不出3一样"
        };

        /// <summary>
        /// 用户警告用户挑战空气
        /// </summary>
        static public void WarnNoUser(Native.Sdk.Cqp.EventArgs.CQGroupMessageEventArgs e)
        {
            CQCode cqat = e.FromQQ.CQCode_At();
            e.FromGroup.SendGroupMessage(cqat, " ", RandomChoose(NoFighterUserStroy));
        }

        //not create User
        static private string[] NotCreateUser = new string[] {
            "小可爱~请先创建角色啦~",
            "我以前觉得我上我也行，直到我下载了游戏",
            "使用【签到】创建角色",
            "如果你尚未创建角色却可以开始游戏，那一定是我写出了船新的bug"
        };
        static public void WarnNoCreateUser(Native.Sdk.Cqp.EventArgs.CQGroupMessageEventArgs e)
        {
            CQCode cqat = e.FromQQ.CQCode_At();
            e.FromGroup.SendGroupMessage(cqat, " ", RandomChoose(NotCreateUser));
        }
    }
}
