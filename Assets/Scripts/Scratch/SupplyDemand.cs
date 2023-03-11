using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scratch {
    [System.Serializable]
    public class SupplyDemand :MonoBehaviour {
        public float basePrice;
        public float supply;
        public float demand;

        float _currentPrice;
        public float CurrentPrice { get => _currentPrice;}

        float _currentValue;
        public float CurrentValue { get => _currentValue;}

        private void Update() {
            UpdateCurrentPriceAndValue();
        }

        public void UpdateCurrentPriceAndValue(){
            _currentPrice = basePrice * demand / supply;
            _currentValue = demand * _currentPrice;
        }
    }


}
