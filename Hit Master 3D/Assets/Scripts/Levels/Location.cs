using HitMaster.Units;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HitMaster.Paths
{
    [Serializable]
    public class Location
    {
        public event Action LocationComplete;

        public Vector3 position;

        [SerializeField] private List<Enemy> enemies = new List<Enemy>();
        private int _countDeadEnemies = 0;

        public int EnemiesCount => enemies.Count;

        public void Initialize()
        {
            for(var i = 0; i < enemies.Count; i++)
            {
                enemies[i].Dead += OnDeadEnemies;
            }
        }

        private void OnDeadEnemies()
        {
            _countDeadEnemies++;
            if(_countDeadEnemies == enemies.Count)
            {
                LocationComplete?.Invoke();
            }
        }
    }
}