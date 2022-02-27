using System;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public sealed class WepaonUIText: MonoBehaviour
    {
        private Text _text;
        private void Awake() {
            _text = GetComponent<Text>();
        }

        public void ShowData(string info) {
            _text.text = $"{info}";
        }

        public void SetActive(bool value) {
            _text.gameObject.SetActive(value);
        }
    }
    
}