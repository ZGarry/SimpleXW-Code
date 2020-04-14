using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.monster
{
    //遗迹
    public class Place
    {
        public string name;
        public string des;
        public string header;
        public string mid;
        public string solder;     

        //入场释放
        virtual public void Enter(Native.Sdk.Cqp.EventArgs.CQGroupMessageEventArgs e)
        {

        }
        public void LookByPerson(player.Player p)
        {
            p.SendMes($@"遗迹 {name} 
...
{des}
...
首领: {header}
队长: {mid}
小兵: {solder}
--------------------
你可以使用'挑衅#怪物名'来攻击怪物");
        }

        public Place(string name0, string des0, string header0, string mid0, string solder0)
        {
            name = name0;
            des = des0;
            header = header0;
            mid = mid0;
            solder = solder0;
        }

    }
}
