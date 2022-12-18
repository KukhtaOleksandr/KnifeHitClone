using UnityEngine;
using Zenject;

namespace UI.Factories
{
    public class StageScoreUIFactory
    {
        [Inject] 
        private GameObject _stageScoreUIPrefab;

        public void Create(Canvas parent, DiContainer container)
        {
            container.InstantiatePrefab(_stageScoreUIPrefab, parent.transform);
        }

    }
}