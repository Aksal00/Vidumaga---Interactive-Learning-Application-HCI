using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    // Start is called before the first frame update
    public int countdownTime;
    public TMP_Text countdownDisplay;

    public GameObject hat;
    void Start()
    {
        StartCoroutine(CountdownToStart());
    }
    // Update is called once per frame
    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1F);
            countdownTime--;
        }

        countdownDisplay.text = "Go!";
        Player.Seller_voice();
        yield return new WaitForSeconds(1F);  
        countdownDisplay.gameObject.SetActive(false);
        yield return new WaitForSeconds(1F);
        hat.gameObject.SetActive(true);
    }
}
