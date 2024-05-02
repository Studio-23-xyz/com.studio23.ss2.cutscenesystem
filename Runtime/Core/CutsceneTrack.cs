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
            var mixerPlayable = ScriptPlayable<CutscenePlayableBehaviour>.Create(graph, inputCount);
            CutscenePlayableBehaviour behaviour = mixerPlayable.GetBehaviour();

            // Initialize with the bound GameObject, assuming it has a CanvasGroup
            GameObject trackBinding = go.GetComponent<PlayableDirector>().GetGenericBinding(this) as GameObject;
            if (trackBinding != null)
            {
                behaviour.Initialize(trackBinding, 0f, 1f);  // Set default alpha values or manage dynamically
            }

            return mixerPlayable;
        }
    }
}


