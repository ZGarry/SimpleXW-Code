using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void LearnHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
            CQCode cqat = e.FromQQ.CQCode_At();
            var mes = e.Message.Text;
            //
            if (mes == "教学")
            {
                e.FromGroup.SendGroupMessage(cqat, " ", @"很高兴你打开了教学~
1.请尝试输入[签到]，来开始游戏
2.未来你可能会对一些游戏机制感到困惑，你可以随时回到这儿来查看
3.使用[教学#词条]来查看收录了哪些词条");
            }
            if (mes == "教学#词条")
            {
                e.FromGroup.SendGroupMessage(cqat, " ", @"1.[判定]");
            }
            //获取个人信息
            e.FromGroup.SendGroupMessage(cqat, " ", @"这是一个关于判定的教学
            1.游戏中有所有涉及随机数的地方，都需要判定
            2.例如[乞灵境]的渡劫概率就只有40%
            3.当你在判定的时候，会抛出一个百面骰，上面会随机展示一个数字
            4.例如抛出了42，这是一个比40大的数字，那么很可惜，你渡劫会失败
            5.但如果你幸运数值为4，那么42-4=38才是你的真实数字~，你的渡劫会成功");
        }
    }
}
