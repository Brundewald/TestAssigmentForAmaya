using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace TestProject
{
    [CreateAssetMenu(menuName = "Data/TaskData", fileName = "TaskData")]
    public sealed class TaskData : ScriptableObject
    {
        [SerializeField] private int _easyLevelStackCount;
        [SerializeField] private int _mediumLevelStackCount;
        [SerializeField] private int _hardLevelStackCount;
        [SerializeField] private int _objectQuantity;
        [SerializeField] private SpriteAtlas _objectSprites;
        [SerializeField] private List<string> _objectsNames;
        [SerializeField] private GameObject _tabletPrefab;
        [SerializeField] private GameObject _particleSystem;

        public int EasyLevelStackCount => _easyLevelStackCount;
        public int MediumLevelStackCount => _mediumLevelStackCount;
        public int HardLevelStackCount => _hardLevelStackCount;
        public int ObjectQuantity => _objectQuantity;
        public SpriteAtlas ObjectSprites => _objectSprites;
        public List<string> ObjectNames => _objectsNames;
        public GameObject TabletPrefab => _tabletPrefab;
        public GameObject ParticleSystem => _particleSystem;
    }   
}
