using UnityEngine;
using Zenject;

namespace UI.Factories
{
    public class KnifeHitMenuUIFactory
    {
        [Inject] 
        private GameObject _knifeHitUIPrefab;

        public void Create(Canvas parent, DiContainer container)
        {
            container.InstantiatePrefab(_knifeHitUIPrefab, parent.transform);
        }

    }
}