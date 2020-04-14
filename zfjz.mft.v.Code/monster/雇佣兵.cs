using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.monster
{
    public class 雇佣兵 : Monster
    {
        public 雇佣兵() : base(
            name0: "雇佣兵", XW0: 8000, basic0: 800, Crazy0: 0, Lucky0: 5,
            fuc0: "无", lose0: "10枚金币",
            icon0: "", level0: "小兵")
        {
        }
    }
}
