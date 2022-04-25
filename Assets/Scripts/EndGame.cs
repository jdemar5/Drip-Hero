using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("EndGameC");
    }

    IEnumerator EndGameC()
    {
        yield return new WaitForSeconds(14f);
        SceneManager.LoadScene(0);
    }
}
