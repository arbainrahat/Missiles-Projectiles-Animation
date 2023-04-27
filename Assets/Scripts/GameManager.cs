using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [HideInInspector] public bool isMissileLunched = false;
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private GameObject bloodSplatter;
    [HideInInspector] public float rocketFlySpeeed = 2f;

    [SerializeField] private Transform missile1_SpwanPosition;
    [SerializeField] private Transform[] missile1_TargetPoints;
    [SerializeField] private Transform missile2_SpwanPosition;
    [SerializeField] private Transform[] missile2_TargetPoints;
    [SerializeField] private Transform missile3_SpwanPosition;
    [SerializeField] private Transform[] missile3_TargetPoints;

    #endregion

    #region Methods

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        //Initialization
        rocketFlySpeeed = 2f;
    }

    public void OnLunch_BtnPressed()
    {
        isMissileLunched = true;
    }

    public void Missiles_Set()
    {
        StartCoroutine(Missile1());
        StartCoroutine(Missile2());
        StartCoroutine(Missile3());
    }

    #region Missiles Initiate
    IEnumerator Missile1()
    {
        //Enable Blood Splatter Screen
        bloodSplatter.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < ObjectPooling.SharedInstance.pooledObjects1.Count; i++)
        {
            GameObject missile = ObjectPooling.SharedInstance.GetPooledObject1();

            missile.transform.position = missile1_SpwanPosition.position;
            missile.GetComponent<Missile>().RocketTarget = missile1_TargetPoints[i];
            missile.SetActive(true);

            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(5f);
        StartCoroutine(Missile1());
    }

    IEnumerator Missile2()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < ObjectPooling.SharedInstance.pooledObjects2.Count; i++)
        {
            GameObject missile = ObjectPooling.SharedInstance.GetPooledObject2();

            missile.transform.position = missile2_SpwanPosition.position;
            missile.GetComponent<Missile>().RocketTarget = missile2_TargetPoints[i];
            missile.SetActive(true);

            yield return new WaitForSeconds(0.5f);
        }
        //Set Camera Shake
        cameraShake.SetCameraShake(4f);
        
        yield return new WaitForSeconds(7f);
        
        StartCoroutine(Missile2());
    }

    IEnumerator Missile3()
    {
        yield return new WaitForSeconds(0.8f);
        for (int i = 0; i < ObjectPooling.SharedInstance.pooledObjects3.Count; i++)
        {
            GameObject missile = ObjectPooling.SharedInstance.GetPooledObject3();

            missile.transform.position = missile3_SpwanPosition.position;
            missile.GetComponent<Missile>().RocketTarget = missile3_TargetPoints[i];
            missile.SetActive(true);

            yield return new WaitForSeconds(0.5f);
        }
        
        yield return new WaitForSeconds(9f);
        //Disable Blood Splatter Screen
        bloodSplatter.SetActive(false);
        StartCoroutine(Missile3());
    }
    #endregion

    #region UI Methods

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    #endregion

    #endregion

}
