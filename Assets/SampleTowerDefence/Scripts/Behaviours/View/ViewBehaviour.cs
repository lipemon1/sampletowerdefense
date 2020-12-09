using SampleTowerDefence.Scripts.Controller.View;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.View
{
    public class ViewBehaviour : MonoBehaviour
    {
        [Header("View Config")]
        [SerializeField] private ViewController.ViewType viewTypeType;
        [SerializeField] private GameObject viewObject;

        public virtual void OpenView()
        {
            viewObject.SetActive(true);
        }

        public virtual void OpenView(Vector3 posToOpen)
        {
            posToOpen.y += 2.5f;
            viewObject.transform.position = posToOpen;
            viewObject.SetActive(true);
        }

        public virtual void CloseView()
        {
            viewObject.SetActive(false);
        }

        public ViewController.ViewType GetViewType()
        {
            return viewTypeType;
        }
    }
}
