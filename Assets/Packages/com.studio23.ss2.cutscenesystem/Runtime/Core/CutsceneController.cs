using System.Linq;
using Studio23.SS2.Cutscenesystem.Data;
using UnityEngine;
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

        void Awake()
        {
            instance = this;
        }


        /// <summary>
        /// Used to advance pages, skipcount parameter used to advance to the selected page column if want to skip to that page column
        /// </summary>
        /// <param name="skipCount"></param>
        public void AdvancePage(int skipCount)
        {
            if (_isPaused)
            {
                Director.Play();
                _isPaused = false;
                Debug.Log("Timeline resumed");
            }
            else
            {
                // Access the timeline asset from the director
                var timeline = Director.playableAsset as TimelineAsset;
                if (timeline == null) return;

                var currentTime = Director.time;
                var tracks = timeline.GetOutputTracks();
                var cutSceneTracks = tracks.OfType<CutsceneTrack>().ToList();

                foreach (var track in cutSceneTracks)
                {
                    if(track.start > currentTime || track.end < currentTime) continue;

                    var shouldSkip = false;
                    var clips = track.GetClips().ToList();
                    int currentClip = skipCount == -1? clips.Count:skipCount;

                    Director.time = track.end - DampingValue;
                    Director.Evaluate();
                    shouldSkip = true;


                    for (int i = 0; i < currentClip; i++)
                    {
                        CutsceneClip cut = clips[i].asset as CutsceneClip;
                        cut.CutsceneBehaviour.ForceAlpha();
                    }

                    if (shouldSkip)
                    {
                        _isPaused = true;
                        Debug.Log($"Director time now {Director.time} and track duration {track.duration}");
                        break; // Break since we've handled the skip for the active track
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
                Director.time = timelineAsset.duration;
            }
        }
    }

}

