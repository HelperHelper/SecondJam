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
    public void CreationGoblin()
    {
        Vector3 position = new Vector3(-3.91f, Random.Range(-1f, -2f), 0);
        Instantiate(goblin, position, goblin.transform.rotation);
        ActiveButtom.instance.decreaseMoney(sellGoblin);

    }
    public void CreationMusthroom()
    {
        Vector3 position = new Vector3(-3.91f, Random.Range(-1f, -2f), 0);
        Instantiate(musthroom, position, musthroom.transform.rotation);
        ActiveButtom.instance.decreaseMoney(sellMusthroom);

    }
    public void CreationSkeleton()
    {
        Vector3 position = new Vector3(-3.91f, Random.Range(-1f, -2f), 0);
        Instantiate(skeleton, position, skeleton.transform.rotation);
        ActiveButtom.instance.decreaseMoney(sellSkeleton);

    }
    public void CreationEyeMonster()
    {
        Vector3 position = new Vector3(-3.91f, Random.Range(-1f, -2f), 0);
        Instantiate(eyeMonster, position, eyeMonster.transform.rotation);
        ActiveButtom.instance.decreaseMoney(sellEyeMonster);

    }

}
