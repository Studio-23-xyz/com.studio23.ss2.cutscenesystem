using System.Collections;
using System.Collections.Generic;
using Studio23.SS2.Cutscenesystem.Core;
using UnityEngine;

public class DummyController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Assuming space bar is the skip key
        {
            CutsceneController.instance.AdvancePage(-1);
        }
    }
}
