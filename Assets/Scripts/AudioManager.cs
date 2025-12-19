using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource alertSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        alertSound = GetComponent<AudioSource>();
    }

    public void PlayAlertSound()
    {
        if (alertSound.isPlaying == false)
            alertSound.Play();
    }

    public void StopAlertSound()
    {
        if (alertSound.isPlaying == true)
            alertSound.Stop();
    }
}
