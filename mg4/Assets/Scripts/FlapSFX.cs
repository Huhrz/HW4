using UnityEngine;

public class FlapSFX : MonoBehaviour
{
    public static FlapSFX Instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip flapClip;

    private void Awake()
    {
        Instance = this;
    }

    public static void Play()
    {
        if (Instance == null || Instance.audioSource == null || Instance.flapClip == null) return;
        Instance.audioSource.PlayOneShot(Instance.flapClip);
    }
}