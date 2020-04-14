using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.items;

namespace zfjz.mft.v.Code.monster
{
    public class 无知渔民 : Monster
    {
        public 无知渔民() : base(
            name0: "无知渔民", XW0: 600, basic0: 100, Crazy0: 400, Lucky0: 0,
            fuc0: "无", lose0: "随机C级道具",
            icon0: "", level0: "小兵")
        {
        }
    }
}
