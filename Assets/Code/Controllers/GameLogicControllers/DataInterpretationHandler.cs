using System.Collections.Generic;
using UnityEngine.U2D;

namespace TestProject
{
    public sealed class DataInterpretationHandler
    {
        private readonly int _objectsQuantity;
        private TabletDataStruct[] _tabletsDataStructs;

        public TabletDataStruct[] TabletsDataStructs => _tabletsDataStructs;
        public DataInterpretationHandler(GameData gameData)
        {
            _objectsQuantity = gameData.TaskData.ObjectQuantity;
            
            var spritesLetters = gameData.TaskData.ObjectSprites;
            var letters = gameData.TaskData.ObjectNames;

            CreateTabletStructs(spritesLetters, letters);
        }

        private void CreateTabletStructs(SpriteAtlas objectSprites, List<string> objectNames)
        {
            if (_tabletsDataStructs != null) return;
            _tabletsDataStructs = new TabletDataStruct[_objectsQuantity];
            FillDataStructs(_tabletsDataStructs, objectNames, objectSprites);
        }

        private void FillDataStructs(TabletDataStruct[] tabletDataStruct, List<string> names, SpriteAtlas sprites)
        {
            foreach (var name in names)
            {
                tabletDataStruct[names.IndexOf(name)].TabletSprite = sprites.GetSprite(name);
                tabletDataStruct[names.IndexOf(name)].TabletName = name;
            }
        }
    }
}