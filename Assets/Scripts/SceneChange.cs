using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public int index;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        index = SceneManager.GetActiveScene().buildIndex;
        IdentifyScene();

    }

    void IdentifyScene()
    {

        if(index == 0 && Input.anyKeyDown)
        {
            SceneManager.LoadScene(index + 1);
        }

    }

}
