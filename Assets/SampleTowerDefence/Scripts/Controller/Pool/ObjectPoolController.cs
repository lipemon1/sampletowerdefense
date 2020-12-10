using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Controller.Pool
{
    public class ObjectPoolController<T> : MonoBehaviour
    {
        [SerializeField] protected List<T> objectsAvailable = new List<T>();
        [SerializeField] private GameObject objectPrefab;

        protected T GetAvailableObject()
        {
            return objectsAvailable?.Count > 0 ? objectsAvailable.PopAt(0) : Instantiate(objectPrefab).GetComponent<T>();
        }

        protected void ReturnObjectToPool(T objectToReturn)
        {
            var go = objectToReturn as GameObject;
            if (go != null) go.SetActive(false);

            objectsAvailable.Add(objectToReturn);
        }
    }
}