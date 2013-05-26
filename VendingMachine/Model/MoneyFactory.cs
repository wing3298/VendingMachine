using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Model {
    public class MoneyFactory {

        protected static MoneyFactory _instance;

        private MoneyFactory() { 
        }

        public static MoneyFactory GetInstance() {
            if (_instance == null) {
                _instance = new MoneyFactory();
            }
            return _instance;
        }

        public MoneyBase CreateMoney(MoneyType moneyType) {
            MoneyBase money;

            switch (moneyType) { 
                case MoneyType.yen10000:
                case MoneyType.yen5000:
                case MoneyType.yen2000:
                case MoneyType.yen1000:
                case MoneyType.doller100:
                    money = new Osatsu(moneyType);
                    break;
                case MoneyType.yen500:
                case MoneyType.yen100:
                case MoneyType.yen50:
                case MoneyType.yen10:
                case MoneyType.yen5:
                case MoneyType.yen1:
                case MoneyType.cent1:
                    money = new Coin(moneyType);
                    break;
                default:
                    throw new InvalidProgramException("Not Allowed MoneyType.");
            }

            return money;
        }

    }
}
