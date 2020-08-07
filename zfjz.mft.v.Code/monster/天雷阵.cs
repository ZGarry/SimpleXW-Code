using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.monster
{
    public class 天雷阵 : Monster
    {
        public 天雷阵() : base(
            name0: "天雷阵", XW0: 100, basic0: 10, Crazy0: 0, Lucky0: 0,
            fuc0: "交换双方修为，战后复原", lose0: "随机B级道具",
            icon0: "", level0: "队长")
        {
        }

        public override void Effect(player.Player p) {
            //获得你的修为
            this.XW = p._XW;
            //交给你我的修为
            p._XW = 100;
           // p.SendMes($"{name}获取了你的修为，同时你的修为被改为100点");
        }
        public override void EffectLose(player.Player p)
        {
            //还回去
            p._XW = this.XW;
            //p.SendMes($"战斗结束，你的修为复原了");
            this.XW =100;
        }
    }
}
