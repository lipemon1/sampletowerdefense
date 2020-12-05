using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Enemy
{
    public class LifeBehaviour : MonoBehaviour
    {
        [SerializeField] private int life;

        public void PrepareBehaviour(int lifeAmount)
        {
            life = lifeAmount;
        }
    }
}
