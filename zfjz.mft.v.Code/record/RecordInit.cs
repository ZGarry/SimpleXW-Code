using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code;

namespace zfjz.mft.v.Code.record
{
    //静态类，初始化record到Game
    static class RecordInit
    {
        public static void Load()
        {
            var Cmd = Common.Conn.CreateCommand();
            Cmd.CommandText = "SELECT times,int_record,str_record FROM record";
            var reader = Cmd.ExecuteReader();
            reader.Read();

            Game.IntRecord = new IntRecord(reader["int_record"].ToString());
            Game.IntRecord.times = int.Parse(reader["times"].ToString());
            Game.StrRecord = new StrRecord(reader["str_record"].ToString());
            reader.Close();
            Cmd.Cancel();
        }
       public  static void Save()
        {
            var Cmd = Common.Conn.CreateCommand();
            Cmd.CommandText = $"UPDATE record SET times = {Game.IntRecord.times}, int_record = '{Game.IntRecord.ExportJson()}', str_record = '{Game.StrRecord.ExportJson()}'";
            Cmd.ExecuteNonQuery();
        }
    }
}
