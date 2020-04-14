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
    public class 聚魔瓶 : Item
    {

        public 聚魔瓶() : base(
            name0: "聚魔瓶", priceLow0: 4, priceHigh0: 4,
            fuc: "未知", icon: "",
            des: "闪烁着诡异的光泽", level: "C")
        {

        }



        public override void EffectIn(Player p)
        {
            if (DateTime.Now.Hour != 0)
            {
                //清空瓶子
                p.StatusInt.Add("魔力指示物", 1);
                if (p.StatusInt.Get("魔力指示物") > 12)
                {
                    p.StatusInt.Lose("魔力指示物", 12);
                    p.SendMes("序列V已加入你的背包");
                    p.Package.AddOne("序列V");
                }
                p.SendMes($"随着瓶盖开启，{name}中的红色液体迅速挥发。时钟转向{p.StatusInt.Get("魔力指示物")}");

            }
            else
            {
                //召唤恶魔！
                p.StatusInt.Add("魔力指示物", 2);
                if (p.StatusInt.Get("魔力指示物") == 13)
                {
                    p.SendMes($"随着瓶盖开启，{name}中的红色液体迅速挥发。瓶身中缓缓出现一个...恶魔");

                    p.SendMes($"恶魔对你说，感谢你释放了我，请收下这33个邪气石吧，然后随风散去");

                    p.Package.Add("邪气石",33);

                    return;
                }
                p.SendMes($"随着瓶盖开启，{name}中的红色液体迅速挥发。时钟转向{p.StatusInt.Get("魔力指示物")}");
            }
        }
    }
}
