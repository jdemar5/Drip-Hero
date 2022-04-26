using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneSkip : MonoBehaviour
{
    private GameObject timeline, mainmenu, storyboard, skipcutscene, bgm, bgm2, sfx, sfx2;
    private bool cutsceneSkipped = false;

    void Start()
    {
        timeline = GameObject.Find("Timeline");
        mainmenu = GameObject.Find("menu").transform.GetChild(0).gameObject;
        storyboard = GameObject.Find("menu").transform.GetChild(2).gameObject;
        skipcutscene = GameObject.Find("menu").transform.GetChild(2).gameObject;
        bgm = GameObject.Find("Audio").transform.GetChild(0).gameObject;
        bgm2 = GameObject.Find("Audio").transform.GetChild(1).gameObject;
        sfx = GameObject.Find("Audio").transform.GetChild(2).gameObject;
        sfx2 = GameObject.Find("Audio").transform.GetChild(3).gameObject;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !cutsceneSkipped)
        {
            timeline.SetActive(false);
            mainmenu.SetActive(true);
            storyboard.SetActive(false);
            skipcutscene.SetActive(false);
            bgm.SetActive(false);
            bgm2.SetActive(true);
            sfx.SetActive(false);
            sfx2.SetActive(false);
            cutsceneSkipped = true;
        }
    }
}
