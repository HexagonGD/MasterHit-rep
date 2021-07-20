using HitMaster.Paths;
using HitMaster.Units;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HitMaster.States
{
    public class MoveState : IState
    {
        private PathLevel _path;
        private Player _player;
        private Location _nextLocation;

        public MoveState(Player player)
        {
            _player = player;
        }

        public void Begin()
        {
            _path = Object.FindObjectOfType<PathLevel>();
            _player.Animator.SetBool("IsAiming", false);
            _nextLocation = _path.GetNextLocation();
            _player.transform.LookAt(_nextLocation.position);
        }

        public void End()
        {
            return;
        }

        public void OnUpdate()
        {
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, _nextLocation.position, Time.deltaTime * 5f);
            if (Vector3.Distance(_player.transform.position, _nextLocation.position) < 1f)
            {
                if (_nextLocation.EnemiesCount > 0)
                {
                    _player.SetState(new AttackState(_player, _nextLocation));
                    return;
                }

                _nextLocation = _path.GetNextLocation();
                if (_nextLocation == null)
                {
                    SceneManager.LoadScene("Map");
                    return;
                }

                _player.transform.LookAt(_nextLocation.position);
            }
        }
    }
}