using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Model {
    
    /// <summary>
    /// Singleton dayo.
    /// </summary>
    public class MoneyManager {

        protected static MoneyManager _instance;


        /// <summary>
        /// Singleton dayo.
        /// </summary>
        private MoneyManager() { 
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

    }
}
