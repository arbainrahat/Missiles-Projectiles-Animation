using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    [SerializeField] private Transform playerSpwanPoint;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    private bool isHitted = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Missile") && !isHitted)
        {
            audioSource.PlayOneShot(audioClip);
            StartCoroutine(ResetPlayer());
        }

    }

    IEnumerator ResetPlayer()
    {
        isHitted = true;
        yield return new WaitForSeconds(4f);
        this.GetComponent<Animator>().SetBool("Die", false);
        transform.SetPositionAndRotation(playerSpwanPoint.position, playerSpwanPoint.rotation);
        isHitted = false;
    }
}
