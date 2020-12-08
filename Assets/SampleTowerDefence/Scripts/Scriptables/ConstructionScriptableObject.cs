using UnityEngine;

namespace SampleTowerDefence.Scripts.Scriptables
{
    [CreateAssetMenu(fileName = "Construction Data", menuName = "Tower Defense/New construction data", order = 1)]
    public class ConstructionScriptableObject : ScriptableObject
    {
        [SerializeField] private Model.Construction constructionData;

        public Model.Construction GetConstructionData()
        {
            return constructionData;
        }
    }
}
