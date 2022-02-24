using Model;
using UnityEngine;

namespace Controller
{
    public abstract class BaseController : MonoBehaviour
    {
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