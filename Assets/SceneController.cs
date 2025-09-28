using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    /*public static SceneController instance;
    [SerializeField] Animator transition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void NextLevel()
    {
       StartCoroutine(LoadLevel1());
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    IEnumerator LoadLevel1()
    {
        transition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         transition.SetTrigger("Start");
    }*/




}
