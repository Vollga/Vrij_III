using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Animator SceneCam;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SceneTransition());
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator SceneTransition()
    {
        SceneCam.SetTrigger("startTransition");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(1);
    }
}
