using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Model {
    
    /// <summary>
    /// お金を管理するクラスだよ！
    /// すごいよ！
    /// Singleton dayo!
    /// </summary>
    public class MoneyManager {

        protected static MoneyManager _instance;

        /// <summary>
        /// お金一覧だよー
        /// </summary>
        Dictionary<MoneyType, List<MoneyBase>> _allMoneyList;

        /// <summary>
        /// Singleton dayo.
        /// </summary>
        private MoneyManager() {
            _allMoneyList = new Dictionary<MoneyType, List<MoneyBase>>();
        }

        /// <summary>
        /// Singleton dayo.
        /// </summary>
        /// <returns></returns>
        public static MoneyManager GetInstance() {
            if (_instance == null) {
                _instance = new MoneyManager();
            }
            return _instance;
        }

        /// <summary>
        /// Moneyを追加しますよ。
        /// </summary>
        /// <param name="money"></param>
        public void AddMoney(MoneyBase money) {
            // 定義されてないEnumの値だったら弾く。"(MoneyType)9999"とか出来ちゃうから。
            if (!Enum.IsDefined(typeof(MoneyType), money.MoneyType)) {
                throw new InvalidProgramException("Not Allowed MoneyType.");
            }

            IList<MoneyBase> list = GetMoneyPool(money.MoneyType);
            list.Add(money);
        }

        /// <summary>
        /// AllMoneyListの中から、追加したいお金種別のListをゲーット
        /// </summary>
        /// <param name="moneyType"></param>
        /// <returns></returns>
        private List<MoneyBase> GetMoneyPool(MoneyType moneyType) {
            List<MoneyBase> list = null;

            // 見つからなかったら作るよ。
            bool exist = _allMoneyList.Any(s => s.Key == moneyType);
            if (!exist) {
                _allMoneyList.Add(moneyType, new List<MoneyBase>());
            }

            list = _allMoneyList.Single(s => s.Key == moneyType).Value;
            return list;
        }

        /// <summary>
        /// とりあえずStringでお金の総数を返すよ。
        /// </summary>
        /// <returns></returns>
        public string OutputMoney() { 
            string output = "";

            foreach (IList<MoneyBase> list in _allMoneyList.Values) {
                if (list.Count > 0) {
                    string moneyType = list[0].MoneyType.ToString();

                    // "yen10000 x2, "
                    output += (moneyType + " x" + list.Count + ", ");
                }
            }

            return output;
        }

    }
}
