using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HiveDefenseManager : MonoBehaviour
{
    [SerializeField] GameObject waspPrefab;
    [SerializeField] GameObject defenseBee;
    [SerializeField] Image fadeImage;
    [SerializeField] TextMeshProUGUI fadeText;
    [SerializeField] float friendlyBeeCount;
    [SerializeField] float fadeToBlackTime;
    [SerializeField] float timeBetweenWasps;

    GameObject currentWasp;
    bool fading = false;

    void Start()
    {
        currentWasp = Instantiate(waspPrefab, transform.position, Quaternion.identity);
        fadeImage = GameObject.Find("Fade Image").GetComponent<Image>();
        fadeText = GameObject.Find("Fade Text").GetComponent<TextMeshProUGUI>();

        //randomly spawn x defense bees
        for (int i = 0; i < friendlyBeeCount; i++)
        {
            Instantiate(defenseBee, new Vector3(Random.Range(2.5f, 17f), 1.25f, Random.Range(-1f, 10f)), Quaternion.identity);
        }
    }

    void Update()
    {
        if(currentWasp == null)
        {
            //fade to black and spawn new wasp
            StartCoroutine(FadeToBlack());

            
        }
    }



    IEnumerator FadeToBlack()
    {
        if (!fading)
        {
            print("fading");
            fading = true;
            // loop over specified time - fade to black
            for (float i = 0; i < fadeToBlackTime; i += Time.deltaTime)
            {
                // set color with i as alpha
                fadeImage.color = new Color(0, 0, 0, i);
                print(fadeImage.color.a);
                fadeText.color = new Color(1,1,1,i);
                yield return null;
            }
            fadeImage.color = new Color(0, 0, 0, 1);
            fadeText.color = new Color(1, 1, 1, 1);

            //spawn new wasp
            currentWasp = Instantiate(waspPrefab, new Vector3(Random.Range(2.5f, 17f),1.25f, Random.Range(-1f, 10f)), Quaternion.identity);

            yield return new WaitForSeconds(timeBetweenWasps);

            // loop backwards - fade to clear
            for (float i = fadeToBlackTime; i > 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                fadeImage.color = new Color(0, 0, 0, i);
                fadeText.color = new Color(1, 1, 1, i);
                yield return null;
            }
            fadeImage.color = new Color(0, 0, 0, 0);
            fadeText.color = new Color(1, 1, 1, 0);
            fading = false;
        }
       
    }
}
