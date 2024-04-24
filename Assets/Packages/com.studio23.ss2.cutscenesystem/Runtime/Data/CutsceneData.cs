using System.Collections;
using System.Collections.Generic;
using Studio23.SS2.Cutscenesystem.Core;
using UnityEngine;


namespace Studio23.SS2.Cutscenesystem.Data
{
    [CreateAssetMenu(fileName = "Cutscene", menuName = "Studio-23/Cutscene")]
    public class CutsceneData : ScriptableObject
    {
        public List<CutscenePanelData> Cutscene;

    }


}

