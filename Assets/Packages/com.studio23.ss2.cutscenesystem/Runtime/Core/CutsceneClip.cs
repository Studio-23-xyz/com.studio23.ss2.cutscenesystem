using System.Collections.Generic;
using Studio23.SS2.Cutscenesystem.Data;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Studio23.SS2.Cutscenesystem.Core
{
    [SerializeField]
    [TrackBindingType(typeof(CutscenePage))]
    public class CutsceneClip : PlayableAsset, ITimelineClipAsset
    {
        public int PageColumn;
        public override double duration => 1;
        public ClipCaps clipCaps => ClipCaps.None;
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<CutscenePlayableBehaviour>.Create(graph);
            var cutsceneBehaviour = playable.GetBehaviour();
            cutsceneBehaviour.Column = PageColumn;

            return playable;
        }

       
    }
}