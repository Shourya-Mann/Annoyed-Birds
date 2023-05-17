using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 2; 
    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Enemy enemy in _enemies)
        {
            if (enemy != null) return;
        }

        Debug.Log("You killed all enemies");

        _nextLevelIndex++;
        string nextLevelName = "level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}
