using ES;
using HitMaster.Events;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            EventSystem.ExecuteEvent(new ScreenTouchEvent(Input.mousePosition));
        }
    }
}
