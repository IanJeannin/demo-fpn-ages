using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger: MonoBehaviour
{
    [SerializeField]
    private PlayerCutscene cutscene;
    
    private void OnTriggerEnter(Collider other)
    {
        cutscene.TransitionToCutScene();
    }
}
