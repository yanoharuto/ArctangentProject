using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteEffect : MonoBehaviour
{ 
    [SerializeField] float playBackTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,playBackTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
