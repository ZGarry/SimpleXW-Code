using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using zfjz.mft.v.Code.player;
using zfjz.mft.v.Code.common;
using Native.Sdk.Cqp.Enum;
using System;

namespace zfjz.mft.v.Code
{
    public class Event_IAppDisable : IAppDisable
    {
        public void AppDisable(object sender, CQAppDisableEventArgs e)
        {

            //e.CQLog.Info("[Ruby]", "应用关闭");
            Game.quit();
            

        }
    }
}
