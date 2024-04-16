using UnityEngine;

public class PlayAudioOnSpace : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component if not already present
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        // Assign the audio clip
        audioSource.clip = audioClip;

        // Preload the audio clip
        audioSource.clip.LoadAudioData();
        
        // Pre-warm the audio source
        audioSource.PlayOneShot(AudioClip.Create("SilentAudio", 1, 1, 44100, false));
    }

    void Update()
    {
        // Check for space key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play the audio clip
            audioSource.Play();
        }
    }
}
