using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource splatsound;
    
    public void PlaySplatSound()
    {
        splatsound.Play();
    }
}
