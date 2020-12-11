using SampleTowerDefence.Scripts.Controller.Core;
using SampleTowerDefence.Scripts.Controller.Pool;
using SampleTowerDefence.Scripts.View.Enemy;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Enemy
{
    public class LifeBehaviour : MonoBehaviour
    {
        [SerializeField] private int life;
        [SerializeField] private int initialLife;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private bool isDead;

        public void PrepareBehaviour(int lifeAmount)
        {
            initialLife = lifeAmount;
        }

        public void ResetLife()
        {
            life = initialLife;
            healthBar.HealthChanged(life);
            isDead = false;
        }

        public void ApplyDamage(int damage, System.Action onEnemyKilled)
        {
            if (isDead) return;
            
            life -= damage;

            if (life <= 0)
                KillEnemy(onEnemyKilled);
            
            healthBar.HealthChanged(life);
        }

        private void KillEnemy(System.Action onEnemyKilled)
        {
            if(!isDead)
            onEnemyKilled?.Invoke();
            
            isDead = true;
        }
    }
}
