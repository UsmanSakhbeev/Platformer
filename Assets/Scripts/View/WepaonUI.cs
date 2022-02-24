using System;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public sealed class WepaonUIText: MonoBehaviour
    {
        private Text _text;
        private void Awake() {
            _text = GetComponent<Text>();
        }

        public void ShowData(int ammoCount) {
            _text.text = $"{ammoCount}";
        }

        public void SetActive(bool value) {
            _text.gameObject.SetActive(value);
        }
    }
    
}