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
        /// お金を作ります。
        /// 最終的には、ここだけでお金を作るようにします。
        /// </summary>
        /// <param name="moneyType"></param>
        /// <returns></returns>
        public MoneyBase CreateMoney(MoneyType moneyType) {
            MoneyFactory factory = MoneyFactory.GetInstance();
            MoneyBase money = factory.CreateMoney(moneyType);
            return money;
        }

        /// <summary>
        /// Moneyを追加しますよ。
        /// </summary>
        /// <param name="money">お金</param>
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
        /// <param name="moneyType">お金種別</param>
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
        /// 投入したお金が幾らか計算する。
        /// ドルとセントは計算でき・・・ますけどマイナスなのでえらいことになります。
        /// </summary>
        /// <returns></returns>
        public string CountMoney() {
            int sumValue = 0;

            foreach (IList<MoneyBase> list in _allMoneyList.Values) {
                if (list.Count > 0) {
                    int value = (int)list[0].MoneyType;
                    value = value * list.Count;
                    sumValue += value;
                }
            }

            return sumValue.ToString();
        } 


        /// <summary>
        /// とりあえずStringでお金の総数を返すよ。
        /// 
        /// 投入金も、払い戻ししたので0円にする。
        /// </summary>
        /// <returns></returns>
        public string ReturnMoney() { 
            string output = "";

            foreach (IList<MoneyBase> list in _allMoneyList.Values) {
                if (list.Count > 0) {
                    string moneyType = list[0].MoneyType.ToString();

                    // "yen10000 x2, "
                    output += (moneyType + " x" + list.Count + ", ");
                }
            }


            // お金を吐き出したら、中身は空にする。
            _allMoneyList.Clear();

            return output;
        }


    }
}
