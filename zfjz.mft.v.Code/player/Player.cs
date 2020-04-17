using Native.Sdk.Cqp.Model;
using System;
using zfjz.mft.v.Code.common;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using Native.Sdk.Cqp.EventArgs;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace zfjz.mft.v.Code.player
{
    //用来监视数据改变,作出反应，同时输出文字
    public delegate void SomeHanppen(Player p, Object o);
    public partial class Player
    {
        //触发器
        public SomeHanppen OnSomeHanppen;
        //当前事件
        public string NowEvent;
        //当前行为
        public string NowSubEvent;
        //消息台
        public CQGroupMessageEventArgs e;
        //@解析字符
        public CQCode _At;
        //临时系数C-用于一些翻倍操作等-使用一次后记得复原
        public double c = 1.0;

        public void SetTNowEvent(string NowEvent0, object o)
        {
            NowEvent = NowEvent0;
            OnSomeHanppen?.Invoke(this, o);
        }
        public void SetTNowSubEvent(string NowSubEvent0, object o)
        {
            NowSubEvent = NowSubEvent0;
            OnSomeHanppen?.Invoke(this, o);
        }
        //基本面
        public long QQ;
        public int _XW;

        public int XW
        {
            get { return _XW; }
            set
            {
                //减少(传入减少值，正数)
                if (value < _XW)
                {
                    var sep = _XW - value;
                    SetTNowSubEvent(PlayerSubEvent.XWLose, sep);

                }
                //增加修为（传入增加值，正数）
                else
                {
                    var sep = value - _XW;
                    //此时还在创建中，自然没有p，自然没有其对应的package！amazing！看来所有数据的加载都是危险的，尽量减少依赖项目！
                    StatusInt.Set("修为增加数值", sep);
                    SetTNowSubEvent(PlayerSubEvent.XWAdd, sep);
                }
                _XW = value;
            }
        }
        private int _LevelNum = 0;
        public int LevelNum
        {
            get => _LevelNum;
            set
            {
                _LevelNum = value;
                Level = Common.Levels[_LevelNum];
            }
        }
        public Level Level;

        public int _Gold;
        public int Gold
        {
            get { return _Gold; }
            set
            {
                //如果失去钱了
                if (value < _Gold && StatusStr.Contain("小猪钱罐"))
                {
                    SendMes("你使用了金币,你失去了小猪钱罐");
                    StatusStr.Dic.Remove("小猪钱罐");
                }
                _Gold = value;
            }
        }

        //三相
        public int _Basic;
        public int Basic
        {
            get { return _Basic; }
            set
            {
                if (value < 20)
                {
                    var lose = (20 - value) * (20 - value) + Crazy;
                    XW -= lose;
                    Crazy += 5;
                    SendMes($"你太虚弱了!失去修为{lose}点,疯狂增加5点");
                }
                _Basic = value;
            }
        }

        public int _Crazy;
        public int Crazy
        {
            get { return _Crazy; }
            set
            {

                if (value >= 0)
                {
                    //并且继续增加的话
                    if (value >= 60 && value > _Crazy)
                    {
                        IAMCRAZY();
                    }
                    _Crazy = value;
                }
                //减少到0
                else
                {
                    _Crazy = 0;
                    SendMes($"你的疯狂已经减少到0，多余部分({-value}点)增加到了体质");
                    Basic += +(-value);
                }
            }
        }
        public int Lucky;

        //进阶
        public Package Package;
        public StatusInt StatusInt;
        public StatusStr StatusStr;
        public Equip Equip;

        public Player(long QQ0, int XW0, int LevelIndex0, int Gold0, int basic0, int crazy0, int lucky0, string Items0, string Status0InT, string Status0Str, string Equipment0)
        {
            QQ = QQ0;
            _XW = XW0;
            LevelNum = LevelIndex0;
            Level = Common.Levels[LevelNum];
            _Gold = Gold0;

            _Basic = basic0;
            Lucky = lucky0;
            _Crazy = crazy0;

            Package = new Package(Items0);
            StatusInt = new StatusInt(Status0InT);
            StatusStr = new StatusStr(Status0Str);
            Equip = new Equip(Equipment0);
        }

        public Player(long qq) : this(qq, 0, 0, 0, 50, 5, 0, "", "", "", "")
        {
        }

        public void SetEIn(CQGroupMessageEventArgs e0)
        {
            e = e0;
            _At = e.FromQQ.CQCode_At();
        }

        public void SendMes(string s)
        {
            e.FromGroup.SendGroupMessage(_At, " ", s);
        }


        //直接设置修为，避免迭代的问题
        public void Set_XW(int i)
        {
            _XW = i;

        }

        public void IAMCRAZY()
        {
            SendMes($"高度疯狂让你神志不清！现在的你随时可能会做傻事！");

            //开始干傻事吧！ 从定时（这样之后触发太多了），改为每次

            switch (random.Next(0, 6))
            {
                case (0):
                    SendMes("你发疯似的扔掉了自己的全部金币！");
                    Gold = 0;
                    break;
                case (1):
                    //如果为空，就不丢，自动出错
                    var li = Package.Dic.Keys.ToList();
                    if (li.Count == 0)
                    {
                        return;
                    }
                    var name = li[0];
                    Package.LoseOne(name);
                    SendMes($"我早就看你这个废物不耐烦了！说着你把背包里的{name}扔了出去。");
                    break;
                case (2):
                    XW -= 400;
                    SendMes($"你花了半天时间自残，终于让自己修为掉了400点。");
                    break;
                case (3):
                    _Basic -= 2;
                    _Crazy += 2;
                    Lucky -= 1;
                    SendMes($"你想要自毁双足！要不是同门师兄及时制止了你，现在你已经流血而死了。体质-2，疯狂+2，幸运-1");
                    break;
                case (4):
                    _Crazy += 9;
                    SendMes($"你盯着太阳光看了一整天！疯狂+9");
                    break;
                case (5):
                    _Basic -= 9;
                    SendMes($"你扯掉了自己所有头发，指甲，身上到处是血印！体质-9");
                    break;
            }
            //失去全部金币
            //失去随机一个物品
            //失去400点修为
            //体质-2，疯狂+2，幸运-1
            //疯狂+9
            //体质-9


        }
    }
}

