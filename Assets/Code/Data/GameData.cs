using System.IO;
using UnityEngine;

namespace TestProject
{
    [CreateAssetMenu(menuName = "Data/GameData", fileName = "GameData")]
    public sealed class GameData: ScriptableObject
    {
        private const string GameDataFolder = "Data/";
        private TaskData _taskData;
        private UIData _uiData;
        private TweenerData _tweenerData;

        [SerializeField] private string _taskDataPath;
        [SerializeField] private string _uiDataPath;
        [SerializeField] private string _tweenerDataPath;

        public TaskData TaskData
        {
            get 
            {
                if (_taskData == null) 
                    _taskData = LoadPath<TaskData>(GameDataFolder + _taskDataPath);
                return _taskData;
            }
        }

        public UIData UIData
        {
            get
            {
                if (_uiData == null) 
                    _uiData = LoadPath<UIData>(GameDataFolder + _uiDataPath);
                return _uiData;
            }
        }

        public TweenerData TweenerData
        {
            get
            {
                if (_tweenerData == null) 
                    _tweenerData = LoadPath<TweenerData>(GameDataFolder + _tweenerDataPath);
                return _tweenerData;
            }
        }


        private T LoadPath<T>(string path) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(path, null));
    }
}
