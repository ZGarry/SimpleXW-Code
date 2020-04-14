using Native.Sdk.Cqp.Enum;
using System;

namespace zfjz.mft.v.Code.common
{
    /// <summary>
    /// 表情包中间架构
    /// </summary>
    static public class Face
    {
        //使用sdk所带枚举构造Faces架构
        static public CQFace[] Faces = Enum.GetValues(typeof(CQFace)) as CQFace[];
        static private Random random=new Random();
        static public string RandomFace()
        {
            return $"[CQ:face,id={random.Next(0, Faces.Length)}]";
        }
    }
}