using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.player
{
    static public class PlayersInit
    {
        static private void clearTable()
        {
            var Cmd = Common.Conn.CreateCommand();
            Cmd.CommandText = "DELETE FROM players";
            Cmd.ExecuteNonQuery();
            Cmd.Cancel();
        }
        static private void insertAll()
        {
            var Cmd = Common.Conn.CreateCommand();
            StringBuilder sql = new StringBuilder("INSERT INTO  players (qq,xw,levelnum,gold,basic,crazy,lucky,items,statusInt,statusStr,equip) VALUES ");

            foreach (var p in Game.Players.Values)
            {
                sql.Append($"( {p.QQ}, {p.XW}, {p.LevelNum},{p.Gold}, {p.Basic},{p.Crazy},{p.Lucky},  '{p.Package.ExportJson()}','{p.StatusInt.ExportJson()}','{p.StatusStr.ExportJson()}','{p.Equip.ExportJson()}' ),");
            }
            var sqlStr = sql.ToString();
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            Cmd.CommandText = sqlStr + ";";
            Cmd.ExecuteNonQuery();
            Cmd.Cancel();
        }
        static public void Load()
        {
            //先清空，再加载
            if (Game.Players.Count > 0)
            {
                Game.Players.Clear();
            }

            var Cmd = Common.Conn.CreateCommand();
            Cmd.CommandText = "SELECT qq,xw,levelnum,gold,basic,crazy,lucky,items,statusInt,statusStr,equip FROM players";
            var reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                var qq = long.Parse(reader["qq"].ToString());
                var XW = int.Parse(reader["xw"].ToString());
                var LevelIndex = int.Parse(reader["levelnum"].ToString());
                var Gold = int.Parse(reader["gold"].ToString());


                var basic = int.Parse(reader["basic"].ToString());
                var crazy = int.Parse(reader["crazy"].ToString());
                var lucky = int.Parse(reader["lucky"].ToString());

                var Items = reader["items"].ToString();
                var StatusInt = reader["statusInt"].ToString();
                var StatusStr = reader["statusStr"].ToString();
                var Equip = reader["equip"].ToString();

                var p = new Player(qq, XW, LevelIndex, Gold, basic, crazy, lucky, Items, StatusInt,StatusStr, Equip);
                Game.Players.Add(qq, p);
            }
            reader.Close();
            Cmd.Cancel();
        }
        static public void Save()
        {
            if (Game.Players.Count == 0)
            {
                return;
            }
            clearTable();           
            insertAll();
        }
    }
}
