using System;
using UnityEngine;

namespace Platformer
{
    public sealed class GameController : MonoBehaviour
    {
        private Controllers _controllers;

        private void Start() {
            _controllers = new Controllers();
            _controllers.Initialization();
        }

        private void Update() {
        }
    }
}