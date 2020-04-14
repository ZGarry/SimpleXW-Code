using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zfjz.mft.v.Code.items;

namespace zfjz.mft.v.Code.monster
{
    public class Monster
    {
        //名称 
        public string name;
        //修为 体质 疯狂 幸运 
        public int XW;
        public int Basic;
        public int Crazy;
        public int Lucky;
        //战斗系数
        public double c = 1;
        //战斗效果描述 掉落描述
        public string fuc;
        public string lose;
        //图标
        public string icon;
        public string level;


        static private Random random = new Random();
        //普通判定
        public bool Jude(int rate)
        {
            return random.Next(100) - this.Lucky < rate;
        }
        //体质判定
        public int BasicJude()
        {
            return Basic / 2 + random.Next(Basic / 2) + 1;
        }
        //疯狂判定
        public int CrazyJude()
        {
            return random.Next(-Crazy, Crazy + 1);
        }
        //计算战力
        virtual public double GetATK()
        {
            var res = (XW + 233.3) * (BasicJude() + CrazyJude()) / 100;
            //避免负数以及过于小
            if (res < 100)
            {
                res = 100;
            }
            return res * c;
        }
        //战斗效果
        virtual public void Effect(player.Player p)
        {

        }
        //效果解除
        virtual public void EffectLose(player.Player p)
        {
        }

        //死亡掉落（基础C和基础B）
        virtual public void PlayWin(player.Player p)
        {
            string iname = "";
            if (level == "小兵")
            {
                iname = ItemList.RandomC();

            }
            else if (level == "队长")
            {
                iname = ItemList.RandomB();

            }
            p.SendMes($"你击杀了{name},获得一个{iname}");
            p.Package.AddOne(iname);

        }
        //失败惩罚
        virtual public void PlayLose(player.Player p)
        {
            if (level == "小兵")
            {
                p.SendMes($"挑战失败，你被{name}打的落花流水");
            }
            else if (level == "队长")
            {
                p.Crazy += 5;
                p.SendMes($"挑战失败，你被{name}打的落花流水，疯狂+5");
            }
            else
            {
                p.Crazy += 25;
                p.SendMes($"在绝对的力量面前，你实在过于弱小，疯狂+25");
            }

        }

        //和玩家战斗
        public void DefeatByPlayer(player.Player p)
        {
            if (p.StatusStr.Contain(name))
            {
                p.SendMes($"你已经击杀过一次{name}了");
                p.StatusInt.Set("上次挑衅时间", 0);
                return;
            }
            p.SendMes($"你正在挑衅{name}");

            Effect(p);
            if (p.GetAtk() > GetATK())
            {
                PlayWin(p);
            }
            else
            {
                PlayLose(p);
            }
            EffectLose(p);

        }

        //构造方法
        public Monster(string name0, int XW0, int basic0, int Crazy0, int Lucky0, string fuc0, string lose0, string icon0, string level0)
        {
            name = name0;
            XW = XW0;
            Basic = basic0;
            Crazy = Crazy0;
            Lucky = Lucky0;
            fuc = fuc0;
            lose = lose0;
            icon = icon0;
            level = level0;
        }

        public void LookByP(player.Player p)
        {
            p.SendMes($@"
{name} {level} 
修为:{XW}
三相: 体质{Basic} | 疯狂{Crazy} | 幸运{Lucky}
战斗效果: {fuc}
掉落: {lose}");
        }
    }
}
