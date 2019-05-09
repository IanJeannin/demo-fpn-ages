using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    #region SerializeFields
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClips;
    [Tooltip("The minimum time that must pass before a thunder sfx plays.")]
    [SerializeField]
    private float minTimeBeforeThunder = 40;
    [Tooltip("The maximum time that can pass before a thunder sfx plays.")]
    [SerializeField]
    private float maxTimeBeforeThunder = 120;
    #endregion

    private void Awake()
    {
        PlayThunder();
    }

    public void PlayThunder()
    {
        float timeToPlayThunder = Random.Range(minTimeBeforeThunder, maxTimeBeforeThunder);
        StartCoroutine(ThunderTimer(timeToPlayThunder));
    }

    /// <summary>
    /// Waits for the previously set random time until a thunder will strike, then set the audio source clip to a random clip from the array, and play it. Finally calls the original method in order to continue the cycle. 
    /// </summary>
    /// <param name="timeUntilThunderStrikes"></param>
    /// <returns></returns>
    private IEnumerator ThunderTimer(float timeUntilThunderStrikes)
    {
        yield return new WaitForSeconds(timeUntilThunderStrikes);
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
        PlayThunder();
    }
}
