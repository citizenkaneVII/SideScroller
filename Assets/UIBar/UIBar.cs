using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIBar : MonoBehaviour {

    public Image bar;
    public Text coinNum;

    public int totalCoinValue;
    public int coinValue = 10;
    public float powerLevel = 0.1f;
    public float amountToAdd = 0.01f;
    
    public enum PowerUpType
    {
        PowerUp,
        PowerDown,
        CollectCoin,
    }



public PowerUpType powerUp;

    void OnTriggerEnter () {
        switch (PowerUp)
        {
           case PowerUpType.PowerUp:
                StartCoroutine(PowerUpBar());
           break;
           
           case PowerUpType.PowerDown:
                StartCoroutine(PowerDownBar());
           break;

           case PowerUpType.CollectCoin:
                //DoWork
           break;
        }
    }

    IENumerator CollectCoin (){
        print("Coin Collected");
        totalCoinValue = int.Parse (coinNum.text);
       // coinNum.text = (coinValue + coinValue).ToString();

        //Need while loop to add numbers to the UI
        int tempAmount = totalCoinValue + coinValue;
        while (totalCoinValue <= tempAmount)
        {
            coinNum.text = (totalCoinValue++).ToString();
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator PowerUpBar () {
        float tempAmount = bar.fillAmount + powerLevel;
        while (bar.fillAmount < 1)
        {
            bar.fillAmount += amountToAdd;
            yield return new WaitForSeconds(barTime);
        }
    }

    IEnumerator PowerDownBar () {
        float tempAmount = bar.fillAmount - powerLevel;
        print(bar.fillAmount);
        print (tempAmount);
        while (powerLevel > tempAmount)
        {
            bar.fillAmount -= amountToAdd;
            yield return new WaitForSeconds(amountToAdd);

            if (bar.FillAmount == 0){
                yield return null;
            }
        }
    }
}