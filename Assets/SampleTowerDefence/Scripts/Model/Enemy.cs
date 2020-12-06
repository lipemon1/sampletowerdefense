using UnityEngine;

namespace SampleTowerDefence.Scripts.Model
{
    [System.Serializable]
    public class Enemy
    {
        public int life;
        public float speed;
        public Material material;

        public Enemy(int life, float speed, Material material)
        {
            this.life = life;
            this.speed = speed;
            this.material = material;
        }

        public Enemy(Enemy enemy)
        {
            this.life = enemy.life;
            this.speed = enemy.speed;
            this.material = enemy.material;
        }
    }
}