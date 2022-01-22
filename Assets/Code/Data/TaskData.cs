using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace TestProject
{
    [CreateAssetMenu(menuName = "Data/TaskData", fileName = "TaskData")]
    internal sealed class TaskData : ScriptableObject
    {
        [SerializeField] private int _easyLevelStackCount;
        [SerializeField] private int _mediumLevelStackCount;
        [SerializeField] private int _hardLevelStackCount;
        [SerializeField] private int _objectQuantity;
        [SerializeField] private SpriteAtlas _objectSprites;
        [SerializeField] private List<string> _objectsNames;
        [SerializeField] private GameObject _tabletPrefab;
        [SerializeField] private GameObject _particleSystem;

        internal int EasyLevelStackCount => _easyLevelStackCount;
        internal int MediumLevelStackCount => _mediumLevelStackCount;
        internal int HardLevelStackCount => _hardLevelStackCount;
        internal int ObjectQuantity => _objectQuantity;
        internal SpriteAtlas ObjectSprites => _objectSprites;
        internal List<string> ObjectNames => _objectsNames;
        public GameObject TabletPrefab => _tabletPrefab;
        internal GameObject ParticleSystem => _particleSystem;
    }   
}
