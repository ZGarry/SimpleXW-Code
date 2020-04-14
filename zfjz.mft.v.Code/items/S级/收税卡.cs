using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.items
{
    public class 收税卡 : Item
    {

        public 收税卡() : base(
            name0: "收税卡", priceLow0: 999, priceHigh0: 999,
            fuc: "所有玩家(修为超过你的）立即给你一个金币", icon: "",
            des: "5000元是中华人民共和国个税起征点", level: "S")
        {
        }

        public override async void EffectIn(Player p)
        {
            var li = Game.Players.Values.ToList();
            int num = 0;
            foreach (var per in li)
            {
                if (per.XW > p.XW && per.Gold >= 1)
                {
                    per.Gold -= 1;
                    num += 1;
                }
            }
            p.Gold += num;
            p.SendMes($"你总共收的税款{num}金，感谢所有交了税的合法公民！");
        }
    }
}
