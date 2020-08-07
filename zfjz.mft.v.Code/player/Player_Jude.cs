using Native.Sdk.Cqp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zfjz.mft.v.Code.player
{

    /// <summary>
    /// 每个判定最终都是要落到每个个人上来的，所有涉及体质疯狂等属性的判定，都带上
    /// </summary>
    public partial class Player
    {
        static private Random random = new Random();
        //普通判定
        public bool Jude(int rate)
        {
            return random.Next(100) - this.Lucky < rate;
        }
        //严格判定
        public bool StrictJude(int rate)
        {
            return random.Next(100) < rate;
        }

        //正态随机
        public double Normal()
        {
            double s = 0, u = 0, v = 0;
            while (s > 1 || s == 0)
            {
                u = random.NextDouble() * 2 - 1;
                v = random.NextDouble() * 2 - 1;

                s = u * u + v * v;
            }

            var z = Math.Sqrt(-2 * Math.Log(s) / s) * u;
            return (z);
        }

        //符合要求的正态分布随机数
        public double RandomNormal(double miu, double sigma)
        {
            var z = Normal() * sigma + miu;
            return (z);
        }

        //体质判定
        public int BasicJude()
        {           
            return (int)RandomNormal(Basic / 2.0, Basic / 6.0);
        }
        //疯狂判定
        public int CrazyJude()
        {
            return random.Next(-Crazy, Crazy + 1);
        }
        //挫败判定|需要输出
        public void LoserJude()
        {
            Crazy += 5;
            SendMes($"你深深的受到了挫败，疯狂+5");           
            if (StrictJude(Lucky))
            {
                SendMes($"面对挫折，你越挫愈勇，顿悟了修炼的本质，修为{(XW > 0 ? "+" : "")}{(int)(XW * 0.5)}");              
                XW = (int)(XW * 1.5);
            }
            else
            {
                var basicLose = (int)(Basic * 0.1 + 1);
                SendMes($"挫折让你心惊胆战,失去10%的体质,共计{basicLose}点");
                Basic -= basicLose;
            }
            return;
        }
        //美德判定
        public void VirtueJude()
        {
            var i = BasicJude()/10+5;
            SendMes($"美德在你心中洋溢，疯狂指数-{i}");
            Crazy -= i;
        }
        //完成不可能判定
        public void UnBelievableJude(Native.Sdk.Cqp.EventArgs.CQGroupMessageEventArgs e)
        {

            //解析参数
            CQCode cqat = e.FromQQ.CQCode_At();

            //
            e.FromGroup.SendGroupMessage(cqat, " ", $"你！完成了不可能的事件！这注定要载入史册！");
            e.FromGroup.SendGroupMessage(cqat, " ", $"现在！你的疯狂+30，为你进行两次疯狂判定！");
            var A = CrazyJude();
            var B = CrazyJude();
            var c = A * B;
            if (c < 0)
            {
                c = -c;
            }
            e.FromGroup.SendGroupMessage(cqat, " ", $"第一次结果是：{A}");
            e.FromGroup.SendGroupMessage(cqat, " ", $"第一次结果是：{B}");
            e.FromGroup.SendGroupMessage(cqat, " ", $"现在，你将获得两数之乘的修为加成，总计{c}点！！！");

            return;
        }
    }
}
