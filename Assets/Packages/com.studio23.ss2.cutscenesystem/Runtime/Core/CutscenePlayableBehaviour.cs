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

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if (Page != null)
            {
                float progress = (float)(playable.GetTime() / playable.GetDuration());
                CurrentAlpha = Mathf.Lerp(StartAlpha, EndAlpha, progress);
                var renderer = Page.GetComponent<CanvasGroup>();
                if (renderer != null)
                {
                    renderer.alpha = CurrentAlpha;
                }
            }
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
        public void ForceAlpha()
        {
            Page.GetComponent<CanvasGroup>().alpha = 1f;
        }

    }

}