using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] section;
    public int xPos = 164;
    public bool creatingSection = false;
    public int secNum;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }
    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 5);
        Instantiate(section[secNum], new Vector3(0,0,xPos+164),Quaternion.identity);
        xPos = xPos+41;
        yield return new WaitForSeconds(4);
        creatingSection=false;

    }


}
