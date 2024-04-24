using UnityEngine;
using UnityEngine.Playables;

namespace Studio23.SS2.Cutscenesystem.Core
{
    public class CutscenePlayableBehaviour : PlayableBehaviour
    {
        
        public int Column;

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            var cutSceneData = playerData as CutsceneController;
            if(cutSceneData == null)
                return;
            
            double duration = playable.GetDuration();
            double time = playable.GetTime();
            float progress = (float)(time / duration);
            float alpha = Mathf.Lerp(0, 1, progress);

            CutsceneController.Instance.UpdateSpriteImageData(alpha,Column);
        }
    }

}