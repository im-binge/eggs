using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Pool;
using System;

public class ChickenManager : MonoBehaviour
{
    private static ChickenManager _instance;

    private float passedTime;

    float multCooldown = 0f;
    public float mult = 1;

    [SerializeField] GameObject chicken;

    public event Action AddScore;
    public event Action UpdateMult;

    public static ChickenManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ChickenManager>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        mult = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            multCooldown = 0f;

            GameObject chicken = ChickenPool.SharedInstance.GetPooledObject();
            chicken.SetActive(true);

        }

        multCooldown = multCooldown + Time.deltaTime;

        if(mult < 1 && multCooldown == 2f)
        {
            mult = mult - 0.1f;
        }

        passedTime = passedTime + Time.deltaTime;
        if(passedTime == 10f)
        {
            mult = mult + 0.1f;
        }

        UpdateMultiplier();
    }

    public void Score()
    {
        AddScore?.Invoke();
    }

    void UpdateMultiplier()
    {
        UpdateMult?.Invoke();
    }
}
