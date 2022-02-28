using System;
using UnityEngine;

namespace Platformer
{
    public sealed class Bullet : Ammo
    {
        private void OnCollisionEnter(Collision collision) {
            var setDamage = collision.gameObject.GetComponent<ICollision>();

            if (setDamage != null) {
                setDamage.CollisionEnter(new InfoCollision(_currentDamage, Type, Rigidbody.velocity));
            }
        }
    }
}