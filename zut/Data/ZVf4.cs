using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Data
{
  public class zvf4 : zvf
  {
    public zvf4(float first, float second, float third, float forth)
      : base(first, second, third, forth) { }
    public zvf4(zvf3 vec, float forth)
      : base(vec[0], vec[1], vec[2], forth) { }
    public zvf4(zvf2 vec, float third, float forth)
      : base(vec[0], vec[1], third, forth) { }

    public static explicit operator zvf3(zvf4 v)
    { return new zvf3(v[0], v[1], v[2]); }
    public static explicit operator zvf2(zvf4 v)
    { return new zvf2(v[0], v[1]); }

    public float x { get { return this[0]; } }
    public float y { get { return this[1]; } }
    public float z { get { return this[2]; } }
    public float w { get { return this[3]; } }

    public float r { get { return this[0]; } }
    public float g { get { return this[1]; } }
    public float b { get { return this[2]; } }
    public float a { get { return this[3]; } }

    public zvf2 xy { get { return new zvf2(x, y); } }
    public zvf2 xz { get { return new zvf2(x, z); } }
    public zvf2 xw { get { return new zvf2(x, w); } }
    public zvf2 yz { get { return new zvf2(y, z); } }
    public zvf2 yw { get { return new zvf2(y, w); } }
    public zvf2 zw { get { return new zvf2(z, w); } }
    public zvf2 yx { get { return new zvf2(y, x); } }
    public zvf2 zx { get { return new zvf2(z, x); } }
    public zvf2 wx { get { return new zvf2(w, x); } }
    public zvf2 zy { get { return new zvf2(z, y); } }
    public zvf2 wy { get { return new zvf2(w, y); } }
    public zvf2 wz { get { return new zvf2(w, z); } }
    public zvf2 xx { get { return new zvf2(x, x); } }
    public zvf2 yy { get { return new zvf2(y, y); } }
    public zvf2 zz { get { return new zvf2(z, z); } }
    public zvf2 ww { get { return new zvf2(w, w); } }

    public zvf2 rg { get { return new zvf2(x, y); } }
    public zvf2 rb { get { return new zvf2(x, z); } }
    public zvf2 ra { get { return new zvf2(x, w); } }
    public zvf2 gb { get { return new zvf2(y, z); } }
    public zvf2 ga { get { return new zvf2(y, w); } }
    public zvf2 ba { get { return new zvf2(z, w); } }
    public zvf2 gr { get { return new zvf2(y, x); } }
    public zvf2 br { get { return new zvf2(z, x); } }
    public zvf2 ar { get { return new zvf2(w, x); } }
    public zvf2 bg { get { return new zvf2(z, y); } }
    public zvf2 ag { get { return new zvf2(w, y); } }
    public zvf2 ab { get { return new zvf2(w, z); } }
    public zvf2 rr { get { return new zvf2(x, x); } }
    public zvf2 gg { get { return new zvf2(y, y); } }
    public zvf2 bb { get { return new zvf2(z, z); } }
    public zvf2 aa { get { return new zvf2(w, w); } }

    public zvf3 xxx { get { return new zvf3(x, x, x); } }
    public zvf3 xxy { get { return new zvf3(x, x, y); } }
    public zvf3 xxz { get { return new zvf3(x, x, z); } }
    public zvf3 xxw { get { return new zvf3(x, x, w); } }
    public zvf3 xyx { get { return new zvf3(x, y, x); } }
    public zvf3 xyy { get { return new zvf3(x, y, y); } }
    public zvf3 xyz { get { return new zvf3(x, y, z); } }
    public zvf3 xyw { get { return new zvf3(x, y, w); } }
    public zvf3 xzx { get { return new zvf3(x, z, x); } }
    public zvf3 xzy { get { return new zvf3(x, z, y); } }
    public zvf3 xzz { get { return new zvf3(x, z, z); } }
    public zvf3 xzw { get { return new zvf3(x, z, w); } }
    public zvf3 xwx { get { return new zvf3(x, w, x); } }
    public zvf3 xwy { get { return new zvf3(x, w, y); } }
    public zvf3 xwz { get { return new zvf3(x, w, z); } }
    public zvf3 xww { get { return new zvf3(x, w, w); } }
    public zvf3 yxx { get { return new zvf3(y, x, x); } }
    public zvf3 yxy { get { return new zvf3(y, x, y); } }
    public zvf3 yxz { get { return new zvf3(y, x, z); } }
    public zvf3 yxw { get { return new zvf3(y, x, w); } }
    public zvf3 yyx { get { return new zvf3(y, y, x); } }
    public zvf3 yyy { get { return new zvf3(y, y, y); } }
    public zvf3 yyz { get { return new zvf3(y, y, z); } }
    public zvf3 yyw { get { return new zvf3(y, y, w); } }
    public zvf3 yzx { get { return new zvf3(y, z, x); } }
    public zvf3 yzy { get { return new zvf3(y, z, y); } }
    public zvf3 yzz { get { return new zvf3(y, z, z); } }
    public zvf3 yzw { get { return new zvf3(y, z, w); } }
    public zvf3 ywx { get { return new zvf3(y, w, x); } }
    public zvf3 ywy { get { return new zvf3(y, w, y); } }
    public zvf3 ywz { get { return new zvf3(y, w, z); } }
    public zvf3 yww { get { return new zvf3(y, w, w); } }
    public zvf3 zxx { get { return new zvf3(z, x, x); } }
    public zvf3 zxy { get { return new zvf3(z, x, y); } }
    public zvf3 zxz { get { return new zvf3(z, x, z); } }
    public zvf3 zxw { get { return new zvf3(z, x, w); } }
    public zvf3 zyx { get { return new zvf3(z, y, x); } }
    public zvf3 zyy { get { return new zvf3(z, y, y); } }
    public zvf3 zyz { get { return new zvf3(z, y, z); } }
    public zvf3 zyw { get { return new zvf3(z, y, w); } }
    public zvf3 zzx { get { return new zvf3(z, z, x); } }
    public zvf3 zzy { get { return new zvf3(z, z, y); } }
    public zvf3 zzz { get { return new zvf3(z, z, z); } }
    public zvf3 zzw { get { return new zvf3(z, z, w); } }
    public zvf3 zwx { get { return new zvf3(z, w, x); } }
    public zvf3 zwy { get { return new zvf3(z, w, y); } }
    public zvf3 zwz { get { return new zvf3(z, w, z); } }
    public zvf3 zww { get { return new zvf3(z, w, w); } }
    public zvf3 wxx { get { return new zvf3(w, x, x); } }
    public zvf3 wxy { get { return new zvf3(w, x, y); } }
    public zvf3 wxz { get { return new zvf3(w, x, z); } }
    public zvf3 wxw { get { return new zvf3(w, x, w); } }
    public zvf3 wyx { get { return new zvf3(w, y, x); } }
    public zvf3 wyy { get { return new zvf3(w, y, y); } }
    public zvf3 wyz { get { return new zvf3(w, y, z); } }
    public zvf3 wyw { get { return new zvf3(w, y, w); } }
    public zvf3 wzx { get { return new zvf3(w, z, x); } }
    public zvf3 wzy { get { return new zvf3(w, z, y); } }
    public zvf3 wzz { get { return new zvf3(w, z, z); } }
    public zvf3 wzw { get { return new zvf3(w, z, w); } }
    public zvf3 wwx { get { return new zvf3(w, w, x); } }
    public zvf3 wwy { get { return new zvf3(w, w, y); } }
    public zvf3 wwz { get { return new zvf3(w, w, z); } }
    public zvf3 www { get { return new zvf3(w, w, w); } }

    public zvf3 rrr { get { return new zvf3(x, x, x); } }
    public zvf3 rrg { get { return new zvf3(x, x, y); } }
    public zvf3 rrb { get { return new zvf3(x, x, z); } }
    public zvf3 rra { get { return new zvf3(x, x, w); } }
    public zvf3 rgr { get { return new zvf3(x, y, x); } }
    public zvf3 rgg { get { return new zvf3(x, y, y); } }
    public zvf3 rgb { get { return new zvf3(x, y, z); } }
    public zvf3 rga { get { return new zvf3(x, y, w); } }
    public zvf3 rbr { get { return new zvf3(x, z, x); } }
    public zvf3 rbg { get { return new zvf3(x, z, y); } }
    public zvf3 rbb { get { return new zvf3(x, z, z); } }
    public zvf3 rba { get { return new zvf3(x, z, w); } }
    public zvf3 rar { get { return new zvf3(x, w, x); } }
    public zvf3 rag { get { return new zvf3(x, w, y); } }
    public zvf3 rab { get { return new zvf3(x, w, z); } }
    public zvf3 raa { get { return new zvf3(x, w, w); } }
    public zvf3 grr { get { return new zvf3(y, x, x); } }
    public zvf3 grg { get { return new zvf3(y, x, y); } }
    public zvf3 grb { get { return new zvf3(y, x, z); } }
    public zvf3 gra { get { return new zvf3(y, x, w); } }
    public zvf3 ggr { get { return new zvf3(y, y, x); } }
    public zvf3 ggg { get { return new zvf3(y, y, y); } }
    public zvf3 ggb { get { return new zvf3(y, y, z); } }
    public zvf3 gga { get { return new zvf3(y, y, w); } }
    public zvf3 gbr { get { return new zvf3(y, z, x); } }
    public zvf3 gbg { get { return new zvf3(y, z, y); } }
    public zvf3 gbb { get { return new zvf3(y, z, z); } }
    public zvf3 gba { get { return new zvf3(y, z, w); } }
    public zvf3 gar { get { return new zvf3(y, w, x); } }
    public zvf3 gag { get { return new zvf3(y, w, y); } }
    public zvf3 gab { get { return new zvf3(y, w, z); } }
    public zvf3 gaa { get { return new zvf3(y, w, w); } }
    public zvf3 brr { get { return new zvf3(z, x, x); } }
    public zvf3 brg { get { return new zvf3(z, x, y); } }
    public zvf3 brb { get { return new zvf3(z, x, z); } }
    public zvf3 bra { get { return new zvf3(z, x, w); } }
    public zvf3 bgr { get { return new zvf3(z, y, x); } }
    public zvf3 bgg { get { return new zvf3(z, y, y); } }
    public zvf3 bgb { get { return new zvf3(z, y, z); } }
    public zvf3 bga { get { return new zvf3(z, y, w); } }
    public zvf3 bbr { get { return new zvf3(z, z, x); } }
    public zvf3 bbg { get { return new zvf3(z, z, y); } }
    public zvf3 bbb { get { return new zvf3(z, z, z); } }
    public zvf3 bba { get { return new zvf3(z, z, w); } }
    public zvf3 bar { get { return new zvf3(z, w, x); } }
    public zvf3 bag { get { return new zvf3(z, w, y); } }
    public zvf3 bab { get { return new zvf3(z, w, z); } }
    public zvf3 baa { get { return new zvf3(z, w, w); } }
    public zvf3 arr { get { return new zvf3(w, x, x); } }
    public zvf3 arg { get { return new zvf3(w, x, y); } }
    public zvf3 arb { get { return new zvf3(w, x, z); } }
    public zvf3 ara { get { return new zvf3(w, x, w); } }
    public zvf3 agr { get { return new zvf3(w, y, x); } }
    public zvf3 agg { get { return new zvf3(w, y, y); } }
    public zvf3 agb { get { return new zvf3(w, y, z); } }
    public zvf3 aga { get { return new zvf3(w, y, w); } }
    public zvf3 abr { get { return new zvf3(w, z, x); } }
    public zvf3 abg { get { return new zvf3(w, z, y); } }
    public zvf3 abb { get { return new zvf3(w, z, z); } }
    public zvf3 aba { get { return new zvf3(w, z, w); } }
    public zvf3 aar { get { return new zvf3(w, w, x); } }
    public zvf3 aag { get { return new zvf3(w, w, y); } }
    public zvf3 aab { get { return new zvf3(w, w, z); } }
    public zvf3 aaa { get { return new zvf3(w, w, w); } }

    public zvf4 xxxx { get { return new zvf4(x, x, x, x); } }
    public zvf4 xxxy { get { return new zvf4(x, x, x, y); } }
    public zvf4 xxxz { get { return new zvf4(x, x, x, z); } }
    public zvf4 xxxw { get { return new zvf4(x, x, x, w); } }
    public zvf4 xxyx { get { return new zvf4(x, x, y, x); } }
    public zvf4 xxyy { get { return new zvf4(x, x, y, y); } }
    public zvf4 xxyz { get { return new zvf4(x, x, y, z); } }
    public zvf4 xxyw { get { return new zvf4(x, x, y, w); } }
    public zvf4 xxzx { get { return new zvf4(x, x, z, x); } }
    public zvf4 xxzy { get { return new zvf4(x, x, z, y); } }
    public zvf4 xxzz { get { return new zvf4(x, x, z, z); } }
    public zvf4 xxzw { get { return new zvf4(x, x, z, w); } }
    public zvf4 xxwx { get { return new zvf4(x, x, w, x); } }
    public zvf4 xxwy { get { return new zvf4(x, x, w, y); } }
    public zvf4 xxwz { get { return new zvf4(x, x, w, z); } }
    public zvf4 xxww { get { return new zvf4(x, x, w, w); } }
    public zvf4 xyxx { get { return new zvf4(x, y, x, x); } }
    public zvf4 xyxy { get { return new zvf4(x, y, x, y); } }
    public zvf4 xyxz { get { return new zvf4(x, y, x, z); } }
    public zvf4 xyxw { get { return new zvf4(x, y, x, w); } }
    public zvf4 xyyx { get { return new zvf4(x, y, y, x); } }
    public zvf4 xyyy { get { return new zvf4(x, y, y, y); } }
    public zvf4 xyyz { get { return new zvf4(x, y, y, z); } }
    public zvf4 xyyw { get { return new zvf4(x, y, y, w); } }
    public zvf4 xyzx { get { return new zvf4(x, y, z, x); } }
    public zvf4 xyzy { get { return new zvf4(x, y, z, y); } }
    public zvf4 xyzz { get { return new zvf4(x, y, z, z); } }
    public zvf4 xyzw { get { return new zvf4(x, y, z, w); } }
    public zvf4 xywx { get { return new zvf4(x, y, w, x); } }
    public zvf4 xywy { get { return new zvf4(x, y, w, y); } }
    public zvf4 xywz { get { return new zvf4(x, y, w, z); } }
    public zvf4 xyww { get { return new zvf4(x, y, w, w); } }
    public zvf4 xzxx { get { return new zvf4(x, z, x, x); } }
    public zvf4 xzxy { get { return new zvf4(x, z, x, y); } }
    public zvf4 xzxz { get { return new zvf4(x, z, x, z); } }
    public zvf4 xzxw { get { return new zvf4(x, z, x, w); } }
    public zvf4 xzyx { get { return new zvf4(x, z, y, x); } }
    public zvf4 xzyy { get { return new zvf4(x, z, y, y); } }
    public zvf4 xzyz { get { return new zvf4(x, z, y, z); } }
    public zvf4 xzyw { get { return new zvf4(x, z, y, w); } }
    public zvf4 xzzx { get { return new zvf4(x, z, z, x); } }
    public zvf4 xzzy { get { return new zvf4(x, z, z, y); } }
    public zvf4 xzzz { get { return new zvf4(x, z, z, z); } }
    public zvf4 xzzw { get { return new zvf4(x, z, z, w); } }
    public zvf4 xzwx { get { return new zvf4(x, z, w, x); } }
    public zvf4 xzwy { get { return new zvf4(x, z, w, y); } }
    public zvf4 xzwz { get { return new zvf4(x, z, w, z); } }
    public zvf4 xzww { get { return new zvf4(x, z, w, w); } }
    public zvf4 xwxx { get { return new zvf4(x, w, x, x); } }
    public zvf4 xwxy { get { return new zvf4(x, w, x, y); } }
    public zvf4 xwxz { get { return new zvf4(x, w, x, z); } }
    public zvf4 xwxw { get { return new zvf4(x, w, x, w); } }
    public zvf4 xwyx { get { return new zvf4(x, w, y, x); } }
    public zvf4 xwyy { get { return new zvf4(x, w, y, y); } }
    public zvf4 xwyz { get { return new zvf4(x, w, y, z); } }
    public zvf4 xwyw { get { return new zvf4(x, w, y, w); } }
    public zvf4 xwzx { get { return new zvf4(x, w, z, x); } }
    public zvf4 xwzy { get { return new zvf4(x, w, z, y); } }
    public zvf4 xwzz { get { return new zvf4(x, w, z, z); } }
    public zvf4 xwzw { get { return new zvf4(x, w, z, w); } }
    public zvf4 xwwx { get { return new zvf4(x, w, w, x); } }
    public zvf4 xwwy { get { return new zvf4(x, w, w, y); } }
    public zvf4 xwwz { get { return new zvf4(x, w, w, z); } }
    public zvf4 xwww { get { return new zvf4(x, w, w, w); } }
    public zvf4 yxxx { get { return new zvf4(y, x, x, x); } }
    public zvf4 yxxy { get { return new zvf4(y, x, x, y); } }
    public zvf4 yxxz { get { return new zvf4(y, x, x, z); } }
    public zvf4 yxxw { get { return new zvf4(y, x, x, w); } }
    public zvf4 yxyx { get { return new zvf4(y, x, y, x); } }
    public zvf4 yxyy { get { return new zvf4(y, x, y, y); } }
    public zvf4 yxyz { get { return new zvf4(y, x, y, z); } }
    public zvf4 yxyw { get { return new zvf4(y, x, y, w); } }
    public zvf4 yxzx { get { return new zvf4(y, x, z, x); } }
    public zvf4 yxzy { get { return new zvf4(y, x, z, y); } }
    public zvf4 yxzz { get { return new zvf4(y, x, z, z); } }
    public zvf4 yxzw { get { return new zvf4(y, x, z, w); } }
    public zvf4 yxwx { get { return new zvf4(y, x, w, x); } }
    public zvf4 yxwy { get { return new zvf4(y, x, w, y); } }
    public zvf4 yxwz { get { return new zvf4(y, x, w, z); } }
    public zvf4 yxww { get { return new zvf4(y, x, w, w); } }
    public zvf4 yyxx { get { return new zvf4(y, y, x, x); } }
    public zvf4 yyxy { get { return new zvf4(y, y, x, y); } }
    public zvf4 yyxz { get { return new zvf4(y, y, x, z); } }
    public zvf4 yyxw { get { return new zvf4(y, y, x, w); } }
    public zvf4 yyyx { get { return new zvf4(y, y, y, x); } }
    public zvf4 yyyy { get { return new zvf4(y, y, y, y); } }
    public zvf4 yyyz { get { return new zvf4(y, y, y, z); } }
    public zvf4 yyyw { get { return new zvf4(y, y, y, w); } }
    public zvf4 yyzx { get { return new zvf4(y, y, z, x); } }
    public zvf4 yyzy { get { return new zvf4(y, y, z, y); } }
    public zvf4 yyzz { get { return new zvf4(y, y, z, z); } }
    public zvf4 yyzw { get { return new zvf4(y, y, z, w); } }
    public zvf4 yywx { get { return new zvf4(y, y, w, x); } }
    public zvf4 yywy { get { return new zvf4(y, y, w, y); } }
    public zvf4 yywz { get { return new zvf4(y, y, w, z); } }
    public zvf4 yyww { get { return new zvf4(y, y, w, w); } }
    public zvf4 yzxx { get { return new zvf4(y, z, x, x); } }
    public zvf4 yzxy { get { return new zvf4(y, z, x, y); } }
    public zvf4 yzxz { get { return new zvf4(y, z, x, z); } }
    public zvf4 yzxw { get { return new zvf4(y, z, x, w); } }
    public zvf4 yzyx { get { return new zvf4(y, z, y, x); } }
    public zvf4 yzyy { get { return new zvf4(y, z, y, y); } }
    public zvf4 yzyz { get { return new zvf4(y, z, y, z); } }
    public zvf4 yzyw { get { return new zvf4(y, z, y, w); } }
    public zvf4 yzzx { get { return new zvf4(y, z, z, x); } }
    public zvf4 yzzy { get { return new zvf4(y, z, z, y); } }
    public zvf4 yzzz { get { return new zvf4(y, z, z, z); } }
    public zvf4 yzzw { get { return new zvf4(y, z, z, w); } }
    public zvf4 yzwx { get { return new zvf4(y, z, w, x); } }
    public zvf4 yzwy { get { return new zvf4(y, z, w, y); } }
    public zvf4 yzwz { get { return new zvf4(y, z, w, z); } }
    public zvf4 yzww { get { return new zvf4(y, z, w, w); } }
    public zvf4 ywxx { get { return new zvf4(y, w, x, x); } }
    public zvf4 ywxy { get { return new zvf4(y, w, x, y); } }
    public zvf4 ywxz { get { return new zvf4(y, w, x, z); } }
    public zvf4 ywxw { get { return new zvf4(y, w, x, w); } }
    public zvf4 ywyx { get { return new zvf4(y, w, y, x); } }
    public zvf4 ywyy { get { return new zvf4(y, w, y, y); } }
    public zvf4 ywyz { get { return new zvf4(y, w, y, z); } }
    public zvf4 ywyw { get { return new zvf4(y, w, y, w); } }
    public zvf4 ywzx { get { return new zvf4(y, w, z, x); } }
    public zvf4 ywzy { get { return new zvf4(y, w, z, y); } }
    public zvf4 ywzz { get { return new zvf4(y, w, z, z); } }
    public zvf4 ywzw { get { return new zvf4(y, w, z, w); } }
    public zvf4 ywwx { get { return new zvf4(y, w, w, x); } }
    public zvf4 ywwy { get { return new zvf4(y, w, w, y); } }
    public zvf4 ywwz { get { return new zvf4(y, w, w, z); } }
    public zvf4 ywww { get { return new zvf4(y, w, w, w); } }
    public zvf4 zxxx { get { return new zvf4(z, x, x, x); } }
    public zvf4 zxxy { get { return new zvf4(z, x, x, y); } }
    public zvf4 zxxz { get { return new zvf4(z, x, x, z); } }
    public zvf4 zxxw { get { return new zvf4(z, x, x, w); } }
    public zvf4 zxyx { get { return new zvf4(z, x, y, x); } }
    public zvf4 zxyy { get { return new zvf4(z, x, y, y); } }
    public zvf4 zxyz { get { return new zvf4(z, x, y, z); } }
    public zvf4 zxyw { get { return new zvf4(z, x, y, w); } }
    public zvf4 zxzx { get { return new zvf4(z, x, z, x); } }
    public zvf4 zxzy { get { return new zvf4(z, x, z, y); } }
    public zvf4 zxzz { get { return new zvf4(z, x, z, z); } }
    public zvf4 zxzw { get { return new zvf4(z, x, z, w); } }
    public zvf4 zxwx { get { return new zvf4(z, x, w, x); } }
    public zvf4 zxwy { get { return new zvf4(z, x, w, y); } }
    public zvf4 zxwz { get { return new zvf4(z, x, w, z); } }
    public zvf4 zxww { get { return new zvf4(z, x, w, w); } }
    public zvf4 zyxx { get { return new zvf4(z, y, x, x); } }
    public zvf4 zyxy { get { return new zvf4(z, y, x, y); } }
    public zvf4 zyxz { get { return new zvf4(z, y, x, z); } }
    public zvf4 zyxw { get { return new zvf4(z, y, x, w); } }
    public zvf4 zyyx { get { return new zvf4(z, y, y, x); } }
    public zvf4 zyyy { get { return new zvf4(z, y, y, y); } }
    public zvf4 zyyz { get { return new zvf4(z, y, y, z); } }
    public zvf4 zyyw { get { return new zvf4(z, y, y, w); } }
    public zvf4 zyzx { get { return new zvf4(z, y, z, x); } }
    public zvf4 zyzy { get { return new zvf4(z, y, z, y); } }
    public zvf4 zyzz { get { return new zvf4(z, y, z, z); } }
    public zvf4 zyzw { get { return new zvf4(z, y, z, w); } }
    public zvf4 zywx { get { return new zvf4(z, y, w, x); } }
    public zvf4 zywy { get { return new zvf4(z, y, w, y); } }
    public zvf4 zywz { get { return new zvf4(z, y, w, z); } }
    public zvf4 zyww { get { return new zvf4(z, y, w, w); } }
    public zvf4 zzxx { get { return new zvf4(z, z, x, x); } }
    public zvf4 zzxy { get { return new zvf4(z, z, x, y); } }
    public zvf4 zzxz { get { return new zvf4(z, z, x, z); } }
    public zvf4 zzxw { get { return new zvf4(z, z, x, w); } }
    public zvf4 zzyx { get { return new zvf4(z, z, y, x); } }
    public zvf4 zzyy { get { return new zvf4(z, z, y, y); } }
    public zvf4 zzyz { get { return new zvf4(z, z, y, z); } }
    public zvf4 zzyw { get { return new zvf4(z, z, y, w); } }
    public zvf4 zzzx { get { return new zvf4(z, z, z, x); } }
    public zvf4 zzzy { get { return new zvf4(z, z, z, y); } }
    public zvf4 zzzz { get { return new zvf4(z, z, z, z); } }
    public zvf4 zzzw { get { return new zvf4(z, z, z, w); } }
    public zvf4 zzwx { get { return new zvf4(z, z, w, x); } }
    public zvf4 zzwy { get { return new zvf4(z, z, w, y); } }
    public zvf4 zzwz { get { return new zvf4(z, z, w, z); } }
    public zvf4 zzww { get { return new zvf4(z, z, w, w); } }
    public zvf4 zwxx { get { return new zvf4(z, w, x, x); } }
    public zvf4 zwxy { get { return new zvf4(z, w, x, y); } }
    public zvf4 zwxz { get { return new zvf4(z, w, x, z); } }
    public zvf4 zwxw { get { return new zvf4(z, w, x, w); } }
    public zvf4 zwyx { get { return new zvf4(z, w, y, x); } }
    public zvf4 zwyy { get { return new zvf4(z, w, y, y); } }
    public zvf4 zwyz { get { return new zvf4(z, w, y, z); } }
    public zvf4 zwyw { get { return new zvf4(z, w, y, w); } }
    public zvf4 zwzx { get { return new zvf4(z, w, z, x); } }
    public zvf4 zwzy { get { return new zvf4(z, w, z, y); } }
    public zvf4 zwzz { get { return new zvf4(z, w, z, z); } }
    public zvf4 zwzw { get { return new zvf4(z, w, z, w); } }
    public zvf4 zwwx { get { return new zvf4(z, w, w, x); } }
    public zvf4 zwwy { get { return new zvf4(z, w, w, y); } }
    public zvf4 zwwz { get { return new zvf4(z, w, w, z); } }
    public zvf4 zwww { get { return new zvf4(z, w, w, w); } }
    public zvf4 wxxx { get { return new zvf4(w, x, x, x); } }
    public zvf4 wxxy { get { return new zvf4(w, x, x, y); } }
    public zvf4 wxxz { get { return new zvf4(w, x, x, z); } }
    public zvf4 wxxw { get { return new zvf4(w, x, x, w); } }
    public zvf4 wxyx { get { return new zvf4(w, x, y, x); } }
    public zvf4 wxyy { get { return new zvf4(w, x, y, y); } }
    public zvf4 wxyz { get { return new zvf4(w, x, y, z); } }
    public zvf4 wxyw { get { return new zvf4(w, x, y, w); } }
    public zvf4 wxzx { get { return new zvf4(w, x, z, x); } }
    public zvf4 wxzy { get { return new zvf4(w, x, z, y); } }
    public zvf4 wxzz { get { return new zvf4(w, x, z, z); } }
    public zvf4 wxzw { get { return new zvf4(w, x, z, w); } }
    public zvf4 wxwx { get { return new zvf4(w, x, w, x); } }
    public zvf4 wxwy { get { return new zvf4(w, x, w, y); } }
    public zvf4 wxwz { get { return new zvf4(w, x, w, z); } }
    public zvf4 wxww { get { return new zvf4(w, x, w, w); } }
    public zvf4 wyxx { get { return new zvf4(w, y, x, x); } }
    public zvf4 wyxy { get { return new zvf4(w, y, x, y); } }
    public zvf4 wyxz { get { return new zvf4(w, y, x, z); } }
    public zvf4 wyxw { get { return new zvf4(w, y, x, w); } }
    public zvf4 wyyx { get { return new zvf4(w, y, y, x); } }
    public zvf4 wyyy { get { return new zvf4(w, y, y, y); } }
    public zvf4 wyyz { get { return new zvf4(w, y, y, z); } }
    public zvf4 wyyw { get { return new zvf4(w, y, y, w); } }
    public zvf4 wyzx { get { return new zvf4(w, y, z, x); } }
    public zvf4 wyzy { get { return new zvf4(w, y, z, y); } }
    public zvf4 wyzz { get { return new zvf4(w, y, z, z); } }
    public zvf4 wyzw { get { return new zvf4(w, y, z, w); } }
    public zvf4 wywx { get { return new zvf4(w, y, w, x); } }
    public zvf4 wywy { get { return new zvf4(w, y, w, y); } }
    public zvf4 wywz { get { return new zvf4(w, y, w, z); } }
    public zvf4 wyww { get { return new zvf4(w, y, w, w); } }
    public zvf4 wzxx { get { return new zvf4(w, z, x, x); } }
    public zvf4 wzxy { get { return new zvf4(w, z, x, y); } }
    public zvf4 wzxz { get { return new zvf4(w, z, x, z); } }
    public zvf4 wzxw { get { return new zvf4(w, z, x, w); } }
    public zvf4 wzyx { get { return new zvf4(w, z, y, x); } }
    public zvf4 wzyy { get { return new zvf4(w, z, y, y); } }
    public zvf4 wzyz { get { return new zvf4(w, z, y, z); } }
    public zvf4 wzyw { get { return new zvf4(w, z, y, w); } }
    public zvf4 wzzx { get { return new zvf4(w, z, z, x); } }
    public zvf4 wzzy { get { return new zvf4(w, z, z, y); } }
    public zvf4 wzzz { get { return new zvf4(w, z, z, z); } }
    public zvf4 wzzw { get { return new zvf4(w, z, z, w); } }
    public zvf4 wzwx { get { return new zvf4(w, z, w, x); } }
    public zvf4 wzwy { get { return new zvf4(w, z, w, y); } }
    public zvf4 wzwz { get { return new zvf4(w, z, w, z); } }
    public zvf4 wzww { get { return new zvf4(w, z, w, w); } }
    public zvf4 wwxx { get { return new zvf4(w, w, x, x); } }
    public zvf4 wwxy { get { return new zvf4(w, w, x, y); } }
    public zvf4 wwxz { get { return new zvf4(w, w, x, z); } }
    public zvf4 wwxw { get { return new zvf4(w, w, x, w); } }
    public zvf4 wwyx { get { return new zvf4(w, w, y, x); } }
    public zvf4 wwyy { get { return new zvf4(w, w, y, y); } }
    public zvf4 wwyz { get { return new zvf4(w, w, y, z); } }
    public zvf4 wwyw { get { return new zvf4(w, w, y, w); } }
    public zvf4 wwzx { get { return new zvf4(w, w, z, x); } }
    public zvf4 wwzy { get { return new zvf4(w, w, z, y); } }
    public zvf4 wwzz { get { return new zvf4(w, w, z, z); } }
    public zvf4 wwzw { get { return new zvf4(w, w, z, w); } }
    public zvf4 wwwx { get { return new zvf4(w, w, w, x); } }
    public zvf4 wwwy { get { return new zvf4(w, w, w, y); } }
    public zvf4 wwwz { get { return new zvf4(w, w, w, z); } }
    public zvf4 wwww { get { return new zvf4(w, w, w, w); } }

    public zvf4 rrrr { get { return new zvf4(x, x, x, x); } }
    public zvf4 rrrg { get { return new zvf4(x, x, x, y); } }
    public zvf4 rrrb { get { return new zvf4(x, x, x, z); } }
    public zvf4 rrra { get { return new zvf4(x, x, x, w); } }
    public zvf4 rrgr { get { return new zvf4(x, x, y, x); } }
    public zvf4 rrgg { get { return new zvf4(x, x, y, y); } }
    public zvf4 rrgb { get { return new zvf4(x, x, y, z); } }
    public zvf4 rrga { get { return new zvf4(x, x, y, w); } }
    public zvf4 rrbr { get { return new zvf4(x, x, z, x); } }
    public zvf4 rrbg { get { return new zvf4(x, x, z, y); } }
    public zvf4 rrbb { get { return new zvf4(x, x, z, z); } }
    public zvf4 rrba { get { return new zvf4(x, x, z, w); } }
    public zvf4 rrar { get { return new zvf4(x, x, w, x); } }
    public zvf4 rrag { get { return new zvf4(x, x, w, y); } }
    public zvf4 rrab { get { return new zvf4(x, x, w, z); } }
    public zvf4 rraa { get { return new zvf4(x, x, w, w); } }
    public zvf4 rgrr { get { return new zvf4(x, y, x, x); } }
    public zvf4 rgrg { get { return new zvf4(x, y, x, y); } }
    public zvf4 rgrb { get { return new zvf4(x, y, x, z); } }
    public zvf4 rgra { get { return new zvf4(x, y, x, w); } }
    public zvf4 rggr { get { return new zvf4(x, y, y, x); } }
    public zvf4 rggg { get { return new zvf4(x, y, y, y); } }
    public zvf4 rggb { get { return new zvf4(x, y, y, z); } }
    public zvf4 rgga { get { return new zvf4(x, y, y, w); } }
    public zvf4 rgbr { get { return new zvf4(x, y, z, x); } }
    public zvf4 rgbg { get { return new zvf4(x, y, z, y); } }
    public zvf4 rgbb { get { return new zvf4(x, y, z, z); } }
    public zvf4 rgba { get { return new zvf4(x, y, z, w); } }
    public zvf4 rgar { get { return new zvf4(x, y, w, x); } }
    public zvf4 rgag { get { return new zvf4(x, y, w, y); } }
    public zvf4 rgab { get { return new zvf4(x, y, w, z); } }
    public zvf4 rgaa { get { return new zvf4(x, y, w, w); } }
    public zvf4 rbrr { get { return new zvf4(x, z, x, x); } }
    public zvf4 rbrg { get { return new zvf4(x, z, x, y); } }
    public zvf4 rbrb { get { return new zvf4(x, z, x, z); } }
    public zvf4 rbra { get { return new zvf4(x, z, x, w); } }
    public zvf4 rbgr { get { return new zvf4(x, z, y, x); } }
    public zvf4 rbgg { get { return new zvf4(x, z, y, y); } }
    public zvf4 rbgb { get { return new zvf4(x, z, y, z); } }
    public zvf4 rbga { get { return new zvf4(x, z, y, w); } }
    public zvf4 rbbr { get { return new zvf4(x, z, z, x); } }
    public zvf4 rbbg { get { return new zvf4(x, z, z, y); } }
    public zvf4 rbbb { get { return new zvf4(x, z, z, z); } }
    public zvf4 rbba { get { return new zvf4(x, z, z, w); } }
    public zvf4 rbar { get { return new zvf4(x, z, w, x); } }
    public zvf4 rbag { get { return new zvf4(x, z, w, y); } }
    public zvf4 rbab { get { return new zvf4(x, z, w, z); } }
    public zvf4 rbaa { get { return new zvf4(x, z, w, w); } }
    public zvf4 rarr { get { return new zvf4(x, w, x, x); } }
    public zvf4 rarg { get { return new zvf4(x, w, x, y); } }
    public zvf4 rarb { get { return new zvf4(x, w, x, z); } }
    public zvf4 rara { get { return new zvf4(x, w, x, w); } }
    public zvf4 ragr { get { return new zvf4(x, w, y, x); } }
    public zvf4 ragg { get { return new zvf4(x, w, y, y); } }
    public zvf4 ragb { get { return new zvf4(x, w, y, z); } }
    public zvf4 raga { get { return new zvf4(x, w, y, w); } }
    public zvf4 rabr { get { return new zvf4(x, w, z, x); } }
    public zvf4 rabg { get { return new zvf4(x, w, z, y); } }
    public zvf4 rabb { get { return new zvf4(x, w, z, z); } }
    public zvf4 raba { get { return new zvf4(x, w, z, w); } }
    public zvf4 raar { get { return new zvf4(x, w, w, x); } }
    public zvf4 raag { get { return new zvf4(x, w, w, y); } }
    public zvf4 raab { get { return new zvf4(x, w, w, z); } }
    public zvf4 raaa { get { return new zvf4(x, w, w, w); } }
    public zvf4 grrr { get { return new zvf4(y, x, x, x); } }
    public zvf4 grrg { get { return new zvf4(y, x, x, y); } }
    public zvf4 grrb { get { return new zvf4(y, x, x, z); } }
    public zvf4 grra { get { return new zvf4(y, x, x, w); } }
    public zvf4 grgr { get { return new zvf4(y, x, y, x); } }
    public zvf4 grgg { get { return new zvf4(y, x, y, y); } }
    public zvf4 grgb { get { return new zvf4(y, x, y, z); } }
    public zvf4 grga { get { return new zvf4(y, x, y, w); } }
    public zvf4 grbr { get { return new zvf4(y, x, z, x); } }
    public zvf4 grbg { get { return new zvf4(y, x, z, y); } }
    public zvf4 grbb { get { return new zvf4(y, x, z, z); } }
    public zvf4 grba { get { return new zvf4(y, x, z, w); } }
    public zvf4 grar { get { return new zvf4(y, x, w, x); } }
    public zvf4 grag { get { return new zvf4(y, x, w, y); } }
    public zvf4 grab { get { return new zvf4(y, x, w, z); } }
    public zvf4 graa { get { return new zvf4(y, x, w, w); } }
    public zvf4 ggrr { get { return new zvf4(y, y, x, x); } }
    public zvf4 ggrg { get { return new zvf4(y, y, x, y); } }
    public zvf4 ggrb { get { return new zvf4(y, y, x, z); } }
    public zvf4 ggra { get { return new zvf4(y, y, x, w); } }
    public zvf4 gggr { get { return new zvf4(y, y, y, x); } }
    public zvf4 gggg { get { return new zvf4(y, y, y, y); } }
    public zvf4 gggb { get { return new zvf4(y, y, y, z); } }
    public zvf4 ggga { get { return new zvf4(y, y, y, w); } }
    public zvf4 ggbr { get { return new zvf4(y, y, z, x); } }
    public zvf4 ggbg { get { return new zvf4(y, y, z, y); } }
    public zvf4 ggbb { get { return new zvf4(y, y, z, z); } }
    public zvf4 ggba { get { return new zvf4(y, y, z, w); } }
    public zvf4 ggar { get { return new zvf4(y, y, w, x); } }
    public zvf4 ggag { get { return new zvf4(y, y, w, y); } }
    public zvf4 ggab { get { return new zvf4(y, y, w, z); } }
    public zvf4 ggaa { get { return new zvf4(y, y, w, w); } }
    public zvf4 gbrr { get { return new zvf4(y, z, x, x); } }
    public zvf4 gbrg { get { return new zvf4(y, z, x, y); } }
    public zvf4 gbrb { get { return new zvf4(y, z, x, z); } }
    public zvf4 gbra { get { return new zvf4(y, z, x, w); } }
    public zvf4 gbgr { get { return new zvf4(y, z, y, x); } }
    public zvf4 gbgg { get { return new zvf4(y, z, y, y); } }
    public zvf4 gbgb { get { return new zvf4(y, z, y, z); } }
    public zvf4 gbga { get { return new zvf4(y, z, y, w); } }
    public zvf4 gbbr { get { return new zvf4(y, z, z, x); } }
    public zvf4 gbbg { get { return new zvf4(y, z, z, y); } }
    public zvf4 gbbb { get { return new zvf4(y, z, z, z); } }
    public zvf4 gbba { get { return new zvf4(y, z, z, w); } }
    public zvf4 gbar { get { return new zvf4(y, z, w, x); } }
    public zvf4 gbag { get { return new zvf4(y, z, w, y); } }
    public zvf4 gbab { get { return new zvf4(y, z, w, z); } }
    public zvf4 gbaa { get { return new zvf4(y, z, w, w); } }
    public zvf4 garr { get { return new zvf4(y, w, x, x); } }
    public zvf4 garg { get { return new zvf4(y, w, x, y); } }
    public zvf4 garb { get { return new zvf4(y, w, x, z); } }
    public zvf4 gara { get { return new zvf4(y, w, x, w); } }
    public zvf4 gagr { get { return new zvf4(y, w, y, x); } }
    public zvf4 gagg { get { return new zvf4(y, w, y, y); } }
    public zvf4 gagb { get { return new zvf4(y, w, y, z); } }
    public zvf4 gaga { get { return new zvf4(y, w, y, w); } }
    public zvf4 gabr { get { return new zvf4(y, w, z, x); } }
    public zvf4 gabg { get { return new zvf4(y, w, z, y); } }
    public zvf4 gabb { get { return new zvf4(y, w, z, z); } }
    public zvf4 gaba { get { return new zvf4(y, w, z, w); } }
    public zvf4 gaar { get { return new zvf4(y, w, w, x); } }
    public zvf4 gaag { get { return new zvf4(y, w, w, y); } }
    public zvf4 gaab { get { return new zvf4(y, w, w, z); } }
    public zvf4 gaaa { get { return new zvf4(y, w, w, w); } }
    public zvf4 brrr { get { return new zvf4(z, x, x, x); } }
    public zvf4 brrg { get { return new zvf4(z, x, x, y); } }
    public zvf4 brrb { get { return new zvf4(z, x, x, z); } }
    public zvf4 brra { get { return new zvf4(z, x, x, w); } }
    public zvf4 brgr { get { return new zvf4(z, x, y, x); } }
    public zvf4 brgg { get { return new zvf4(z, x, y, y); } }
    public zvf4 brgb { get { return new zvf4(z, x, y, z); } }
    public zvf4 brga { get { return new zvf4(z, x, y, w); } }
    public zvf4 brbr { get { return new zvf4(z, x, z, x); } }
    public zvf4 brbg { get { return new zvf4(z, x, z, y); } }
    public zvf4 brbb { get { return new zvf4(z, x, z, z); } }
    public zvf4 brba { get { return new zvf4(z, x, z, w); } }
    public zvf4 brar { get { return new zvf4(z, x, w, x); } }
    public zvf4 brag { get { return new zvf4(z, x, w, y); } }
    public zvf4 brab { get { return new zvf4(z, x, w, z); } }
    public zvf4 braa { get { return new zvf4(z, x, w, w); } }
    public zvf4 bgrr { get { return new zvf4(z, y, x, x); } }
    public zvf4 bgrg { get { return new zvf4(z, y, x, y); } }
    public zvf4 bgrb { get { return new zvf4(z, y, x, z); } }
    public zvf4 bgra { get { return new zvf4(z, y, x, w); } }
    public zvf4 bggr { get { return new zvf4(z, y, y, x); } }
    public zvf4 bggg { get { return new zvf4(z, y, y, y); } }
    public zvf4 bggb { get { return new zvf4(z, y, y, z); } }
    public zvf4 bgga { get { return new zvf4(z, y, y, w); } }
    public zvf4 bgbr { get { return new zvf4(z, y, z, x); } }
    public zvf4 bgbg { get { return new zvf4(z, y, z, y); } }
    public zvf4 bgbb { get { return new zvf4(z, y, z, z); } }
    public zvf4 bgba { get { return new zvf4(z, y, z, w); } }
    public zvf4 bgar { get { return new zvf4(z, y, w, x); } }
    public zvf4 bgag { get { return new zvf4(z, y, w, y); } }
    public zvf4 bgab { get { return new zvf4(z, y, w, z); } }
    public zvf4 bgaa { get { return new zvf4(z, y, w, w); } }
    public zvf4 bbrr { get { return new zvf4(z, z, x, x); } }
    public zvf4 bbrg { get { return new zvf4(z, z, x, y); } }
    public zvf4 bbrb { get { return new zvf4(z, z, x, z); } }
    public zvf4 bbra { get { return new zvf4(z, z, x, w); } }
    public zvf4 bbgr { get { return new zvf4(z, z, y, x); } }
    public zvf4 bbgg { get { return new zvf4(z, z, y, y); } }
    public zvf4 bbgb { get { return new zvf4(z, z, y, z); } }
    public zvf4 bbga { get { return new zvf4(z, z, y, w); } }
    public zvf4 bbbr { get { return new zvf4(z, z, z, x); } }
    public zvf4 bbbg { get { return new zvf4(z, z, z, y); } }
    public zvf4 bbbb { get { return new zvf4(z, z, z, z); } }
    public zvf4 bbba { get { return new zvf4(z, z, z, w); } }
    public zvf4 bbar { get { return new zvf4(z, z, w, x); } }
    public zvf4 bbag { get { return new zvf4(z, z, w, y); } }
    public zvf4 bbab { get { return new zvf4(z, z, w, z); } }
    public zvf4 bbaa { get { return new zvf4(z, z, w, w); } }
    public zvf4 barr { get { return new zvf4(z, w, x, x); } }
    public zvf4 barg { get { return new zvf4(z, w, x, y); } }
    public zvf4 barb { get { return new zvf4(z, w, x, z); } }
    public zvf4 bara { get { return new zvf4(z, w, x, w); } }
    public zvf4 bagr { get { return new zvf4(z, w, y, x); } }
    public zvf4 bagg { get { return new zvf4(z, w, y, y); } }
    public zvf4 bagb { get { return new zvf4(z, w, y, z); } }
    public zvf4 baga { get { return new zvf4(z, w, y, w); } }
    public zvf4 babr { get { return new zvf4(z, w, z, x); } }
    public zvf4 babg { get { return new zvf4(z, w, z, y); } }
    public zvf4 babb { get { return new zvf4(z, w, z, z); } }
    public zvf4 baba { get { return new zvf4(z, w, z, w); } }
    public zvf4 baar { get { return new zvf4(z, w, w, x); } }
    public zvf4 baag { get { return new zvf4(z, w, w, y); } }
    public zvf4 baab { get { return new zvf4(z, w, w, z); } }
    public zvf4 baaa { get { return new zvf4(z, w, w, w); } }
    public zvf4 arrr { get { return new zvf4(w, x, x, x); } }
    public zvf4 arrg { get { return new zvf4(w, x, x, y); } }
    public zvf4 arrb { get { return new zvf4(w, x, x, z); } }
    public zvf4 arra { get { return new zvf4(w, x, x, w); } }
    public zvf4 argr { get { return new zvf4(w, x, y, x); } }
    public zvf4 argg { get { return new zvf4(w, x, y, y); } }
    public zvf4 argb { get { return new zvf4(w, x, y, z); } }
    public zvf4 arga { get { return new zvf4(w, x, y, w); } }
    public zvf4 arbr { get { return new zvf4(w, x, z, x); } }
    public zvf4 arbg { get { return new zvf4(w, x, z, y); } }
    public zvf4 arbb { get { return new zvf4(w, x, z, z); } }
    public zvf4 arba { get { return new zvf4(w, x, z, w); } }
    public zvf4 arar { get { return new zvf4(w, x, w, x); } }
    public zvf4 arag { get { return new zvf4(w, x, w, y); } }
    public zvf4 arab { get { return new zvf4(w, x, w, z); } }
    public zvf4 araa { get { return new zvf4(w, x, w, w); } }
    public zvf4 agrr { get { return new zvf4(w, y, x, x); } }
    public zvf4 agrg { get { return new zvf4(w, y, x, y); } }
    public zvf4 agrb { get { return new zvf4(w, y, x, z); } }
    public zvf4 agra { get { return new zvf4(w, y, x, w); } }
    public zvf4 aggr { get { return new zvf4(w, y, y, x); } }
    public zvf4 aggg { get { return new zvf4(w, y, y, y); } }
    public zvf4 aggb { get { return new zvf4(w, y, y, z); } }
    public zvf4 agga { get { return new zvf4(w, y, y, w); } }
    public zvf4 agbr { get { return new zvf4(w, y, z, x); } }
    public zvf4 agbg { get { return new zvf4(w, y, z, y); } }
    public zvf4 agbb { get { return new zvf4(w, y, z, z); } }
    public zvf4 agba { get { return new zvf4(w, y, z, w); } }
    public zvf4 agar { get { return new zvf4(w, y, w, x); } }
    public zvf4 agag { get { return new zvf4(w, y, w, y); } }
    public zvf4 agab { get { return new zvf4(w, y, w, z); } }
    public zvf4 agaa { get { return new zvf4(w, y, w, w); } }
    public zvf4 abrr { get { return new zvf4(w, z, x, x); } }
    public zvf4 abrg { get { return new zvf4(w, z, x, y); } }
    public zvf4 abrb { get { return new zvf4(w, z, x, z); } }
    public zvf4 abra { get { return new zvf4(w, z, x, w); } }
    public zvf4 abgr { get { return new zvf4(w, z, y, x); } }
    public zvf4 abgg { get { return new zvf4(w, z, y, y); } }
    public zvf4 abgb { get { return new zvf4(w, z, y, z); } }
    public zvf4 abga { get { return new zvf4(w, z, y, w); } }
    public zvf4 abbr { get { return new zvf4(w, z, z, x); } }
    public zvf4 abbg { get { return new zvf4(w, z, z, y); } }
    public zvf4 abbb { get { return new zvf4(w, z, z, z); } }
    public zvf4 abba { get { return new zvf4(w, z, z, w); } }
    public zvf4 abar { get { return new zvf4(w, z, w, x); } }
    public zvf4 abag { get { return new zvf4(w, z, w, y); } }
    public zvf4 abab { get { return new zvf4(w, z, w, z); } }
    public zvf4 abaa { get { return new zvf4(w, z, w, w); } }
    public zvf4 aarr { get { return new zvf4(w, w, x, x); } }
    public zvf4 aarg { get { return new zvf4(w, w, x, y); } }
    public zvf4 aarb { get { return new zvf4(w, w, x, z); } }
    public zvf4 aara { get { return new zvf4(w, w, x, w); } }
    public zvf4 aagr { get { return new zvf4(w, w, y, x); } }
    public zvf4 aagg { get { return new zvf4(w, w, y, y); } }
    public zvf4 aagb { get { return new zvf4(w, w, y, z); } }
    public zvf4 aaga { get { return new zvf4(w, w, y, w); } }
    public zvf4 aabr { get { return new zvf4(w, w, z, x); } }
    public zvf4 aabg { get { return new zvf4(w, w, z, y); } }
    public zvf4 aabb { get { return new zvf4(w, w, z, z); } }
    public zvf4 aaba { get { return new zvf4(w, w, z, w); } }
    public zvf4 aaar { get { return new zvf4(w, w, w, x); } }
    public zvf4 aaag { get { return new zvf4(w, w, w, y); } }
    public zvf4 aaab { get { return new zvf4(w, w, w, z); } }
    public zvf4 aaaa { get { return new zvf4(w, w, w, w); } }
  }
}
