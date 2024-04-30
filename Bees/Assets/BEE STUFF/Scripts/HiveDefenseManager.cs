using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiveDefenseManager : MonoBehaviour
{
    [SerializeField] GameObject waspPrefab;
    [SerializeField] GameObject defenseBee;
    [SerializeField] Image fadeImage;
    [SerializeField] float friendlyBeeCount;
    [SerializeField] float fadeToBlackTime;
    [SerializeField] float timeBetweenWasps;

    GameObject currentWasp;
    int waspsKilled = 0;
    bool fading = false;

    void Start()
    {
        currentWasp = Instantiate(waspPrefab, transform.position, Quaternion.identity);
        fadeImage = GameObject.Find("Fade Image").GetComponent<Image>();

        //randomly spawn x defense bees
    }

    void Update()
    {
        if(currentWasp == null)
        {
            waspsKilled++;

            //fade to black and spawn new wasp
            StartCoroutine(FadeToBlack());

            
        }
    }



    IEnumerator FadeToBlack()
    {
        if (!fading)
        {
            fading = true;
            // loop over specified time - fade to black
            for (float i = 0; i < fadeToBlackTime; i += Time.deltaTime)
            {
                // set color with i as alpha
                fadeImage.color = new Color(0, 0, 0, i);
                yield return null;
            }
            fadeImage.color = new Color(0, 0, 0, 1);

            //spawn new wasp
            currentWasp = Instantiate(waspPrefab, new Vector3(Random.Range(2.5f, 17f),1.25f, Random.Range(-1f, 10f)), Quaternion.identity);

            yield return new WaitForSeconds(timeBetweenWasps);

            // loop backwards - fade to clear
            for (float i = fadeToBlackTime; i > 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                fadeImage.color = new Color(0, 0, 0, i);
                yield return null;
            }
            fadeImage.color = new Color(0, 0, 0, 0);
            fading = false;
        }
       
    }
}
