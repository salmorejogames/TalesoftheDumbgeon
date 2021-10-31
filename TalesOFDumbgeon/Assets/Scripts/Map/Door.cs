using System;
using UnityEngine;

namespace Map
{
    public class Door : MonoBehaviour
    {
        public enum Orientation
        {
            North,
            South,
            West,
            East
        }

        public Orientation orientation;

        private void Start()
        {
            Debug.Log(orientation.ToString());
        }

    }
}
