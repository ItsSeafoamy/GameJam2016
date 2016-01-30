using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

    static LoadingScreen instance;

    void Awake() {
        if (instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
            if (instance != this)
            Destroy(gameObject);
    }

	public static IEnumerator ChangeScene(string scene) {
        /*int progress = 0;
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        while (!async.isDone) {

        }*/
        Application.LoadLevelAsync(scene);

        yield return null;
    }
}
