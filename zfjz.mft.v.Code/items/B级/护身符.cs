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
    public class 护身符 : Item
    {
        public 护身符() : base(
            name0: "护身符", priceLow0: 22, priceHigh0: 44,
            fuc: "24h之内！幸运+5！", icon: "",
            des: "全球限量·寺庙之光·内置写真·守计大师·开光版", level: "B")
        {

        }
        public override async void EffectIn(Player p)
        {
            //退货
            if (p.StatusStr.Get(name) == "使用中")
            {
                p.SendMes($"上一次{name}的效果还在使用中，本次无法使用{name}");
                p.Package.AddOne(name);
                return;
            }
            //正常使用
            p.StatusStr.Set(name, "使用中");

            //增加
            p.Lucky += 5;
            p.SendMes($"去寺庙里求姻缘的你，对守计大师感激涕零，手持着一张999的{name}哭着出来了。幸运临时+5，24小时后失效");

            await Task.Run(() =>
            {
                Thread.Sleep(1000*60*60*24);
                p.SendMes($"{name}时间过了！你复原啦！");
                p.Lucky -= 5;
                p.StatusStr.Dic.Remove(name);
            });
        }

       
    }
}
