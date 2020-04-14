using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using System.Data.SQLite;
using zfjz.mft.v.Code.player;
using zfjz.mft.v.Code.common;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace zfjz.mft.v.Code
{
    public class Event_AppEnable : IAppEnable
    {
        public void AppEnable(object sender, CQAppEnableEventArgs e)
        {
            e.CQLog.Info("[Ruby]", "应用开启");


            //启用数据库
            Common.Conn = new SQLiteConnection(@"data source=data.db");
            Common.Conn.Open();
            //初始化等级系统
            Common.Levels = new List<common.Level>{
                //new common.Level(-2,"底灵境",-500,"从未有人到过的天堂",100,0),
                //new common.Level(-1,"克灵境",-100,"向死而生",100,0),
                  new common.Level(0,"凡人境",0,"普通",100,0),
                   new common.Level(1,"入灵境",333,"初窥门槛",100,0),
                    new common.Level(2,"虚灵境",666,"力量涌动",100,0),
                     new common.Level(3,"乞灵境",999,"乞灵之下，皆为凡人",40,-100),
                      new common.Level(4,"唤灵境",1999,"水木草石，始知形意",71,-500),
                       new common.Level(5,"通灵境",3599,"通天灵力，移山填海",44,-777),

                        new common.Level(6,"问灵境",6000,"探幽寻微，法力无边",69,-560),
                         new common.Level(7,"寻灵境",10000,"寻天问道，初登大堂",25,-314),
                          new common.Level(8,"叩灵境",15000,"道前一叩，生死由天",20,-324),
                           new common.Level(9,"化灵境",30000,"灵气化体，身融天地",15,-2000),
                            new common.Level(10,"地灵境",60000,"天地有灵，由谁执掌",10,-9999),

                             new common.Level(11,"天灵境",120000,"天地有灵，吾执掌之",5,-9999),
                              new common.Level(12,"仙境",240000,"仙人抚顶，羽化飞升",0,-4444),

                      new common.Level(100,"不可能",100000000,"不可能",71,-500)
            };
            e.CQLog.Info("[Ruby]", "数据库加载成功");
            Game.Init();
            e.CQLog.Info("[Ruby]", "玩家以及游戏加载成功");
            //读取夸群主的词语

            //StreamReader reader = new StreamReader(@"good.txt", Encoding.GetEncoding("utf-8"));
            //Common.Word = reader.ReadToEnd().Replace("\r\n","\n").Split('\n');
            //e.CQLog.Info("[Ruby]", "读取成功");

            //reader.Close();
        }
    }
}
