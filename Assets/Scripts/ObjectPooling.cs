using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    #region Fields
    public static ObjectPooling SharedInstance;

    //Missile One Pooling Data
    public List<GameObject> pooledObjects1;
    [SerializeField] private GameObject objectToPool1;
    [SerializeField] private int amountToPool1 = 5;

    //Missile Two Pooling Data
    public List<GameObject> pooledObjects2;
    [SerializeField] private GameObject objectToPool2;
    [SerializeField] private int amountToPool2 = 5;

    //Missile Three Pooling Data
    public List<GameObject> pooledObjects3;
    [SerializeField] private GameObject objectToPool3;
    [SerializeField] private int amountToPool3 = 5;
    #endregion

    #region Methods
    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        MakePooling_Missile1();
        MakePooling_Missile2();
        MakePooling_Missile3();
    }

    #region Make Object Pooling
    private void MakePooling_Missile1()
    {
        pooledObjects1 = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool1; i++)
        {
            tmp = Instantiate(objectToPool1);
            tmp.SetActive(false);
            pooledObjects1.Add(tmp);
        }
    }

    private void MakePooling_Missile2()
    {
        pooledObjects2 = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool2; i++)
        {
            tmp = Instantiate(objectToPool2);
            tmp.SetActive(false);
            pooledObjects2.Add(tmp);
        }
    }

    private void MakePooling_Missile3()
    {
        pooledObjects3 = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool3; i++)
        {
            tmp = Instantiate(objectToPool3);
            tmp.SetActive(false);
            pooledObjects3.Add(tmp);
        }
    }
    #endregion

    #region Get Pooled Objects
    public GameObject GetPooledObject1()
    {
        for (int i = 0; i < amountToPool1; i++)
        {
            if (!pooledObjects1[i].activeInHierarchy)
            {
                return pooledObjects1[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject2()
    {
        for (int i = 0; i < amountToPool2; i++)
        {
            if (!pooledObjects2[i].activeInHierarchy)
            {
                return pooledObjects2[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject3()
    {
        for (int i = 0; i < amountToPool3; i++)
        {
            if (!pooledObjects3[i].activeInHierarchy)
            {
                return pooledObjects3[i];
            }
        }
        return null;
    }
    #endregion

    #endregion

}
