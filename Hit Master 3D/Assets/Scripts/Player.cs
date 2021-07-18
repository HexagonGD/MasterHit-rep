using ES;
using HitMaster.Events;
using HitMaster.States;
using UnityEngine;

namespace HitMaster.Units
{
    public class Player : MonoBehaviour
    {
        private Animator _animator;
        private IState _state;

        public Animator Animator => _animator;

        private void Awake()
        {
            SetState(new AttackState(this));
            EventSystem.AddListener<ScreenTouchEvent>(this, OnScreenTouch);
        }

        public void OnScreenTouch(ScreenTouchEvent eventArg)
        {
            _state?.OnClick();
        }

        public void SetState(IState state)
        {
            _state?.End();
            _state = state;
            _state.Begin();
        }
    }
}