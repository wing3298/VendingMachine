using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VendingMachine.Model;

namespace VendingMachine {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        private MoneyType _insertMoneyType;

        /// <summary>
        /// 手の上に持っているお金。
        /// </summary>
        private MoneyBase _moneyInHand;


        public MainWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// お札投入口のクリックHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSlotInsertCoin_Click(object sender, RoutedEventArgs e) {
            if (Enum.IsDefined(typeof(MoneyType), _insertMoneyType)) {
                MoneyFactory factory = MoneyFactory.GetInstance();
                MoneyManager moneyManager = MoneyManager.GetInstance();

                MoneyBase money = factory.CreateMoney(_insertMoneyType);
                moneyManager.AddMoney(money);
            }
        }

        /// <summary>
        /// 硬貨投入口のクリックHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSlotInsertOsatsu_Click(object sender, RoutedEventArgs e) {
            if (Enum.IsDefined(typeof(MoneyType), _insertMoneyType)) {
                MoneyFactory factory = MoneyFactory.GetInstance();
                MoneyManager moneyManager = MoneyManager.GetInstance();

                MoneyBase money = factory.CreateMoney(_insertMoneyType);
                moneyManager.AddMoney(money);
            }
        }

        /// <summary>
        /// おつりレバーのクリックHandler.
        /// 
        /// クリックすると、投入したお金の分だけTextで出します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectRetunMoneyLever_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            MoneyManager moneyManager = MoneyManager.GetInstance();
            string insertedMoney = moneyManager.OutputMoney();

            ReturnMoneyOutputter.Text = insertedMoney;
        }


        private void btnYen10000_Click(object sender, RoutedEventArgs e) {
            _insertMoneyType = MoneyType.yen10000;

            // こうやって作った方がいいかな？責務がすごく微妙。
            MoneyFactory factory = MoneyFactory.GetInstance();
            _moneyInHand = factory.CreateMoney(MoneyType.yen10000);
        }

        private void btnYen5000_Click(object sender, RoutedEventArgs e) {
            _insertMoneyType = MoneyType.yen5000;
        }

        private void btnYen2000_Click(object sender, RoutedEventArgs e) {
            _insertMoneyType = MoneyType.yen2000;
        }

        private void btnYen1000_Click(object sender, RoutedEventArgs e) {
            _insertMoneyType = MoneyType.yen1000;
        }

        private void btnYen500_Click(object sender, RoutedEventArgs e) {
            _insertMoneyType = MoneyType.yen500;
        }

        private void btnYen100_Click(object sender, RoutedEventArgs e) {
            _insertMoneyType = MoneyType.yen100;
        }

        private void btnYen50_Click(object sender, RoutedEventArgs e) {
            _insertMoneyType = MoneyType.yen50;
        }

        private void btnYen10_Click(object sender, RoutedEventArgs e) {
            _insertMoneyType = MoneyType.yen10;
        }

        private void btnYen5_Click(object sender, RoutedEventArgs e) {
            _insertMoneyType = MoneyType.yen5;
        }

        private void btnYen1_Click(object sender, RoutedEventArgs e) {
            _insertMoneyType = MoneyType.yen1;
        }

        private void btnDoller100_Click(object sender, RoutedEventArgs e) {
            _insertMoneyType = MoneyType.doller100;
        }

        private void btnCent1_Click(object sender, RoutedEventArgs e) {
            _insertMoneyType = MoneyType.cent1;
        }



    }
}