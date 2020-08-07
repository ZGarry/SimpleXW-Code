using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;

namespace zfjz.mft.v.Code.monster
{
    public class 废弃神殿 : Place
    {
        public 废弃神殿() : base(
            name0: "废弃神殿", des0: "西北部城区，隐蔽树林密道处，可进入一个半截入土的废弃圣殿。黑道上传闻，那里在进行一些足以推翻当局的大动作...",
            header0: "晴空号", mid0: "地下迷宫", solder0: "眼中钉"
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
