using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using System;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void dHandle(CQGroupMessageEventArgs e)
        {
            try
            {
                int num = int.Parse(e.Message.Text.Substring(1));
                if (num <= 0) {
                    e.FromGroup.SendGroupMessage("d后面只接受正整数，例如d100");
                    return;
                }
                //空格记得要加
                e.FromGroup.SendGroupMessage(e.FromQQ.CQCode_At(), $" result={1+Common.Random.Next(num)}");
            }
            catch
            {
                e.FromGroup.SendGroupMessage("请在d后面键入一个数字，例如d100");
            }





        }
    }
}
