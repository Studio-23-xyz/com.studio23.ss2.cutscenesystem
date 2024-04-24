using Studio23.SS2.Cutscenesystem.Core;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        base.ProcessFrame(playable, info, playerData);
        CutscenePlayableBehaviour targetPlayableBehavior = null;

        int numInputs = playable.GetInputCount();
        for (int i = 0; i < numInputs; i++)
        {
            var inputWeight = playable.GetInputWeight(i);
            if (inputWeight > 0)
            {
                var inputPlayable = (ScriptPlayable<CutscenePlayableBehaviour>)playable.GetInput(i);
                targetPlayableBehavior = inputPlayable.GetBehaviour();
            }
        }
        var director = playable.GetGraph().GetResolver() as PlayableDirector;
       
        if (Application.isPlaying)
        {
            UpdateCutsceneRuntime(targetPlayableBehavior, director);
        }
    }

    private void UpdateCutsceneRuntime(CutscenePlayableBehaviour targetPlayableBehavior, PlayableDirector director)
    {
        if (targetPlayableBehavior != null && director.time < director.duration) 
        {
           // targetPlayableBehavior.ShowNext();
        }
    }
}
