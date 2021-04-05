using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null)
                return;
        }

        //log entry
        Debug.Log("You Killed all enemies");
        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}


public class WaitForSecondsExample : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(10);
        print(Time.time);
    }
}