using System;
using UnityEngine;

namespace Platformer
{
    public abstract class Weapon : BaseSceneObject
    {
        [SerializeField] protected float _rechargeTime = 0.2f;
        [SerializeField] protected Transform _barrel;        
        [SerializeField] protected float _force = 999;

        protected bool _isReady;        
        protected ITimeRemaining _timeRemaining;

        public Ammo Ammo;


        private void Start() {
            _timeRemaining = new TimeRemaining(ReadyShoot, _rechargeTime);
        }

        protected void ReadyShoot()
        {
            _isReady = true;
        }
        
        public abstract void Fire();
    }
}