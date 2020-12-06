using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Enemy
{
    public class LifeBehaviour : MonoBehaviour
    {
        [SerializeField] private int life;
        [SerializeField] private int initialLife;

        public void PrepareBehaviour(int lifeAmount)
        {
            initialLife = lifeAmount;
        }

        public void ResetLife()
        {
            life = initialLife;
        }
    }
}
