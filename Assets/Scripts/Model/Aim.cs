using System;
using UnityEngine;

namespace Platformer
{
    public class Aim : MonoBehaviour, ICollision
    {
        private bool _isDead = false;
        private float _timeToDestroy = 5f;
        public float Hp = 100;
        public event EventHandler OnPointChanged = delegate { };

        public void CollisionEnter(InfoCollision infoCollision) {
            if (_isDead) return;

            if (Hp>0) {
                Hp -= infoCollision.Damage;
            }

            if (Hp <=0) {
                Destroy(gameObject, _timeToDestroy);
            }
        }
    }
}