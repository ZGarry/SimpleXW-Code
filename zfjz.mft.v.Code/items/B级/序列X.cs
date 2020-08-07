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
    public class 序列X : Item
    {

        public 序列X() : base(
             name0: "序列X", priceLow0: 7, priceHigh0: 17,
            fuc: "做一次疯狂判定，取平方。70%失去对应修为，30%获得对应修为。若失去修为，重新获得此物品。", icon: "",
            des: "诱惑", level: "C")
        {
        }

        public override void EffectIn(Player p)
        {
            int tem = p.CrazyJude();
            int value = tem * tem;
            if (p.Jude(70))
            {
                p.XW -= value;
                p.Package.AddOne(name);
                p.SendMes($"{name}让你失去{value}点修为，你再次获得了{name}");
            }
            else
            {
                p.XW += value;
                p.SendMes($"莱比锡文写就的繁文缛节在你眼中一一展开。参悟成功！修为增加{value}点");
            }
        }
    }
}
