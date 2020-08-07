using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.items
{
    /// <summary>
    /// 商品名录表
    /// </summary>
    public class ItemList
    {
        //用于商店抽选
        static public Item ChooseOne()
        {
            var i = Common.D();
            if (i >= 1 && i <= 5)
            {
                return RandomOne(ItemsS);
            }
            else if (i >= 6 && i <= 15)
            {
                return RandomOne(ItemsA);
            }
            else if (i >= 15 && i < 40)
            {
                return RandomOne(ItemsB);
            }
            else
            {
                return RandomOne(ItemsC);
            }
        }

        public static void Lottery(player.Player p)
        {
            var price = 3 + p.StatusInt.Get("抽奖次数") / 10;

            if (p.StatusInt.Get("抽奖次数") > 9 && p.StatusInt.Get("抽奖次数") % 10 == 0)
            {
                p.SendMes($"这是你第{p.StatusInt.Get("抽奖次数")}次抽奖啦~下一次，我就会多收你一枚金币了~");
            }
            if (p.Gold < price)
            {
                p.SendMes($"你的金币数量不足{price}枚");
                return;
            }
            else
            {
                //抽奖次数+1
                p.StatusInt.AddOne("抽奖次数");
                p.Gold -= price;
            }

            Item item0;
            //累计值增加
            p.StatusInt.Add("累计值", 1);
            //大奖！
            if (p.StrictJude(p.StatusInt.Get("累计值")))
            {
                p.StatusInt.Lose("累计值", 10);
                var i = Common.D() - p.Lucky;
                if (i <= -10)
                {
                    item0 = RandomOne(ItemsS);
                }
                else if (i <= 5)
                {
                    item0 = RandomOne(ItemsA);
                }
                else
                {
                    item0 = RandomOne(ItemsB);
                }
            }
            //普通抽取
            else
            {
                item0 = RandomOne(ItemsC);
            }
            //告知
            p.Package.AddOne(item0.name);
            p.SendMes($"花费{price}枚金币,你抽中了一个{item0.Level}级{item0.name}");
        }


        public static void LookByPerson(player.Player p, string name)
        {
            //判断是否有
            if (!ALLItem.ContainsKey(name))
            {
                p.SendMes("查无此物");
                return;
            }
            //执行使用
            p.SendMes(ALLItem[name].Report());
        }

        // Static constructor
        static ItemList()
        {
            var li = new List<Dictionary<string, Item>>() { ItemsA, ItemsB, ItemsC, ItemsS, ItemsSP, Forbin };
            foreach (var i in li)
            {
                foreach (string key in i.Keys)
                {
                    if (!ALLItem.ContainsKey(key))
                        ALLItem.Add(key, i[key]);
                }
            }
        }

        //使用的时候（全体物品）
        public static void UseItemByPerson(player.Player p, string name)
        {
            //判断是否有
            if (!p.Package.Contain(name))
            {
                p.SendMes("你没有这个物品");
                return;
            }
            //判断是否可以使用
            if (!ALLItem.ContainsKey(name))
            {
                p.SendMes("此物品不可使用");
                return;
            }
            //执行使用
            ALLItem[name].UseBy(p);
        }


        //所有Item（应该把所有物品设置可用）
        public static Dictionary<string, Item> ALLItem = new Dictionary<string, Item>
        {

        };



        //其实这是名目表，而非库存
        //开始时统一加载库存
        public static Dictionary<string, Item> ItemsC = new Dictionary<string, Item>{
            { "回气丹",new 回气丹()},
            { "红药水",new 红药水()},
            { "复合药",new 复合药()},
            { "灵石",new 灵石()},
            { "闪回石",new 闪回石()},

            { "伤药",new 伤药()},
            { "增幅药剂",new 增幅药剂()},
            { "邪气石",new 邪气石()},
            { "序列I",new 序列I()},
            { "月石",new 月石()},

            { "小钱袋",new 小钱袋()},
            { "小树苗",new 小树苗()},
            { "润肺露",new 润肺露()},
    };
        public static Dictionary<string, Item> ItemsB = new Dictionary<string, Item>{
            { "灵芝",new 灵芝()},
            { "护身符",new 护身符()},
            { "九转丹",new 九转丹()},
            { "序列X",new 序列X()},
            { "小红花",new 小红花()},

            { "序列III",new 序列III()},
            { "序列IX",new 序列IX()},
            { "混乱药剂",new 混乱药剂()},
            { "窃贼指环",new 窃贼指环()},
            { "疾跑药水",new 疾跑药水()},


    };
        public static Dictionary<string, Item> ItemsA = new Dictionary<string, Item>{
             //A-级物品
             { "倍金配方",new 倍金配方()},
             { "圣水",new 圣水()},
             { "小猪钱罐",new 小猪钱罐()},
             { "神偷手套",new 神偷手套()},
              { "缩小药片",new 缩小药片()},
               { "天山雪莲",new 天山雪莲()},

    };
        public static Dictionary<string, Item> ItemsS = new Dictionary<string, Item>{
           ////S-级物品
             { "传家宝",new 传家宝()},
             { "收税卡",new 收税卡()},
             { "序列V",new 序列V()},
             { "一沓假钞",new 一沓假钞()},

    };
        public static Dictionary<string, Item> ItemsSP = new Dictionary<string, Item>{
            { "小金箔",new 小金箔() },
            { "许愿币",new 许愿币() },
            { "饮料币",new 饮料币()}

    };

        //药水
        public static Dictionary<string, Item> ItemsBill = new Dictionary<string, Item>{
            { "红药水",new 红药水()},
            { "复合药",new 复合药()},
            { "伤药",new 伤药()},
            { "增幅药剂",new 增幅药剂()},
            { "圣水",new 圣水()},

            { "润肺露",new 润肺露()},
            { "疾跑药水",new 疾跑药水()},
             { "缩小药片",new 缩小药片()},
    };

        //违禁品
        public static Dictionary<string, Item> Forbin = new Dictionary<string, Item>
        {
            {"玻璃碎刃",new 玻璃碎刃() },
            {"大力丸",new 大力丸() },
            {"放大药水",new 放大药水() },
            {"聚魔瓶",new 聚魔瓶() },
            {"灵火",new 灵火() },
            {"缩小药水",new 缩小药水() },
            {"忘忧草",new 忘忧草() },
        };

        public static Item RandomOne(Dictionary<string, Item> item_dic)
        {
            return item_dic.ToList()[Common.Random.Next(item_dic.Count)].Value;
        }

        public static string RandomC()
        {
            return RandomOne(ItemsC).name;
        }
        public static string RandomB()
        {
            return RandomOne(ItemsB).name;
        }
        public static string RandomA()
        {
            return RandomOne(ItemsA).name;
        }
        public static string RandomS()
        {
            return RandomOne(ItemsS).name;
        }
    }
}
