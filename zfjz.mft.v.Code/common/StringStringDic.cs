using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.common
{
    public class StringStringDic
    {
        /// <summary>
        /// 底层的string-string结构
        /// </summary>
        public Dictionary<string, string> Dic = new Dictionary<string, string> { };


        /// <summary>
        /// 构造创建
        /// </summary>
        /// <param name="s">json字符串</param>
        public StringStringDic(string s)
        {
            LoadJson(s);
        }

        /// <summary>
        /// 从json字符串加载
        /// </summary>
        /// <param name="s">json字符串</param>
        public void LoadJson(string s)
        {
            try
            {
                Dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(s);            
            }
            catch
            {
             
            }
            finally {
                if (Dic == null)
                {
                    Dic = new Dictionary<string, string>();
                }
            }
        }

        /// <summary>
        /// 导出为json字符串
        /// </summary>
        public string ExportJson()
        {
            return JsonConvert.SerializeObject(Dic);
        }

        public virtual string Show()
        {
            return "";
        }

        public string Get(string key)
        {
            if (Contain(key))
            {
                return Dic[key];
            }
            else
            {
                return "";
            }
        }
        public void Set(string key, string str)
        {
            if (Contain(key))
            {
                Dic[key] = str;
            }
            else
            {
                Dic.Add(key, str);
            }
        }

        public Boolean Contain(string itemName)
        {
            return Dic.ContainsKey(itemName);
        }
    }
}
