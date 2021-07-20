using HitMaster.States;
using UnityEngine;

namespace HitMaster.Units
{
    public class Player : MonoBehaviour
    {
        private IState _state;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _gun;
        [SerializeField] private Transform _model;

        public Animator Animator => _animator;
        public Vector3 GunPosition => _gun.position;
        public Transform Model => _model;

        private void Awake()
        {
            SetState(new MoveState(this));
        }

        private void Update()
        {
            _state.OnUpdate();
        }

        public void SetState(IState state)
        {
            _state?.End();
            _state = state;
            _state.Begin();
        }
    }
}