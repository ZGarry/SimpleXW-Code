using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Model;
using zfjz.mft.v.Code.common;
using zfjz.mft.v.Code.player;
using zfjz.mft.v.Code.items;

namespace zfjz.mft.v.Code.handle
{
    public partial class Handle
    {
        public static void YouselfHandle(CQGroupMessageEventArgs e)
        {
            //解析参数
            CQCode cqat = e.FromQQ.CQCode_At();
            var qq = e.FromQQ.Id;

            //获取个人信息
            if (!Game.Players.ContainsKey(qq))
            {
                FixStroy.WarnNoCreateUser(e);
                return;
            }
            var p = Game.Players[qq];
            p.SetEIn(e);

            if (e.Message.Text == "查看")
            {
                //展示信息
                string template = @$"{(p.StrictJude(10) ? p.Level.Slogan : "")}
境界: {p.Level.LevelName}
修为: {p.XW}
金币: {p.Gold}
三相: 体质{p.Basic} | 疯狂{p.Crazy} | 幸运{p.Lucky}
物品: {p.Package.Show()}";
                e.FromGroup.SendGroupMessage(cqat, " ", template);
                return;
            }

            if (e.Message.Text.Contains("查看#"))
            {
                //展示信息
                var name = e.Message.Text.Split('#')[1];

                //现在是否在怪物列表中
                if (monster.MonsterList.Monsters.ContainsKey(name))
                {
                    monster.MonsterList.Monsters[name].LookByP(p);
                    return;
                }
                //不在则认为是查看物品
                else
                {
                    ItemList.LookByPerson(p, name);
                }
            }

            return;
        }



    }
}

