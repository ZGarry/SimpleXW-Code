using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using zfjz.mft.v.Code.player;
using zfjz.mft.v.Code.common;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void SignInHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
            CQCode cqat = e.FromQQ.CQCode_At();
            var qq = e.FromQQ.Id;

            //尚未创建角色，为之创建
            if (!Game.Players.ContainsKey(qq))
            {
                e.FromGroup.SendGroupMessage(cqat, " ", $"这是您第一次签到，正为您创建角色");
                Game.Players.Add(qq, new Player(qq));
            }

            var p = Game.Players[qq];
            p.SetEIn(e);

            if (p.StatusInt.Get("上次签到时间")==DateTime.Now.DayOfYear)
            {
                e.FromGroup.SendGroupMessage(cqat, " ", $"今天你签过到啦！");
                return;
            }
            p.StatusInt.Set("上次签到时间", DateTime.Now.DayOfYear);
            p.StatusInt.Add("本周签到次数", 1);

            if (DayOfWeek.Sunday == DateTime.Now.DayOfWeek && p.StatusInt.Get("本周签到次数") == 7)
            {
                p.StatusInt.Set("本周签到次数", 0); 
                p.Gold += 1;
                e.FromGroup.SendGroupMessage(cqat, " ", $"连续签到一周，金币数+1");
            }
           
         
            //节日签到
            GetTodayMes(e, p);
            //签到结算
            p.SignIn(e);
        }
        //获取今日状况
        private static void GetTodayMes(CQGroupMessageEventArgs e,Player p)
        {
            CQCode cqat = e.FromQQ.CQCode_At();

            int code;
            string name;
            
            //如果已经查询过
            if (Game.IntRecord.Get("上次查询节日信息") == DateTime.Now.DayOfYear)
            {
                code = Game.IntRecord.Get("节日代码");
                name = Game.StrRecord.Get("节日名");
                
            }
            else
            {
                //格式形如：2020-10-1
                var url = @"http://holiday.zhusaidong.cn/api.php?date=" + $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                string html = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                var RESULT = Regex.Match(html, "\"code\":(\\d).*\"Name\":\"(.*?)\"");
                code = int.Parse(RESULT.Groups[1].Value);
                name = RESULT.Groups[2].Value;
                //e.FromGroup.SendGroupMessage(cqat, " ", $"{code}{name}");
                Game.IntRecord.Set("上次查询节日信息",DateTime.Now.DayOfYear);
            }

            if (code == 1)
            {
                p.XW += 100;
                e.FromGroup.SendGroupMessage(cqat, " ", $"{name}快乐！100点修为已经送入你的账户~");
            }
        }
    }
}
