using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    [SerializeField] Image progressBarFill;

    private int pNum;

    public void Update()
    {
       float progressValue = Mathf.InverseLerp(12f, 0f, pNum);
        progressBarFill.fillAmount = progressValue;
    }

    public void SetNum(int num)
    {
        pNum = num;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
