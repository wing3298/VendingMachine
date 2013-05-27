using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Model {

    /// <summary>
    /// 硬貨クラス
    /// </summary>
    public class Coin : MoneyBase {

        public Coin(MoneyType type): base(type) { 
        }
    }
}
