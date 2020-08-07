using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.items
{
    public class 天山雪莲 : Item
    {
        //可以此处静态的把他加入ITEM-C
        //静态类创建的时候加入列表，这是一个可以考虑发展的方向

        public 天山雪莲() : base(
            name0: "天山雪莲", priceLow0: 7, priceHigh0: 33,
            fuc: "增加修为到能整除1000", icon: "",
            des: "登人任歌指羽，长卷应天能怜", level: "A")
        {
        }

        public override void EffectIn(Player p)
        {
            //舍弃尾数 + 1
            //0 -- 1000
            //-1000 -- 0
            //1000 -- 2000
            int target = (p.XW / 1000 + 1) * 1000;
            int add = target - p.XW;
            p.XW += add;

            p.SendMes($"{name}让你精神焕发，修为+{add}");



        }
    }
}
