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
    public class 月石 : Item
    {
        
        public 月石() : base(
             name0: "月石", priceLow0: 7, priceHigh0: 17,
            fuc: "月光越盛，月石效果越强！", icon: "",
            des: "一闪一闪亮晶晶", level: "C")
        {
        }

        public override void EffectIn(Player p)
        {
            if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 19) {
                p.Basic += 1;
                p.SendMes($"白天的{name}暗淡无光，体质+1");
                return;
            }
            string status = common.Monn.GetMoonStatus();
            if (status == "满月")
            {
                p.Basic += 4;
                if (p.StrictJude(10))
                {
                    p.Lucky += 1;
                    p.SendMes($"美丽的长眠~{name}在{status}下散发出闪烁的光泽！体质+4，幸运+1");
                }
                else
                {
                    p.Crazy -= 4;
                    p.SendMes($"{name}在{status}下散发出闪烁的光泽！体质+4,疯狂-4");
                }
            }
            else
            {
                p.Basic += 2;
                p.SendMes($"{name}在{status}之下散发出微弱光芒！体质+2");
            }
        }
    }
}
