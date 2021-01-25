using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Animator SceneCam;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(SceneTransition());
        } else if (Input.GetButtonDown("Cancel"))
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
