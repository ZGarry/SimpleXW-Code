using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using zfjz.mft.v.Code.common;

namespace zfjz.mft.v.Code.player
{
    /// <summary>
    /// 背包，用于玩家的物品管理
    /// </summary>
    public class Package : StringIntDic
    {
        public Package(string s) : base(s)
        {
        }
        public override string Show()
        {
            if (Dic.Count == 0)
            {
                return "空";
            }
            StringBuilder s = new StringBuilder();
            foreach (var v in Dic)
            {
                if (Dic[v.Key] <= 0)
                {
                    continue;
                }
                if (Dic[v.Key] == 1)
                {
                    s.Append(v.Key);
                }
                else
                {
                    s.Append(v.Key + "`" + Dic[v.Key]);
                }
                s.Append("、");
            }
            var res = s.ToString();
            return res.Substring(0, res.Length - 1);
        }
    }
}

