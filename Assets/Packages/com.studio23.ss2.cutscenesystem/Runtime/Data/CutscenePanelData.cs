using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Studio23.SS2.Cutscenesystem.Data
{
    [CreateAssetMenu(fileName = "ComicPage", menuName = "Studio-23/ComicPage")]
    public class CutscenePanelData : ScriptableObject
    {
        public Sprite ComicSprite;
        [Range(1, 3)] public int ColumnSpan = 1;
    }
}