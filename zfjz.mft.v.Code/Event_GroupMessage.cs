using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using Native.Sdk.Cqp.Model;
using Native.Sdk.Cqp.Enum;
using System;
using zfjz.mft.v.Code.handle;
using zfjz.mft.v.Code.player;
using zfjz.mft.v.Code.common;

namespace zfjz.mft.v.Code
{
    public class Event_GroupMessage : IGroupMessage
    {


        /// <summary>
        /// 收到群消息
        /// </summary>
        /// <param name="sender">事件来源</param>
        /// <param name="e">事件参数</param>
        public void GroupMessage(object sender, CQGroupMessageEventArgs e)
        {
            try
            {
                var mes = e.Message.Text;

                if (mes == "百科")
                {
                    e.FromGroup.SendGroupMessage("百科全书地址：https://zgarry.github.io/SimpleXiuXian/_site/story/index.html");
                }
                if (mes == "出关")
                {
                    Handle.OuthomeHandle(e);
                }
                if (true)
                {
                    handle.Handle.FORBINHandle(e);
                }

                if (mes.StartsWith("赠送"))
                {
                    Handle.GiveHandle(e);
                }
                if (mes == "闭关")
                {
                    Handle.InhomeHandle(e);
                }
                if (mes.StartsWith("援助"))
                {
                    Handle.HelpHandle(e);
                }
                if (mes.StartsWith("奖励"))
                {
                    Handle.SendHandle(e);
                }
                //选项
                if (mes[0] == '#')
                {
                    Handle.ChooseHandle(e);
                }
                if (mes.Contains("偷取"))
                {
                    Handle.RobustHandle(e);
                }
                if (mes == "成就榜")
                {
                    Handle.AcheHandle(e);
                }
                if (mes == "签到")
                {
                    Handle.SignInHandle(e);
                }
                if (mes.StartsWith("作弊码"))
                {
                    Handle.CheatHandle(e);
                }
                if (mes.Contains("使用"))
                {
                    Handle.UseHandle(e);
                }
                if (mes == "抽奖")
                {
                    Handle.RandomHandle(e);
                }
                if (mes == "装备栏")
                {
                    Handle.LookEquipHandle(e);
                }
                if (mes.StartsWith("挑战"))
                {
                    Handle.FightHandle(e);
                }
                if (mes.StartsWith("双修"))
                {
                    Handle.TwoHandle(e);
                }
                if (mes.StartsWith("查看"))
                {
                    Handle.YouselfHandle(e);
                }
                if (mes == "遗迹")
                {
                    Handle.PlaceHandle(e);
                }
                if (mes.StartsWith("挑衅"))
                {
                    Handle.FightMonsterHandle(e);
                }
                if (mes == "商店")
                {
                    Handle.ShopHandle(e);
                }
                if (mes == "交易所")
                {
                    Handle.BlockHandle(e);
                }
                if (mes.Contains("购买"))
                {
                    Handle.BuyHandle(e);
                }
                if (mes == "看大佬")
                {
                    Handle.LookUpHandle(e);
                }
                if (mes == "任务")
                {
                    Handle.TaskHandle(e);
                }
                if (mes == "测试")
                {

                }
                if (mes == "教学")
                {
                    Handle.LearnHandle(e);
                }
                if (mes == "统计")
                {
                    Handle.ShowStatusHandle(e);
                }
                //if (mes.StartsWith("日期"))
                //{
                //    Handle.DayHandle(e);
                //}
                //if (mes.Contains("群主"))
                //{
                //    Handle.SayGoodHandle(e);
                //}

                if (true)
                {
                    Game.IntRecord.TimesAdd();
                }
            }
            catch
            {

            }

            // 设置该属性, 表示阻塞本条消息, 该属性会在方法结束后传递给酷Q
            e.Handler = false;
        }
    }
}