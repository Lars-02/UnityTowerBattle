using UnityEngine;
using UnityEngine.UI;

public class MuteController : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnMouseDown()
    {
        GetComponent<Text>().text = audioSource.mute ? "Mute" : "Unmute";
        audioSource.mute = !audioSource.mute;
    }
}
