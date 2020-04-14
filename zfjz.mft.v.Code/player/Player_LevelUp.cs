using Native.Sdk.Cqp.Model;
using System;
using zfjz.mft.v.Code.common;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using Native.Sdk.Cqp.EventArgs;

namespace zfjz.mft.v.Code.player
{
    public partial class Player
    {

        public bool CheckLevelUp()
        {
            //判断是否进入下一级别
            var nextL = Common.Levels[LevelNum + 1];
            if (this.XW >= nextL.LowNum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Breakthrough()
        {
            var nextL = Common.Levels[LevelNum + 1];
            if (Common.Hit(nextL.Rate))
            {
                this.LevelNum += 1;
                return true;
            }
            else
            {
                XW += nextL.Punish;
                return false;
            }


        }


    }
}



