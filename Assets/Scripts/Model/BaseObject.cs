using System;
using UnityEngine;

namespace Platformer
{
    /// <summary>
    /// Базовая модель объекта находящегося на сцене
    /// </summary>
    public abstract class BaseSceneObject : MonoBehaviour
    {
        private int _layer;
        private Color _color;
        private bool _isVisible;
        
        [HideInInspector] public Rigidbody2D Rigidbody;
        [HideInInspector] public Transform Transform;

        protected virtual void Awake() {
            Rigidbody = GetComponent<Rigidbody2D>();
            Transform = GetComponent<Transform>();
        }

        #region Property

        /// <summary>
        /// Имя объекта
        /// 
        /// </summary>
        public string Name {
            get => gameObject.name;
            set => gameObject.name = value;
        }

        public int Layer {
            get => _layer;
            set {
                _layer = value;
                AskLayer(transform,value);
            }
        }

        public Color color {
            get => _color;
            set {
                _color = value;
                AskColor(transform, value);
            }
        }

        public bool IsVisible {
            get => _isVisible;
            set {
                _isVisible = value;
                RendererSetActive(transform);
                if (transform.childCount <= 0) {
                    return;
                }

                foreach (Transform t in transform) {
                    RendererSetActive(t);
                }
            }
        }

        #endregion

        #region private methods

        private void AskLayer(Transform obj, int lvl) {
            obj.gameObject.layer = lvl;
            if (obj.childCount <=0) {
                return;
            }

            foreach (Transform d in obj) {
                AskLayer(d,lvl);
            }
        }


        private void RendererSetActive(Transform renderer) {
            if (renderer.gameObject.TryGetComponent<Renderer>(out var component)) {
                component.enabled = _isVisible;
            }
        }

        private void AskColor(Transform obj, Color color) {
            foreach (var curMateral in obj.GetComponent<Renderer>().materials) {
                curMateral.color = _color;
            }

            if (obj.childCount <= 0) {
                return;
            }

            foreach (Transform d in obj) {
                AskColor(d, color);
            }
        }


        #endregion

        public void DisableRigidbody() {
            var rigidbodies = GetComponentsInChildren<Rigidbody2D>();
            foreach (var rb in rigidbodies) {
                rb.isKinematic = true;
            }
        }

        public void EnableRigidbody(float force) {
            EnableRigidbody();
            Rigidbody.AddForce(transform.forward * force);
        }

        public void EnableRigidbody() {
            var rigidbodies = GetComponentsInChildren<Rigidbody2D>();
            foreach (var rb in rigidbodies) {
                rb.isKinematic = false;
            }
        }

        /// <summary>
        /// Замораживает или размораживает физическую трансформацию объекта
        /// </summary>
        /// <param name="rigidbodyConstraints2D">Трансформацию которую нужно заморозить</param>
        public void ConstrainstsRigidbody(RigidbodyConstraints2D rigidbodyConstraints2D) {
            var rigidbodies = GetComponentsInChildren<Rigidbody2D>();
            foreach (var rb in rigidbodies) {
                rb.constraints = rigidbodyConstraints2D;
            }
        }

        public void SetActive(bool value) {
            IsVisible = value;
        }
        
    }
}