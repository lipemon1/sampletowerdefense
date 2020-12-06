using SampleTowerDefence.Scripts.Model;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Scriptables
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "Tower Defense/New enemy data", order = 1)]
    public class EnemyScriptableObject : ScriptableObject
    {
        [SerializeField] private Model.Enemy enemyData;

        public Model.Enemy GetEnemyData()
        {
            return enemyData;
        }
    }
}
