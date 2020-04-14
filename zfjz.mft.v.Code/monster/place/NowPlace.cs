using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.monster
{
    //当前遗迹
    static class NowPlace
    {
        public static Place Now = new 北境雷山();

        public static void MonsterATKbyPerson(player.Player p, string monster_name)
        {
            //选出怪物
            if (monster_name == Now.solder)
            {
                MonsterList.Monsters[monster_name].DefeatByPlayer(p);
            }
            else if (monster_name == Now.mid)
            {
                MonsterList.Monsters[monster_name].DefeatByPlayer(p);
            }
            else if (monster_name == Now.header)
            {
                MonsterList.Monsters[monster_name].DefeatByPlayer(p);
            }
            else
            {
                p.SendMes("请挑衅遗迹中存在的怪物");
            }

        }

        static public Dictionary<string, Place> AllPlaces = new Dictionary<string, Place>
        {
            {      "北境雷山", new  北境雷山()},
            {      "海妖弧岛", new 海妖弧岛()},
        };

        //随机挑选一个作为本次遗迹内容
        static public void ChangeAnother()
        {
            var li = AllPlaces.Keys.ToList();
            var name = li[(new Random()).Next(li.Count)];
            //替换当前遗迹
            
            Now = AllPlaces[name];
        }
    }
}
