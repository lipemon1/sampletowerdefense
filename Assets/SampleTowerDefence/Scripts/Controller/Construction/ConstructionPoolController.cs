using System.Collections.Generic;
using System.Linq;
using SampleTowerDefence.Scripts.Behaviours.Construction;
using SampleTowerDefence.Scripts.Controller.Pool;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Controller.Construction
{
    public class ConstructionPoolController : ObjectPoolController<PrepareConstructionBehaviour>
    {        
        public PrepareConstructionBehaviour GetAvailableConstruction()
        {
            return GetAvailableObject();
        }
        
        public void ReturnConstructionToPool(PrepareConstructionBehaviour constructionBehaviour)
        {
            ReturnObjectToPool(constructionBehaviour);
        }
    }
}