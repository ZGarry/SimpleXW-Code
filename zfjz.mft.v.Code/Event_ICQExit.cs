using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using System;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;

namespace zfjz.mft.v.Code
{
    public class Event_ICQExit : ICQExit
    {
        public void CQExit(object sender, CQExitEventArgs e)
        {
            //e.CQLog.Info("[Ruby]", "酷q关闭");
            //Save._Save();
        }
    }
}
