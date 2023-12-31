using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class ChangeScene : MonoBehaviour
{
    public static UnityAction sceneChanged;
    private static Stack<string> scenes;
    public static string[] allScenes;

    void Start()
    {
        if (scenes != null && allScenes != null) return;

        scenes = new(SceneManager.sceneCountInBuildSettings);
        scenes.Push(SceneManager.GetActiveScene().path);

        allScenes = new string[SceneManager.sceneCountInBuildSettings];

        for (int i = 0; i < allScenes.Length; i += 1)
            allScenes[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        if (scenes.Count == allScenes.Length)
            scenes.Clear();

        string path;

        do
        {
            int randomIndex = Random.Range(0, allScenes.Length);
            path = allScenes[randomIndex];
        } while (scenes.Contains(path));

        scenes.Push(path);
        sceneChanged();
        SceneManager.LoadScene(path);
    }
}