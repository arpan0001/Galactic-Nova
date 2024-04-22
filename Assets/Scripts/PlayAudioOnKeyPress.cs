using UnityEngine;

public class PlayAudioOnKeyPress : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = audioClip;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            if (audioClip != null && !isPlaying)
            {
               
                audioSource.Play();
                isPlaying = true;
            }
        }

        
        if (Input.GetKeyUp(KeyCode.W))
        {
            
            if (isPlaying)
            {
                
                audioSource.Stop();
                isPlaying = false;
            }
        }
    }
}
