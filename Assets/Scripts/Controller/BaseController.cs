using UnityEngine;

namespace Platformer
{
    public abstract class BaseController : MonoBehaviour
    {
        protected UIInterface UiInterface;

        public bool  IsActive { get; private set; }

        public virtual void On() {
            On(null);
        }

        public virtual void On(params BaseSceneObject[] objs) {
            IsActive = true;
        }

        public virtual void Off() {
            IsActive = false;
        }

        public void Switch(params BaseSceneObject[] objs) {
            if (!IsActive) {
                On(objs);
            }
            else {
                Off();
            }
        }
    }
}