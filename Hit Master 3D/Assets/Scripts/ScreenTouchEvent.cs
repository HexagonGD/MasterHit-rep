using UnityEngine;

namespace HitMaster.Events
{
    public readonly struct ScreenTouchEvent
    {
        public readonly Vector3 position;

        public ScreenTouchEvent(Vector3 position)
        {
            this.position = position;
        }
    }
}