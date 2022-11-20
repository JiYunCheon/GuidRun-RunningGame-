using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [SerializeField] Slider slider;
  
    public void SceneChange()
    {
        StartCoroutine(startScene());
    }


    IEnumerator startScene()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("Select",LoadSceneMode.Single);
        slider.gameObject.SetActive(true);
        slider.value = ao.progress;
        while(ao.isDone ==true)
        {
            slider.value = ao.progress;
            yield return null;
        }
        slider.value = ao.progress;
        //yield return new WaitForSeconds(3f);
        //slider.gameObject.SetActive(false);
    }

}
