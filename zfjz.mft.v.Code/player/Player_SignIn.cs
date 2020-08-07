using Native.Sdk.Cqp.Model;
using System;
using zfjz.mft.v.Code.common;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using Native.Sdk.Cqp.EventArgs;
using zfjz.mft.v.Code.items;

namespace zfjz.mft.v.Code.player
{
    public partial class Player
    {
        private int GetTrainNum()
        {
            var result = this.Basic * (Jude(Lucky) ? 2 : 1) + CrazyJude() * CrazyJude() + XW * 0.01 - Crazy;
            return (int)result;
        }

        public void SignIn(CQGroupMessageEventArgs e)
        {
            //解析参数
            CQCode cqat = e.FromQQ.CQCode_At();

            string temple;

            //用疯狂做普通判定(大于44才判定)
            if (Crazy >= 44 && Jude(Crazy))
            {
                e.FromGroup.SendGroupMessage(cqat, " ", "疯狂太高，你无心修炼，明天再来吧（其他角色可以 '援助@你'帮你吸收疯狂）");
                return;
            }

            //小树苗判断
            if (this.StatusInt.Contain("树苗大小"))
            {
                StatusInt.AddOne("树苗大小");
                if (StatusInt.Get("树苗大小") >= 5)
                {
                    SendMes("你的小树苗成熟啦~摘获一个饮料币");
                    StatusInt.Dic.Remove("树苗大小");
                    Package.AddOne("饮料币");
                }
                else
                {
                    SendMes($"你的小树苗正在茁壮成长，离成熟还需要{5 - StatusInt.Get("树苗大小")}天");
                }
            }


            //额外判定一次小猪钱罐
            if (StatusStr.Contain("小猪钱罐") && Jude(50))
            {
                Gold += 1;
                SendMes("小猪钱罐让你获得一个额外的金币！");
            }

            var addGold = (StrictJude(Lucky) ? 2 : 1);
            if (LevelNum >= 8)
            {
                addGold += 1;
            }
            Gold += addGold;
            
            var addNum = GetTrainNum();
            XW += addNum;

            //levelNum  
            if (LevelNum >= 9)
            {
                Crazy -= 1;
            }
            string name = "";
            if (LevelNum >= 10)
            {

                if (Jude(50))
                {
                    name = ItemList.RandomB();
                }
                else
                {
                    name = ItemList.RandomC();
                }
                Package.AddOne(name);


            }
            var story = Story.GetTrainStory(addNum);

            //渡劫 这儿代码写的也太乱了，但是我觉得也米有动的必要
            if (!CheckLevelUp())
            {
                temple = @$"{story},修为{(addNum >= 0 ? "+" : "")}{addNum},金币+{addGold}{(LevelNum >= 9 ? ",疯狂-1" : "")}{(name != "" ? $",获得一个{name}" : "")}
当前修为: {XW}
当前境界: {Level.LevelName}";


                e.FromGroup.SendGroupMessage(cqat, " ", temple);
                return;
            }
            else
            {
                temple = @$"{story},修为{(addNum > 0 ? "+" : "")}{addNum},达到{XW}点,即将突破到下一境界！";
                e.FromGroup.SendGroupMessage(cqat, " ", temple);
                if (Breakthrough())
                {
                    temple = @$"渡劫成功,现在你是{Level.LevelName}强者了！";
                    e.FromGroup.SendGroupMessage(cqat, " ", temple);
                    return;
                }
                else
                {
                    temple = @$"渡劫失败,修为{Common.Levels[LevelNum + 1].Punish}点";
                    e.FromGroup.SendGroupMessage(cqat, " ", temple);
                    return;
                }
            }
        }

    }
}



