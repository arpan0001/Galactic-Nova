using UnityEngine;

public class PlayAudioOnSpace : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        audioSource.clip = audioClip;

       
        audioSource.clip.LoadAudioData();
        
       
        audioSource.PlayOneShot(AudioClip.Create("SilentAudio", 1, 1, 44100, false));
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            audioSource.Play();
        }
    }
}
