using UnityEngine;

namespace TestProject
{
    internal sealed class TabletBuilder
    {
        private readonly GameObject _tabletPrefab;
        private readonly Transform[] _tabletsPositions;
        private TabletView _tabletView;

        internal TabletView TabletView => _tabletView;
        
        internal TabletBuilder(GameData gameData, UIInitializeHandler uiInitializeHandler)
        {
            _tabletPrefab = gameData.TaskData.TabletPrefab;
            _tabletsPositions = uiInitializeHandler.GameScreenView.TabletPositons;
        }

        internal GameObject BuildTablet(TabletDataStruct tabletDataStruct, int index)
        {
            var newTablet = Object.Instantiate(_tabletPrefab);
            _tabletView = newTablet.GetComponent<TabletView>();
            var tabletBackground = _tabletView.TabletBackground;
            var tabletImage = _tabletView.TabletImage;
            
            newTablet.name = tabletDataStruct.TabletName;
            tabletImage.name = tabletDataStruct.TabletName;
            
            newTablet.transform.SetParent(_tabletsPositions[index]);
            newTablet.transform.position = _tabletsPositions[index].position;
            
            newTablet.SetActive(false);
            
            tabletImage.sprite = tabletDataStruct.TabletSprite;
            tabletBackground.color = Random.ColorHSV();
            
            return newTablet;
        }
    }
}