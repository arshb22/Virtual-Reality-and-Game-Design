using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenerateTrack : MonoBehaviour
{
    //use this script to generate track
    private bool winning = true;
    List<int> positionPossibilities = new List<int>() { 1, 2, 3, 4, 5 };
    public System.Random rnd = new System.Random();
    public GameObject a;
    private IEnumerator coroutine;
    private float positionZ = 250;
    public GameObject b;
    private float timeEnd = 0.0f;

    //How to do this:
    //Randomizer code [chooses how many blocks to have]
    //Randomizer code [chooses where to place them]
    //Instantiates them

    //Have 5 blocks put it in a for loop so it keeps instantiating them
    //GameObject thingdown = GameObject.Instantiate(something)
    //Set thingdown to vector3 position
    //Do slerp to transform position to make it look nice

    //Notes:
    //Blocks are put down too fast [fixed] - changed when the method is invoked
    //The section that is complete where the ball starts on is too long [fixed] - change the scale from 20 to 4.2
    //It doesn't appear in the ether and the move down
    //The blocks are too thick and the ball won't go down
    //The obstacles haven't even been started yet

    //Obstacle Notes:
    //Randomly choose whether or not (yes or no)
    //Randomly choose one place to put it out of the places it exists [check]

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateTrack", 0.5f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        positionZ = positionZ - 2f;
        coroutine = generatePaving(positionZ);
        StartCoroutine(coroutine);
        */
        /*
        timeEnd += Time.deltaTime;
        Debug.Log(timeEnd);
        if(timeEnd > 15.0f)
            CancelInvoke();
        */
    }

    void CreateTrack()
    {
        positionZ = positionZ - 2f;
        coroutine = generatePaving(positionZ);
        StartCoroutine(coroutine);
    }

    IEnumerator generatePaving(float positionZ)
    {
        //Make sure this happens for the top and bottom

        //This code decides how many blocks it wants to spawn [between 2 and 5]
        int howManyBlocks = rnd.Next(2, 5);
        int howManyBlocksTop = rnd.Next(2, 5);
        //This code decides where to spawn it [first orders it randomly, then takes however many places it needs to]
        IEnumerable<int> positionPlaces = positionPossibilities.OrderBy(item => rnd.Next()).Take(howManyBlocks);
        IEnumerable<int> positionPlacesTop = positionPossibilities.OrderBy(item => rnd.Next()).Take(howManyBlocksTop);

        //Instantiate and move it down or up [look down]
        //https://answers.unity.com/questions/570573/how-do-i-slowly-translate-a-object-to-a-other-obje.html [moves it to some place]

        //Goes from left to right instantiating them

        //Decides whether it wants to put an obstacle or not [0 for yes and 1 for no]
        int yesOrNoObstacle = rnd.Next(0, 3);
        //Since it spawns them in a random order; just put it on the first one it spawns

        //have to get first one here if we want to put an obstacle
        int firstPlaceBottom = positionPlaces.First();
        int firstPlaceTop = positionPlacesTop.First();

        foreach (int position in positionPlaces)
        {
            GameObject paver = GameObject.Instantiate(a);
            paver.transform.position = new Vector3((2f * (float)position)-6f, 0, positionZ);
            Destroy(paver, 5.0f);

            if (yesOrNoObstacle == 0)
            {
                GameObject obstacle = GameObject.Instantiate(b);
                obstacle.transform.position = new Vector3((2f*(float)firstPlaceBottom)-6f, 0.5f, positionZ);
                Destroy(obstacle, 5.0f);
            }

        }
        foreach (int position in positionPlacesTop)
        {
            GameObject paver2 = GameObject.Instantiate(a);
            paver2.transform.rotation = Quaternion.Euler(0, 0, 180);
            paver2.transform.position = new Vector3((2f * (float)position) - 6f, 10, positionZ);
            Destroy(paver2, 5.0f);

            if (yesOrNoObstacle == 0)
            {
                GameObject obstacle = GameObject.Instantiate(b);
                obstacle.transform.rotation = Quaternion.Euler(0, 0, 180);
                obstacle.transform.position = new Vector3((2f * (float)firstPlaceTop) -6f, 9.5f, positionZ);
                Destroy(obstacle, 5.0f);
            }
        }
        yield return new WaitForSeconds(0f);
    }
}