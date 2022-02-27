using UnityEngine;

namespace Platformer
{
    public sealed class UIInterface
    {
        private WepaonUIText _wepaonUIText;

        public WepaonUIText WepaonUIText {
            get {
                if (!_wepaonUIText)
                    _wepaonUIText = Object.FindObjectOfType<WepaonUIText>();
                return _wepaonUIText;
            }
        }
    }
}