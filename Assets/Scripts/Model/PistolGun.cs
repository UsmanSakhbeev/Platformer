using System;

namespace Platformer
{
    public class PistolGun : Weapon
    {
        public override void Fire() {
            if (!_isReady) return;
            var obj = CacheObjectRepo.Instance.SpawnCacheObject(Ammo.GetEnumMemberName(), _barrel.position, _barrel.rotation);
            _isReady = false;
            _timeRemaining.Add();
            obj.GetComponent<Ammo>().AddForce(_barrel.forward*_force);
        }
    }
}