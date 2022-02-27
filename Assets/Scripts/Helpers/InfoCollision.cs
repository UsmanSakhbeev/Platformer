using UnityEngine;

namespace Platformer
{
    public readonly struct InfoCollision
    {
        private readonly Vector3 _dir;
        private readonly float _damage;
        private readonly AmmoType _type;

        public InfoCollision( float damage, AmmoType type, Vector3 dir = default ) {
            _dir = dir;
            _damage = damage;
            _type = type;
        }
        
        public Vector3 Dir => _dir;
        
        public float Damage => _damage;
        
        public AmmoType Type => _type;
    }
}