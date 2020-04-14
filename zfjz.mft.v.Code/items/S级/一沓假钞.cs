using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.items
{
    public class 一沓假钞 : Item
    {

        public 一沓假钞() : base(
            name0: "一沓假钞", priceLow0: 999, priceHigh0:999,
            fuc: "疯狂+30。金币+999，30s后，失去全部金币！", icon: "",
            des: "为我们的苦难复仇！", level: "S")
        {
        }

        public override async void EffectIn(Player p)
        {
            p.SendMes($"立刻，马上，现在！你获得了999个金币，快，使用它们！你的金币将在30s后全部消失！");
            p.Gold += 999;

            //加回来，同时移除状态
            await Task.Run(() =>
            {
                Thread.Sleep(1000 * 30);
                p.Gold = 0;
                p.Crazy += 30;                
                p.SendMes($"警察闻风而来，你因制造假钞罪锒铛入狱。疯狂+30");               
            });
        }
    }
}
