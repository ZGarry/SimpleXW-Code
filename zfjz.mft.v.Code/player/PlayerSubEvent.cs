using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.player
{
    //存储行为、需要的时候随时添加、面向物品需要需求开发
    static public class PlayerSubEvent
    {     
        //增减类
        public const string XWAdd = "修为增加";
        public const string XWLose = "修为减少";

        public const string LevelAdd = "等级增加";
        public const string LevelLose = "等级减少";

        public const string CrazyAdd = "疯狂增加";
        public const string CrazyLose = "疯狂减少";

        public const string BasicAdd = "体质增加";
        public const string BasciLose = "体质减少";

        public const string LuckyAdd = "幸运增加";
        public const string LuckyLose = "幸运减少";

        public const string ItemAdd = "物品增加";
        public const string ItemLose = "物品减少";

        public const string GoldAdd = "金币增加";
        public const string GoldLose = "金币减少";

        //战斗类
        public const string GetATK = "计算战力";
        public const string GetATKEnd = "计算战力结束";

    }
}
