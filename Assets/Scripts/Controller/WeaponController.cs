
namespace Platformer
{
    public class WeaponController : BaseController
    {
        private Weapon _weapon;

        public override void On(params BaseSceneObject[] weapon) {
            if (IsActive)
                return;
            if (weapon.Length > 0) _weapon = weapon[0] as Weapon;
            if (_weapon is null)
                return;
            base.On(_weapon);
            _weapon.IsVisible = true;
            UiInterface.WepaonUIText.SetActive(true);
            UiInterface.WepaonUIText.ShowData(_weapon.Ammo.Type.ToString());
        }
    }
}