using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [Header("Setup")]
    public Transform RocketTarget;
    public Rigidbody RocketRgb;

    public float turnSpeed = 1f;
    public float rocketFlySpeed = 10f;

    private Transform rocketLocalTrans;

    // Start is called before the first frame update
    void Start()
    {
        if (!RocketTarget)
            Debug.Log("Please set the Rocket Target");

        rocketLocalTrans = GetComponent<Transform>();
        rocketFlySpeed = GameManager.Instance.rocketFlySpeeed;
    }


    private void FixedUpdate()
    {
        if (!RocketRgb) //If we have not set the Rigidbody, do nothing..
            return;

        if (GameManager.Instance.isMissileLunched)
        {
            RocketRgb.velocity = rocketLocalTrans.forward * rocketFlySpeed;

            //Now Turn the Rocket towards the Target
            var rocketTargetRot = Quaternion.LookRotation(RocketTarget.position - rocketLocalTrans.position);

            RocketRgb.MoveRotation(Quaternion.RotateTowards(rocketLocalTrans.rotation, rocketTargetRot, turnSpeed));
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Deactivate Rocket..
            this.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            collision.gameObject.GetComponent<Animator>().SetBool("Die", true);
        }
    }
}
