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
        yen10000 = 10000,
        yen5000 = 5000,
        yen2000 = 2000,
        yen1000 = 1000,
        yen500 = 500,
        yen100 = 100,
        yen50 = 50,
        yen10 = 10,
        yen5 = 5,
        yen1 = 1,
        doller100 = -100,
        cent1 = -1,
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
