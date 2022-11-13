using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoblin : MonoBehaviour
{

    public int sellGoblin = 10;
    public int sellMusthroom = 20;
    public int sellSkeleton = 30;
    public int sellEyeMonster = 40;
    public GameObject goblin;
    public GameObject musthroom;
    public GameObject skeleton;
    public GameObject eyeMonster;

    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void CreationGoblin()
    {
        Vector3 psition = new Vector3(-3.91f, Random.Range(-1f, -2f), 0);
        Instantiate(goblin, psition, goblin.transform.rotation);
        ActiveButtom.instance.decreaseMoney(sellGoblin);

    }
    public void CreationMusthroom()
    {
        Vector3 psition = new Vector3(-3.91f, Random.Range(-1f, -2f), 0);
        Instantiate(musthroom, psition, musthroom.transform.rotation);
        ActiveButtom.instance.decreaseMoney(sellMusthroom);

    }
    public void CreationSkeleton()
    {
        Vector3 psition = new Vector3(-3.91f, Random.Range(-1f, -2f), 0);
        Instantiate(skeleton, psition, skeleton.transform.rotation);
        ActiveButtom.instance.decreaseMoney(sellSkeleton);

    }
    public void CreationEyeMonster()
    {
        Vector3 psition = new Vector3(-3.91f, Random.Range(-1f, -2f), 0);
        Instantiate(eyeMonster, psition, eyeMonster.transform.rotation);
        ActiveButtom.instance.decreaseMoney(sellEyeMonster);

    }

}
