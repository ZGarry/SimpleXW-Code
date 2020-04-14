using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;
using System;
using zfjz.mft.v.Code.monster;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        //挑衅野怪
        public static void FightMonsterHandle(CQGroupMessageEventArgs e)
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

            //使用
            if (p.StatusInt.Get("上次挑衅时间") == DateTime.Now.DayOfYear)
            {
                p.SendMes("每次遗迹开放都只能挑衅一次~");
                return;
            }
            //时间判断
            if (DateTime.Now.DayOfWeek != DayOfWeek.Saturday && DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
            {
                p.SendMes($"遗迹开放时才能挑衅");
                return;
            }
            //19-20(不包括二十)
            if (DateTime.Now.Hour != 19)
            {
                p.SendMes($"现在不是挑衅的时间");
                return;
            }
            //今天还没进入遗迹
            if (Game.IntRecord.Get("进入遗迹时间") != DateTime.Now.DayOfYear) {
                p.SendMes("请先进入遗迹");
                return;
            }

            var monsterName = e.Message.Text.Split('#')[1];

            p.StatusInt.Set("上次挑衅时间", DateTime.Now.DayOfYear);
            NowPlace.MonsterATKbyPerson(p, monsterName);


           

        }
    }
}
