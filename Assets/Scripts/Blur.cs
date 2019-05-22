using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Blur : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume postProcessVolume;

    private float depthAperture;

    private void Start()
    {

    }

}
