using UnityEngine;

public class PlayAudioOnKeyPress : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Assign the audio clip to the AudioSource
        audioSource.clip = audioClip;
    }

    void Update()
    {
        // Check if the 'W' key is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Check if audio clip is assigned and it's not already playing
            if (audioClip != null && !isPlaying)
            {
                // Play the audio clip
                audioSource.Play();
                isPlaying = true;
            }
        }

        // Check if the 'W' key is released
        if (Input.GetKeyUp(KeyCode.W))
        {
            // Check if audio is playing
            if (isPlaying)
            {
                // Stop the audio clip
                audioSource.Stop();
                isPlaying = false;
            }
        }
    }
}
