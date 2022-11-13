using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveButtom : MonoBehaviour
{
   
    public int bank;
    public Text bankText;
    public static ActiveButtom instance;
    public GameObject goblinOff;
    public GameObject musthroomOff;
    public GameObject skelettonOff;
    public GameObject eyeMonsterOff;
    public Button buttonGoblin;
    public Button buttonMusthroom;
    public Button buttonSkeleton;
    public Button buttonEyeMonster;
    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        bankText.text = bank.ToString();
       
        ActivateGoblin();
        ActivateMusthroom();
        ActivateSkeleton();
        ActivateEyeMonster();
    }

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
    }

    public void Money(int Cashcolleted)
    {
        bank += Cashcolleted;
        bankText.text = bank.ToString();
    }
    public void decreaseMoney(int Cashcolleted)
    {
        bank -= Cashcolleted;
        bankText.text = bank.ToString();
    }

    void ActivateGoblin()
    {
        if(bank >= 10)
        {
            goblinOff.SetActive(false);
            buttonGoblin.enabled = true;
           
        }
        else
        {
            goblinOff.SetActive(true);
            buttonGoblin.enabled = false;

        }


    }
    void ActivateMusthroom()
    {
        if (bank >= 20)
        {
            musthroomOff.SetActive(false);
            buttonMusthroom.enabled = true;

        }
        else
        {
            musthroomOff.SetActive(true);
            buttonMusthroom.enabled = false;
        }


    }
    void ActivateSkeleton()
    {
        if (bank >= 30)
        {
            skelettonOff.SetActive(false);
            buttonSkeleton.enabled = true;

        }
        else
        {
            skelettonOff.SetActive(true);
            buttonSkeleton.enabled = false;
        }


    }
    void ActivateEyeMonster()
    {
        if (bank >= 40)
        {
            eyeMonsterOff.SetActive(false);
            buttonEyeMonster.enabled = true;

        }
        else
        {
            eyeMonsterOff.SetActive(true);
            buttonEyeMonster.enabled = false;
        }


    }
}
