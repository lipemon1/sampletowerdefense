using UnityEngine;

namespace SampleTowerDefence.Scripts.Scriptables
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "Enemies Creation/New enemy data", order = 1)]
    public class EnemyScriptableObject : ScriptableObject
    {
        [SerializeField] private Model.Enemy enemyData;

        public int GetEnemyLife()
        {
            return enemyData.life;
        }

        public float GetEnemySpeed()
        {
            return enemyData.speed;
        }
    }
}
