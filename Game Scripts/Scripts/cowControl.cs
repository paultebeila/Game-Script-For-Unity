using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class cowControl : MonoBehaviour
{
    NavMeshAgent cowNav;
    public enum StateType { state_SFF, state_flee, state_Eat };
    public StateType currState = StateType.state_SFF;
    Animator a;
    //when we need a new
    bool needWanderDestination = true;
    public grass[] grasses;
    float sightRange = 50f;
    public grass foodTarget;
    public float health = 100;
    public Vector3 fleePos;
    public dogControl[] DogDanger;
    public dogControl Dog;
    public Text txtCow;
    //

    //

    // Use this for initialization
    void Start()
    {


        cowNav = GetComponent<NavMeshAgent>();
        a = GetComponent<Animator>();
        Move(new Vector3(0, 0, 0));
        //a.SetBool("isWalking", false);
        //txtCow.text = "Cow Health :: " + health;
        InvokeRepeating("HealthDecrement", 3.3f, 6.5f);



    }

    // Update is called once per frame
    void Update()
    {

        //print(a.GetBool("isWlaking"));
        txtCow.text = "Cow Health :: " + health;

        UpdateSate(currState);

        if (health > 100)
        { health = 100; }
        if (health <= 0)
        {
            died();

        }





    }

    private void ChangeState(StateType newState)
    {
        currState = newState;
        needWanderDestination = true;


    }

    Vector3 RandomNavMeshHideLocation(dogControl g)
    {

        fleePos = new Vector3(Random.Range(g.gameObject.transform.position.x, 1000), 0, Random.Range(g.gameObject.transform.position.z, 1000));
        return fleePos;


    }


    void Move(Vector3 target)
    {
        cowNav.SetDestination(target);
    }


    void UpdateSate(StateType currentState)
    {
        switch (currentState)
        {
            case StateType.state_SFF:
                a.SetBool("isInDanger", false);
                a.SetBool("isWalking", true);
                cowNav.speed = 3.5f;
                Wandering(); 
                if(checkDanger())
                {
                    ChangeState(StateType.state_flee);
                }
                else if (CheckFood()) //where we are
                {
                    ChangeState(StateType.state_Eat);
                    //currentState = StateType.state_Eat;
                }
                break;
            case StateType.state_Eat:
                if (!foodTarget)
                {
                    ChangeState(StateType.state_SFF);
                }
                else { Eat(); }

                break;
            case StateType.state_flee:
                
                
                flee();

                // print(zebraNav.destination);
                if (Vector3.Distance(Dog.gameObject.transform.position, gameObject.transform.position) > 50)
                {
                    ChangeState(StateType.state_SFF);
                }
                //
                break;


        }
    }

    void died()
    {
        //needWanderDestination = false;
        cowNav.SetDestination(gameObject.transform.position);
        a.SetBool("isWalking", false);
        a.SetBool("isDead", true);
        Invoke("Destroy", 4.4f);



    }
    bool checkDanger()
    {
        DogDanger = FindObjectsOfType<dogControl>();


        foreach (dogControl d in DogDanger)
        {
            if (Vector3.Distance(transform.position, d.gameObject.transform.position) < sightRange)
            {
                Dog = d;

                return true;
            }

        }
        a.SetBool("isInDanger", false);
        return false;
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    void flee()
    {
        a.SetBool("isInDanger", true);
        cowNav.speed = 10;
        cowNav.SetDestination(RandomNavMeshHideLocation(Dog));
        if (Vector3.Distance(cowNav.destination, gameObject.transform.position) < 2)
        {
            ChangeState(StateType.state_SFF);

        }

    }

    bool CheckFood()// checks for food
    {

        grasses = FindObjectsOfType<grass>();
        //print("amount of grass in scene" + grasses.Length);

        foreach (grass g in grasses)
        {
            if (Vector3.Distance(transform.position, g.gameObject.transform.position) < sightRange)
            {
                foodTarget = g;
               // print("Food Found");

                return true;

            }

        }
        return false;


    }

    void HealthDecrement()
    {


        health -= 10;


    }




    void Eat()
    {




        if (foodTarget)
        {
            cowNav.SetDestination(foodTarget.gameObject.transform.position);
        }
        if (foodTarget)
        {
            if (Vector3.Distance(transform.position, foodTarget.gameObject.transform.position) < 5)
            {
                a.SetBool("isWalking", false);
                
                foodTarget.EatMe(45);
                if(health<100)
                { health += 20 * Time.deltaTime; }
                
            }

        }
        else { a.SetBool("isEating", false); }


    }
    public void beingEaten(int biteSize)
    {
        health -= biteSize * Time.deltaTime;

    }



    void Wandering()
    {

        if (needWanderDestination)
        {
            cowNav.SetDestination(new Vector3(Random.Range(10, 1000), 0, Random.Range(10, 1000)));
            if (Vector3.Distance(cowNav.destination, transform.position) < 1)
            {
                a.SetBool("isWalking", false);
            }
            else
            {
                a.SetBool("isWalking", true);

            }
            needWanderDestination = false;

        }
        if (Vector3.Distance(cowNav.destination, transform.position) < 2)
        {
            needWanderDestination = true;
        }
       // print(cowNav.destination);

        //grasses = FindObjectsOfType<grass>();
        //print("amount of grass in scene" + grasses.Length);

        ////for(int i = 0; i <= grasses.Length;i++)
        ////{
        ////    if(Vector3.Distance(gameObject.transform.position, grasses[i].gameObject.transform.position)<sightRange)
        ////    {


        ////        foodTarget = grasses[i];
        ////    }

        ////}
        //foreach(grass g in grasses)
        //{
        //    if (Vector3.Distance(transform.position, g.gameObject.transform.position) < sightRange)
        //    {
        //        foodTarget = g; ;
        //        break;

        //    }



    }






}
