using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

/*
 * 1、新月（朔月，农历初一）：基本看不见，或者隐约看见一弯细线；

2、蛾眉月（农历的初二~初六）：如眉似弓；

3、上弦月（农历初七~初八）：半圆；

4、渐盈凸月（农历初九~十四）：椭圆；
5、满月（望月，农历十五~十六）：圆盘；
6、渐亏凸月（农历十七~二十三）：椭圆；
7、下弦月（农历二十三左右）：半圆；

8、残月（农历二十四~月末）：如眉似弓；

9、农历月最后一天又变为新月：基本看不见，或者隐约看见一弯细线。
 * */

namespace zfjz.mft.v.Code.common
{
    /// <summary>
    /// 月相获取类
    /// </summary>
    static public class Monn
    {
        
        static ChineseLunisolarCalendar chineseDate = new ChineseLunisolarCalendar();
        public static string GetMoonStatus() {
            int y = chineseDate.GetDayOfMonth(DateTime.Now);
            if (y >= 1 && y <= 3) return "新月";
            if (y >= 4 && y <= 7) return "峨眉月";
            if (y >= 8 && y <= 10) return "上弦月";
            if (y >= 11 && y <= 14) return "渐盈凸月";
            if (y >= 15 && y <= 16) return "满月";
            if (y >= 17 && y <= 20) return "渐亏凹月";
            if (y >= 21 && y <= 25) return "下弦月";
            return "残月";
        }
    }
}
