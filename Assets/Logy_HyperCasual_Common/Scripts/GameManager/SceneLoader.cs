using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    [SerializeField] float wait;
    [SerializeField] int start_scene_index;
    [SerializeField] Effect effect;

    bool loading;
    
    /// <summary>
    /// load current scene
    /// </summary>
    public void ReLoadtScene(float wait) {
        StartCoroutine(DelayReLoadtScene(wait));
    }
    IEnumerator DelayReLoadtScene(float wait) {
        //if effect not null, wait effect cost_time
        if(effect != null) {
            EffectSetting();
            effect.Play(0f);
            yield return new WaitForSeconds(effect.CostTime());
        }

        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// load next scene
    /// </summary>
    public void NextScene(float wait) {
        StartCoroutine(DelayNextScene(wait));
    }
    IEnumerator DelayNextScene(float wait) {
        //if effect not null, wait effect cost_time
        if(effect != null) {
            EffectSetting();
            effect.Play(0f);
            yield return new WaitForSeconds(effect.CostTime());
        }
        yield return new WaitForSeconds(wait);
        if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings-1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(start_scene_index);
    }

    /// <summary>
    /// set how many seconds to wait execute LoadScene method
    /// </summary>
    public void SetWait(float wait) {
        this.wait = wait;
    }

    /// <summary>
    /// load index scene
    /// </summary>
    public void LoadScene(int index) {
        StartCoroutine(DelayLoadScene(index));
    }
    IEnumerator DelayLoadScene(int index) {
        //if effect not null, wait effect cost_time
        if(effect != null) {
            EffectSetting();
            effect.Play(0f);
            yield return new WaitForSeconds(effect.CostTime());
        }
        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene(index);
    }

    void EffectSetting() {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(effect.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        SceneManager.sceneLoaded -= OnSceneLoaded;
        effect.finish_distory = true;
        effect.Finish(0f);
        Destroy(gameObject);
    }
}
