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
        //遗迹
        public static void PlaceHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
            var qq = e.FromQQ.Id;
            var codes = e.Message.CQCodes;

            //无此人，直接返回           
            if (!Game.Players.ContainsKey(qq))
            {
                return;
            }
            var p = Game.Players[qq];
            p.SetEIn(e);

            //时间判断
            if (DateTime.Now.DayOfWeek != DayOfWeek.Saturday && DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
            {
                p.SendMes($"遗迹将在每周六、周日晚上七点开放，八点关闭");
                return;
            }
            //19-20(不包括二十)
            if (DateTime.Now.Hour != 19)
            {
                p.SendMes($"遗迹将在每周六、周日晚上七点开放，八点关闭");
                return;
            }

            //如果是今天第一次进入该遗迹，则需要选中一个遗迹
            if (Game.IntRecord.Get("进入遗迹时间") != DateTime.Now.DayOfYear || NowPlace.Now==null) {
            //随机选中一个作为本次的遗迹
            NowPlace.ChangeAnother();
            //释放入场效果
            //NowPlace.Now.Enter(e);
            //记载今日已经进入遗迹了
            Game.IntRecord.Set("进入遗迹时间", DateTime.Now.DayOfYear);
            }
            //如果今天已经选出遗迹了，则直接展示


            NowPlace.Now.LookByPerson(p);
        }
    }
}
