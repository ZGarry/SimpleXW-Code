using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using Native.Sdk.Cqp.Model;
using Native.Sdk.Cqp.Enum;
using System;
using zfjz.mft.v.Code.handle;
using zfjz.mft.v.Code.player;
using zfjz.mft.v.Code.common;

namespace zfjz.mft.v.Code
{
    public class Event_PrivateMessage : IPrivateMessage
    {

        public void PrivateMessage(object sender, CQPrivateMessageEventArgs e)
        {
            //如果游戏已经在运行
            if (cookies.ThatWords.Running)
            {
                return;
            }
            if (e.FromQQ.Id != cookies.ThatWords.qq)
            {
                return;
            }
            if (e.Message.Text.Length < 2 || e.Message.Text.Length > 4)
            {
                e.FromQQ.SendPrivateMessage($"词语{e.Message.Text}过长或过短");
                return;
            }
            cookies.ThatWords.word = e.Message.Text;
            e.FromQQ.SendPrivateMessage($"词语'{e.Message.Text}'设置成功,任何人（包括你自己说这个词语也会导致游戏结束）");
            cookies.ThatWords.Running = true;

            e.Handler = false;
        }
    }
}