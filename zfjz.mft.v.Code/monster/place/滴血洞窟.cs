using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;

namespace zfjz.mft.v.Code.monster
{
    public class 滴血洞窟 : Place
    {
        public 滴血洞窟() : base(
            name0: "滴血洞窟", des0: "西北高纬地区向来干燥少雨，那里的人民不服教管，迷信，喜好丧葬事宜，在雷山左翼喀斯特地貌处立起迷宫般...",
            header0: "骸骨大将", mid0: "蝙蝠群", solder0: "绞首巨蟒"
            )
        {

        }
        public override void Enter(CQGroupMessageEventArgs e)
        {
            //进入遗迹
            for (int i = 0; i < Game.Players.Count; i++) {
                Game.Players[i].Crazy +=7;
            }
            e.FromGroup.SendGroupMessage("你进入");
        }
    }
}
