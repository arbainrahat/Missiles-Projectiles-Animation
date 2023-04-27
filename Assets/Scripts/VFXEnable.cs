using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXEnable : MonoBehaviour
{
    [SerializeField] private GameObject particleAffect;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Missile"))
        {
            particleAffect.SetActive(true);
            audioSource.PlayOneShot(audioClip);
            Invoke("DisableVFX", 4.5f);
        }
    }

    void DisableVFX()
    {
        particleAffect.SetActive(false);
    }
}
