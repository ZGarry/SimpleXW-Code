using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.common;

namespace zfjz.mft.v.Code.player
{
    /// <summary>
    /// 状态栏，为player类提供支持
    /// </summary>
    public class StatusStr : StringStringDic
    {
        public StatusStr(string s) : base(s)
        {
        }
    }
}
