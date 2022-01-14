using UnityEngine;

namespace TestProject
{
    public struct TabletDataStruct
    {
        private string _tabletName;
        private Sprite _tabletSprite;

        public string TabletName
        {
            internal set => _tabletName = value;
            get => _tabletName;
        }
        public Sprite TabletSprite
        {
            internal set => _tabletSprite = value;
            get => _tabletSprite;
        }
    }
}