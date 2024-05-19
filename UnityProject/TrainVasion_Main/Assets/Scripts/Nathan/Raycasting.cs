using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Raycasting : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject stop;
    public Vector3 Player;
    public Vector3 newDirection;
    public Vector3 newDirectionLeft;
    public Vector3 newDirectionRight;
    public float rayRange;
    public bool onStop = true;
    public bool hitTargetForward;
    public bool hitTargetLeft;
    public bool hitTargetRight;

    public GameObject forwardButton;
    public GameObject leftButton;
    public GameObject rightButton;

    public Image forwardButtonImage;
    public Image leftButtonImage;
    public Image rightButtonImage;

    public Button forwardButtonClick;
    public Button leftButtonClick;
    public Button rightButtonClick;

    Ray ray;
    Ray rayLeft;
    Ray rayRight;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        newDirection = Quaternion.Euler(0, 180, 0) * transform.forward;
        newDirectionLeft = Quaternion.Euler(0, 180, 0) * -transform.right;
        newDirectionRight = Quaternion.Euler(0, 180, 0) * transform.right;
    }

    // Update is called once per frame
    void Update()
    {

        forwardButton = GameObject.Find("Forward Button");
        forwardButtonImage = forwardButton.GetComponent<Image>();
        forwardButtonClick = forwardButton.GetComponent<Button>();

        leftButton = GameObject.Find("Left Button");
        leftButtonImage = leftButton.GetComponent<Image>();
        leftButtonClick = leftButton.GetComponent<Button>();

        rightButton = GameObject.Find("Right Button");
        rightButtonImage = rightButton.GetComponent<Image>();
        rightButtonClick = rightButton.GetComponent<Button>();

        Player = transform.position;
        ray = new Ray(Player, newDirection);

        if (!onStop)
        {
            forwardButtonImage.enabled = false;
            forwardButtonClick.enabled = false;
            leftButtonImage.enabled = false;
            leftButtonClick.enabled = false;
            rightButtonImage.enabled = false;
            rightButtonClick.enabled = false;
        }


        if (Physics.Raycast(ray, out hit, rayRange))
        {
            if ((hit.collider.tag == ("1 People") || hit.collider.tag == ("5 People") || hit.collider.tag == ("10 People") || hit.collider.tag == ("The End")) && onStop)
            {
                stop = hit.collider.gameObject;

                forwardButtonImage.enabled = true;
                forwardButtonClick.enabled = true;
                hitTargetForward = true;
            }
            else if(hit.collider.tag == ("Blockade") && onStop)
            {
                forwardButtonImage.enabled = false;
                forwardButtonClick.enabled = false;
                leftButtonImage.enabled = true;
                leftButtonClick.enabled = true;
                rightButtonImage.enabled = true;
                rightButtonClick.enabled = true;
            }
        }

        Player = transform.position;
        rayLeft = new Ray(Player, newDirectionLeft);

        if (Physics.Raycast(rayLeft, out hit, rayRange))
        {
            if ((hit.collider.tag == ("1 People") || hit.collider.tag == ("5 People") || hit.collider.tag == ("10 People") || hit.collider.tag == "The End" && onStop))
            {
                leftButtonImage.enabled = true;
                leftButtonClick.enabled = true;
            }
        }

        Player = transform.position;
        rayRight = new Ray(Player, newDirectionRight);

        if (Physics.Raycast(rayRight, out hit, rayRange))
        {
            if ((hit.collider.tag == ("1 People") || hit.collider.tag == ("5 People") || hit.collider.tag == ("10 People") || hit.collider.tag == ("The End") && onStop))
            {
                rightButtonImage.enabled = true;
                rightButtonClick.enabled = true;
            }
        }
    }

    public void RayCast(GameObject other)
    {
        if (Physics.Raycast(ray, out hit, rayRange))
        {
            if (hit.collider.tag == "1 People" || hit.collider.tag == "5 People" || hit.collider.tag == "10 People" || hit.collider.tag == "The End")
            {
                stop = other.gameObject;
                Vector3 stopPos = other.transform.position;
                playerController.Transition(stopPos);
            }
        }
    }

    public void ActivateMovement()
    {
        RayCast(stop);
    }

    public void RotateRay(int rotateLeft, int rotateRight)
    {
        if(rotateRight == 0)
        {
            newDirection = Quaternion.Euler(0, -90, 0) * transform.forward;
            newDirectionLeft = Quaternion.Euler(0, -90, 0) * -transform.right;
            newDirectionRight = Quaternion.Euler(0, -90, 0) * transform.right;
        }
        else if(rotateLeft == 1)
        {
            newDirection = Quaternion.Euler(0, 90, 0) * transform.forward;
            newDirectionLeft = Quaternion.Euler(0, 90, 0) * -transform.right;
            newDirectionRight = Quaternion.Euler(0, 90, 0) * transform.right;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(Player, ray.direction * rayRange);
        Gizmos.DrawRay(Player, rayLeft.direction * rayRange);
        Gizmos.DrawRay(Player, rayRight.direction * rayRange);
    }


}
