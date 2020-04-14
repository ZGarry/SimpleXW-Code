using Native.Sdk.Cqp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace zfjz.mft.v.Code.player
{
    partial class Player
    {
        public double GetAtk()
        {            
            var res = (XW + 233.3) * (BasicJude() + CrazyJude()) / 100;
            //避免负数以及过于小
            if (res < 100)
            {
                res = 100;
            }
            //乘以临时系数c
            return res*c;
        }

        public void Fight(Player p2)
        {
            //战斗开始
            SetTNowEvent(PlayerEvent.Fight, null);
            //计算战力开始
            SetTNowSubEvent(PlayerSubEvent.GetATK, null);
            var atk1 = GetAtk();
            if (StrictJude(Lucky) || StatusStr.Contain("玻璃碎刃"))
            {
                if (StatusStr.Contain("玻璃碎刃")) {
                    StatusStr.Dic.Remove("玻璃碎刃");
                }
                atk1 *= 2;
                SendMes("你超常发挥，战力翻倍！");
            }
            //计算战力结束
            SetTNowSubEvent(PlayerSubEvent.GetATKEnd, null);

            double atk2 = p2.GetAtk();

            double r = atk1 / atk2;
            if (r < 0.1)
            {
                int change = (int)(XW * 0.3);
                XW -= change;
                SendMes($"以卵击石，自折其羽！失去修为{change}点");            
                LoserJude();
            }
            else if (r < 0.6)
            {
                int change = (int)(BasicJude());
                XW -= change;
                p2.XW += change;
                Basic -= 2;
                Crazy += 1;
                SendMes($"自取其辱，无功而返！疯狂+1，体质-2，被夺取修为{change}点");
            }
            else if (r < 0.9)
            {
                if (this.Jude(20))
                {
                    Basic += 2;
                    SendMes($"君子报仇十年不晚，你暗暗发誓早晚取这厮性命！体质+2。");
                }
                else
                {
                    int change = (int)(BasicJude()/ 2);
                    XW -= change;
                    p2.XW += change;
                    SendMes($"略输一筹！被夺取修为{change}点");
                }
            }
            else if (r < 1.1)
            {
                int change = BasicJude() + p2.BasicJude();
                XW += change;
                p2.XW += change;
                SendMes($"你与对方大战三百回合，不分胜负！修为各加{change}点");
            }
            else if (r < 2)
            {
                if (this.Jude(20))
                {
                    Basic+=4;
                    SendMes($"你用小拳拳把对方打的鼻青脸肿，活动了身体！体质+4。");
                }
                else
                {
                    int change = (int)(BasicJude());
                    XW += change;
                    p2.XW -= change;
                    SendMes($"你巧妙的抓住对方破绽，把对方扇到了墙上！夺取修为{change}点");
                }
            }
            else if (r < 4)
            {

                int change = (int)((BasicJude() + BasicJude()));
                XW += change;
                p2.XW -= change;

                SendMes($"你一巴掌，打得对方亲妈都不认识了！夺取修为{change}点");
            }
            else if (r < 7)
            {

                int change = (int)(BasicJude() );
                XW += change;
                p2.XW -= change;
                SendMes($"你让了对方三十招，然而对方连你的护甲都未击破！啊，无敌是多么寂寞。夺取修为{change}点");
            }
            else
            {
                XW -= 200;
                SendMes($"恃强凌弱！非英雄也！失去修为{200}点");
            }
        }
    }
}
