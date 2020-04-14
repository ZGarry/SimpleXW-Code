using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code;
using System.Collections.Generic;

namespace zfjz.mft.v.Code.record
{
    public class IntRecord : StringIntDic
    {
        public int times;
        public IntRecord(string s) : base(s) { }

        public void TimesAdd()
        {
            times++;
            if (times % Config.SaveFrequency == 0)
            {
                Game.Save();
            }
        }

        public string Report()
        {
            return $"总计发言：{times}次";
        }
    }
}
