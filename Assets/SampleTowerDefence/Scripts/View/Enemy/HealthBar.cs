using UnityEngine;
using UnityEngine.UI;

namespace SampleTowerDefence.Scripts.View.Enemy
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;

        [SerializeField] private Vector3 wantedRotation;
        
        private void LateUpdate()
        {
            transform.rotation = Quaternion.Euler(wantedRotation);    
        }

        public void HealthChanged(float newValue)
        {
            healthSlider.value = newValue;
        }
    }
}