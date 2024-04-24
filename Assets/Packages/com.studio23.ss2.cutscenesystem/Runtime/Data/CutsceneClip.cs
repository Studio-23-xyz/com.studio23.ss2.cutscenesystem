using Studio23.SS2.Cutscenesystem.Core;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Studio23.SS2.Cutscenesystem.Data
{
    [SerializeField]
    internal class CutsceneClip : PlayableAsset, ITimelineClipAsset
    {
        public ExposedReference<GameObject> ComicPage;
        public float StartAlpha = 0f;
        public float EndAlpha = 1f;

        public CutscenePlayableBehaviour CutsceneBehaviour;
        public ClipCaps clipCaps => ClipCaps.None;


        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<CutscenePlayableBehaviour>.Create(graph);
            var behaviour = playable.GetBehaviour();

            // Set up the behaviour properties
            behaviour.Page = ComicPage.Resolve(graph.GetResolver());
            behaviour.StartAlpha = StartAlpha;
            behaviour.EndAlpha = EndAlpha;
            CutsceneBehaviour = behaviour;
            return playable;
        }
    }
}