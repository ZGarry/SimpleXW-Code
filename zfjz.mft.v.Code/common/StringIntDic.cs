using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.common
{
    public class StringIntDic
    {
        /// <summary>
        /// 底层的string-int结构
        /// </summary>
        public Dictionary<string, int> Dic = new Dictionary<string, int> { };

        /// <summary>
        /// 构造创建
        /// </summary>
        /// <param name="s">json字符串</param>
        public StringIntDic(string s)
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
                Dic = JsonConvert.DeserializeObject<Dictionary<string, int>>(s);
            }
            catch
            {

            }
            finally
            {
                if (Dic == null)
                {
                    Dic = new Dictionary<string, int>();
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

        public int Get(string key)
        {
            if (Contain(key))
            {
                return Dic[key];
            }
            else
            {
                return 0;
            }
        }
        public void Set(string key, int num)
        {
            if (Contain(key))
            {
                Dic[key] = num;
            }
            else
            {
                Dic.Add(key, num);
            }
        }

        public void Add(string itemName, int num)
        {
            if (Contain(itemName))
            {
                Dic[itemName] += num;
            }
            else
            {
                Dic.Add(itemName, num);
            }
        }
        public void AddOne(string itemName)
        {
            Add(itemName, 1);

        }
        public bool Lose(string itemName, int num)
        {
            if (Contain(itemName))
            {
                if (Dic[itemName] > num)
                {
                    Dic[itemName] -= num;
                    return true;
                }
                if (Dic[itemName] == num)
                {
                    Dic.Remove(itemName);
                    return true;
                }
                if (Dic[itemName] < num)
                {
                    return false;
                }
            }

            return false;
        }
        public bool LoseOne(string itemName)
        {
            return Lose(itemName, 1);
        }
        public Boolean Contain(string itemName)
        {
            return Dic.ContainsKey(itemName);
        }
    }
}
