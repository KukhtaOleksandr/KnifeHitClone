using UnityEngine;
using Zenject;

namespace UI.Factories
{
    public class PlayButtonUiFactory
    {
        [Inject] 
        private GameObject _playButtonPrefab;

        public void Create(Canvas parent, DiContainer container)
        {
            container.InstantiatePrefab(_playButtonPrefab, parent.transform);
        }
    }
}