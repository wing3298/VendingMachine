using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Model {

    /// <summary>
    /// お金の種類。
    /// </summary>
    /// <remarks>
    /// それぞれにクラス作ったほうが楽だけど、とりあえずお手軽だからこっちにしとく。
    /// </remarks>
    public enum MoneyType { 
        yen10000 = 10,
        yen5000 = 20,
        yen2000 = 30,
        yen1000 = 40,
        yen500 = 50,
        yen100 = 60,
        yen50 = 70,
        yen10 = 80,
        yen5 = 90,
        yen1 = 100,
        doller100 = 110,
        cent1 = 120,
    }

    /// <summary>
    /// お金の基底クラス。
    /// </summary>
    public class MoneyBase {

        private MoneyType _Value;

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>このクラスは直接インスタンス化させん。</remarks>
        /// <param name="value"></param>
        protected MoneyBase(MoneyType value) {
            _Value = value;
        }

        public MoneyType MoneyType {
            get {
                return _Value;
            }
        }

    }
}
