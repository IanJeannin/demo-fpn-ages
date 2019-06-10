using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Blur : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume postProcessVolume;
    /// <summary>
    /// How long before the blur at the very start of the game goes away. 
    /// </summary>
    [SerializeField]
    private float secondsBeforeBlurFades;
    //private DepthOfField depthOfField=new DepthOfField();
    private float depthAperture;
    private bool isBlurOn = true;
    
    private void Start()
    {
        //DepthOfField depthOfField = new DepthOfField();
        DepthOfField depthOfField = ScriptableObject.CreateInstance<DepthOfField>();
        StartCoroutine(BlurDisappear(depthOfField));
    }
    

    private IEnumerator BlurDisappear(DepthOfField x)
    {
        yield return new WaitForSeconds(secondsBeforeBlurFades);
        x.aperture.value = 32;
        //postProcessVolume.GetComponent<DepthOfField>().aperture.value = 32;
    }

}
