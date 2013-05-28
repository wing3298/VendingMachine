using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace VendingMachine.Model {

    /// <summary>
    /// 硬貨クラス
    /// </summary>
    public class Coin : MoneyBase {

        public Coin(MoneyType type): base(type) {

            //todo Reflectionを使って、MoneyFactory以外から呼び出されたときは、Exceptionにしようかな。
            //GitHub上から編集テスト(Reflectionはなるべく使わないほうが可読性あがると思うがどうだろう)
        }
    }
}
