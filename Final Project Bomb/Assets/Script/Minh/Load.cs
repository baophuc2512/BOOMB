using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public bool wantToSave = false;

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        if (wantToSave == true)
        {
            GameObject.Find("SaveDataBetweenScene").GetComponent<ApplyData>().saveData();
        }
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        GameObject.Find("SaveDataBetweenScene").GetComponent<ApplyData>().loadData();


        yield return null;
    }

}
