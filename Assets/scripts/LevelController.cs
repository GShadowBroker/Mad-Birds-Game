using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int LevelIndex = 1;
    private Enemy[] Enemies;

    private void OnEnable()
    {
        Enemies = FindObjectsOfType<Enemy>();
        Debug.Log("Number of enemies in the level: " + Enemies.Length);
    }

    void Update()
    {
        foreach (Enemy enemy in Enemies)
        {
            if (enemy != null) return;
        }

        // loop back to first level if we pass level 4
        if (LevelIndex == 4)
        {
            LevelIndex = 0;
        }

        LevelIndex++;
        string levelName = "Level" + LevelIndex;

        SceneManager.LoadScene(levelName);
    }
}
