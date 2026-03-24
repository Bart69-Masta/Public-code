using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    public GameObject Player;

    public ParticleSystem particleEffect;
    //public NEWMOVE targetScript;

    public string sceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (Player)
        {
            PlayEffect();
            //DisableScript();
            yield return new WaitForSeconds(2);
            LoadScene();
            Debug.Log("To the next level");
        }


        else if (other.gameObject.tag == "untagged")
        {
            Debug.Log("nada");
        }
    }

    //load scene is for intial ui to start game
    //must make a new variant to load player into next level in the series

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlayEffect()
    {
        if (particleEffect != null)
        {
            particleEffect.Play();
        }
        else
        {
            Debug.LogWarning("Particle System is not assigned.");
        }
    }

    //public void DisableScript()
    //{
    //    if (targetScript != null)
    //    {
    //        targetScript.enabled = false; // Disable the script
    //        Debug.Log("TargetScript has been disabled.");
    //    }

    //    else
    //    {
    //        Debug.LogWarning("TargetScript reference is missing!");
    //    }
    //}
   
}