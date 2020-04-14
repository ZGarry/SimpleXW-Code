using System;
using System.Collections.Generic;
using System.Data.SQLite;
using zfjz.mft.v.Code.common;

namespace zfjz.mft.v.Code
{
    public class Common
    {
        //数据库连接
        static public SQLiteConnection Conn;
        static public List<Level> Levels;
        static public Random Random = new Random();

        static public String[] Word;
        //投一下百面骰
        static public int D()
        {
            return Random.Next(1, 101);
        }

        /// <summary>
        /// 被好运命中
        /// </summary>
        /// <param name="rate">命中率</param>
        /// <returns></returns>
        static public Boolean Hit(int rate)
        {
            if (D() <= rate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
