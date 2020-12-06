using System.Collections.Generic;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Model
{
    [System.Serializable]
    public class Wave
    {
        public enum EnemyType
        {
            Normal,
            Strong
        }
        
        public List<EnemyType> enemies;
    }
}
