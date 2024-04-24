using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

namespace Studio23.SS2.Cutscenesystem.Core
{
    public class CutsceneController : MonoBehaviour
    {
        public static CutsceneController Instance;
        public List<Image> Pages;
        public List<ActivationTrack> ActivationTracks;
        public PlayableDirector Director;
        public float DampingValue = 0.1f;

        private bool isPaused = false;

        void Awake()
        {
            Instance = this;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Assuming space bar is the skip key
            {
                Debug.Log("Skipped pressed");
                Skip();
            }
        }

        [ContextMenu("Skip")]
        private void Skip()
        {
            if (isPaused)
            {
                Director.Play();
                isPaused = false;
                Debug.Log("Timeline resumed");
            }
            else
            {
                // Access the timeline asset from the director
                TimelineAsset timeline = Director.playableAsset as TimelineAsset;
                if (timeline == null) return;

                double currentTime = Director.time;

                // Get all tracks from the timeline
                var tracks = timeline.GetOutputTracks();

                // Filter to find all Activation Tracks

                var activationTracks = tracks.OfType<ActivationTrack>().ToList();
                
               

                foreach (var track in activationTracks)
                {
                    bool shouldSkip = false;
                    foreach (var clip in track.GetClips())
                    {
                        if (clip.start <= currentTime && clip.end > currentTime)
                        {
                            // Set time to the end of the current track's duration
                            Debug.Log("Current Time: " + Director.time);
                            Director.time = track.end - DampingValue;
                            
                            Debug.Log("Current Time After Calculation: " + Director.time);
                            shouldSkip = true;
                            Debug.Log("Activation Track found: " + track.name);
                            break; // Break since we found the active clip
                        }
                    }
                    if (shouldSkip)
                    {
                        Director.Pause();
                        ForceUpdateAlpha(1);
                        Director.Evaluate();
                        isPaused = true;
                        Debug.Log($"Director time now {Director.time} and track duration {track.duration}");
                        break; // Break since we've handled the skip for the active track
                    }
                }
            }
        }


        public void ForceUpdateAlpha(float alpha)
        {
            foreach (var page in Pages)
            {
                page.GetComponent<CanvasGroup>().alpha = alpha;
            }
        }

        public void UpdateSpriteImageData(double alpha, int index)
        {
            var dd = Pages[index].GetComponent<CanvasGroup>();
            dd.alpha = (float)alpha;
        }

    }

}

