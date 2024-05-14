using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Playables;

namespace Studio23.SS2.Cutscenesystem.Core
{
    internal class CutscenePlayableBehaviour : PlayableBehaviour
    {
        public GameObject Page;
        public float StartAlpha;
        public float EndAlpha;
        internal float CurrentAlpha;

        private bool _firstFrameHappened;

        
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if (Page != null)
            {
                float progress = (float)(playable.GetTime() / playable.GetDuration());
                CurrentAlpha = Mathf.Lerp(StartAlpha, EndAlpha, progress);
                var renderer = Page.GetComponent<CanvasGroup>();
                renderer.alpha = CurrentAlpha;
                if (!_firstFrameHappened)
                {
                    renderer.alpha = StartAlpha;
                    _firstFrameHappened = true;
                }
            }
        }

        public override void OnPlayableDestroy(Playable playable)
        {
            _firstFrameHappened = false;
            if(Page != null) Page.GetComponent<CanvasGroup>().alpha = StartAlpha;
        }

        public void Initialize(GameObject targetPage, float startAlpha, float endAlpha)
        {
            Page = targetPage;
            StartAlpha = startAlpha;
            EndAlpha = endAlpha;
            Page.GetComponent<CanvasGroup>().alpha = startAlpha;
        }

        /// <summary>
        /// Make the remaining pages transparency to Maximum
        /// </summary>
        public void ForceAlpha(int value)
        {
            Page.GetComponent<CanvasGroup>().alpha = value;
        }

    }

}