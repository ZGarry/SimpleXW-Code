using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;

namespace zfjz.mft.v.Code.monster
{
    public class 北境雷山 : Place
    {
        public 北境雷山() : base(
            name0: "北境雷山", des0: "横亘在北方的巨大山脉，土地黝黑，寸草不生，天雷滚滚。上缚一龙，不见其首尾，终日嘶吼！",
            header0: "闪电雷龙", mid0: "天雷阵", solder0: "小雷龙"
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
