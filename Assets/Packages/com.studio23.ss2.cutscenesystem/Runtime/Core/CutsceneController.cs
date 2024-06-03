using System.Collections.Generic;
using System.Linq;
using Studio23.SS2.Cutscenesystem.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Timeline;


namespace Studio23.SS2.Cutscenesystem.Core
{
    public class CutsceneController : MonoBehaviour
    {
        public static CutsceneController instance;
        public PlayableDirector Director;
        private readonly float DampingValue = 0.1f;
        private bool _isPaused;

        private List<TimelineClip> ActivationClip;

        public UnityEvent OnPageAdvance;
        public UnityEvent OnPageSkip;

        private void Awake()
        {
            instance = this;
        }


        /// <summary>
        ///     Used to advance pages, skipcount parameter used to advance to the selected page column if want to skip to that page
        ///     column
        /// </summary>
        /// <param name="skipCount"></param>
        public void AdvancePage(int skipCount)
        {
            // Access the timeline asset from the director
            var timeline = Director.playableAsset as TimelineAsset;
            if (timeline == null) return;

            var currentTime = Director.time;
            var tracks = timeline.GetOutputTracks();
            var cutSceneTracks = tracks.OfType<CutsceneTrack>().ToList();
            var activeTracks = tracks.OfType<ActivationTrack>().ToList();

            foreach (var activeTrack in activeTracks)
            {
                if (activeTrack.start > currentTime || activeTrack.end < currentTime) continue;
                var shouldSkip = false;
                ActivationClip = activeTrack.GetClips().ToList();
                var Clip = skipCount == -1 ? ActivationClip.Count : skipCount;
                Director.time = activeTrack.end - DampingValue;
                Director.Evaluate();
                shouldSkip = true;
                OnPageAdvance?.Invoke();
               
                foreach (var track in cutSceneTracks)
                {
                    if (track.start > currentTime || track.end < currentTime) continue;
                    var clips = track.GetClips().ToList();
                    var currentClip = skipCount == -1 ? clips.Count : skipCount;

                    for (var i = 0; i < currentClip; i++)
                    {
                        var cut = clips[i].asset as CutsceneClip;
                        if (cut != null) cut.CutsceneBehaviour.ForceAlpha();
                    }
                }
            }
        }

        /// <summary>
        /// Skip to the whole timeline track
        /// </summary>
        public void SkipPage()
        {
            var timelineAsset = Director.playableAsset as TimelineAsset;
            if (timelineAsset != null)
            {
                var markers = timelineAsset.markerTrack.GetMarkers().ToArray();
                OnPageSkip?.Invoke();
                Director.time = timelineAsset.duration;
            }
        }
    }

}

