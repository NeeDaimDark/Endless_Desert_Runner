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
    //after i made  5 sections(level) i generated it randomly using a table of game objects every 4 sec every section is 41 m long i putted 5 sections and i started generated them after 4sections 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this is were i check if section are not creating if not  i create one 
        if(creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }
    //this method helps me generate  randomly one section evrery 4 sec
    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 5);
        Instantiate(section[secNum], new Vector3(0,0,xPos+164),Quaternion.identity);
        xPos = xPos+41;
        yield return new WaitForSeconds(4);
        creatingSection=false;

    }


}
