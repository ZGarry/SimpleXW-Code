using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.player;
using zfjz.mft.v.Code.record;

namespace zfjz.mft.v.Code
{
    //游戏入口
    //出口等
    static public class Game
    {
        //两种记录，数字记录和符号记录
        static public StrRecord StrRecord;
        static public IntRecord IntRecord;

        //玩家
        static public Dictionary<long, Player> Players = new Dictionary<long, Player>();


        

        static public void Init()
        {
            //初始化记录系统
            RecordInit.Load();
            //加载所有玩家
            PlayersInit.Load();
        }

        static public void Save()
        {
            RecordInit.Save();
            PlayersInit.Save();
        }

        static public void DeleteUnused() {
            foreach (var p in Game.Players.Values) {
                var li = p.StatusStr.Dic.Keys.ToList();
                foreach (var c in li) {
                    if (p.StatusStr.Dic[c] == "使用中"|| p.StatusStr.Dic[c] == "on")
                    {
                        p.StatusStr.Dic.Remove(c);
                    }
                }
            }
        }

        static public void quit()
        {
            DeleteUnused();
            Save();
        }
    }
}
