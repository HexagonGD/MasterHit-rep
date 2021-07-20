using System.Collections.Generic;
using UnityEngine;

namespace HitMaster.Paths
{
    public class PathLevel : MonoBehaviour
    {
        [SerializeField] private List<Location> _locations;
        private int _indexLocation = 0;

        private void Awake()
        {
            _locations.ForEach(x => x.Initialize());
        }

        public Location GetNextLocation()
        {
            if(_indexLocation >= _locations.Count)
            {
                return null;
            }
            else
            {
                return _locations[_indexLocation++];
            }
        }

        private void OnDrawGizmos()
        {
            for(var i = 0; i < _locations.Count - 1; i++)
            {
                Gizmos.DrawLine(_locations[i].position, _locations[i + 1].position);
                Gizmos.DrawWireSphere(_locations[i + 1].position, 1);
            }
        }
    }
}