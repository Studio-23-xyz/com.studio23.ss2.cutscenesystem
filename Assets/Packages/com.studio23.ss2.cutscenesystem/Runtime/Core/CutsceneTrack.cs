using System.Collections;
using System.Collections.Generic;
using Studio23.SS2.Cutscenesystem.Data;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


namespace Studio23.SS2.Cutscenesystem.Core
{
    [TrackColor(0,0,1)]
    [TrackBindingType(typeof(CutsceneController))]
    [TrackClipType(typeof(CutsceneClip))]
    public class CutsceneTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
           
            return ScriptPlayable<CutsceneMixer>.Create(graph, inputCount);
        }
    }
}


