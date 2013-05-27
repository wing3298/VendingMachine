using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Model {

    /// <summary>
    /// お札クラス。
    /// </summary>
    public class Osatsu : MoneyBase {

        public Osatsu(MoneyType type): base(type) { 
        }

    }
}
