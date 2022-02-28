using System;
using UnityEngine;

namespace Platformer
{
    public abstract class Ammo : BaseSceneObject
    {
        [SerializeField] private float _timeToReturnToPool = 10f;
        [SerializeField] private float _baseDamage = 0.1f;
        private float _lossOfDamageAtTime = 0.2f;
        protected float _currentDamage;
        public AmmoType Type = AmmoType.Bullet;
        protected override void Awake() {
            base.Awake();
            _currentDamage = _baseDamage;                   
        }

        public void AddForce(Vector3 dir) {
            if (!Rigidbody) {
                return;
            }
            
            Rigidbody.AddForce(dir);
        }

        private void LossDamage() {
            _currentDamage -= _lossOfDamageAtTime;
        }
        
        public string GetEnumMemberName()
            => Enum.GetName(typeof(AmmoType), Type).ToLower();
        
    }
}