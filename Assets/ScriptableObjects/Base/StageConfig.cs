using System.Collections.Generic;
using Stump.RotationMechanics;
using UnityEngine;

namespace Stages
{
    [CreateAssetMenu(menuName = "Stages/StageConfig")]
    public class StageConfig : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _knivesToSpawn;
        [SerializeField] private Stage _stage;
        [SerializeField] private List<RotationType> _rotationTypes;
        [SerializeField] private List<Stump.Stump> _stumpPrefabs;

        public int KnivesToSpawn { get => _knivesToSpawn; }
        public Stage Stage { get => _stage; }
        public float Speed { get => _speed; }

        public RotationType RotationType
        {
            get
            {
                return _rotationTypes[Random.Range(0, _rotationTypes.Count)];
            }
        }

        public int Direction
        {
            get
            {
                if (UnityEngine.Random.Range(0, 2) == 0)
                    return -1;
                else
                    return 1;
            }
        }

        public Stump.Stump StumpPrefab
        {
            get 
            { 
                return _stumpPrefabs[Random.Range(0,_stumpPrefabs.Count)];
            }
        }
    }

    public enum Stage
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
        Seventh,
        Eighth,
        Ninth,
        Tenth,
        Eleventh,
        Twelfth
    }


}