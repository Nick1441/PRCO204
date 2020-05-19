using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator alien;
    public Animator playerBook;
    public Animator alienBook;
    public Animator stick;
    public Animator sword;
    public Animator axe;
    public Animator camera;
    private bool inputAllowed = false;
    private bool clicked = false;

    private float yRotation = 0;
    private float xRotation = 0;
    private float screenCenter = Screen.width / 2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Animation());
    }

    // Update is called once per frame
    void Update()
    {
        print(Input.mousePosition.x - screenCenter);
        if (Input.GetMouseButton(0) == true && inputAllowed == true && clicked == false)
        {
            if (Input.mousePosition.x - screenCenter > 30)
            {
                StartCoroutine(Clicked("sword"));
            }
            else if (Input.mousePosition.x - screenCenter < -30)
            {
                StartCoroutine(Clicked("axe"));
            }
            else
            {
                StartCoroutine(Clicked("stick"));
            }


        }

        if (Input.GetKey(KeyCode.D))
        {
            if (yRotation < 5 && camera.isActiveAndEnabled == false)
            {
                camera.gameObject.transform.Rotate(0, 0.1f, 0);
                yRotation = yRotation + 0.1f;
            }

        }

        if (Input.GetKey(KeyCode.A))
        {
            if (yRotation > -5 && camera.isActiveAndEnabled == false)
            {
                camera.gameObject.transform.Rotate(0, -0.1f, 0);
                yRotation = yRotation -0.1f;
            }

        }

        if (Input.GetKey(KeyCode.S))
        {
            if (xRotation < 5 && camera.isActiveAndEnabled == false)
            {
                camera.gameObject.transform.Rotate(0.1f, 0, 0);
                xRotation = xRotation + 0.1f;
            }

        }

        if (Input.GetKey(KeyCode.W))
        {
            if (xRotation > -7 && camera.isActiveAndEnabled == false)
            {
                camera.gameObject.transform.Rotate(-0.1f, 0, 0);
                xRotation = xRotation - 0.1f;
            }

        }
    }

    private IEnumerator Animation()
    {
        alienBook.enabled = false;
        playerBook.enabled = false;
        alien.enabled = false;
        stick.enabled = false;
        axe.enabled = false;
        sword.enabled = false;

        alienBook.gameObject.transform.localScale = new Vector3(0, 0, 0);
        playerBook.gameObject.transform.localScale = new Vector3(0, 0, 0);
        stick.gameObject.transform.localScale = new Vector3(0, 0, 0);
        axe.gameObject.transform.localScale = new Vector3(0, 0, 0);
        sword.gameObject.transform.localScale = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(1);

        alienBook.enabled = true;
        alien.enabled = true;
        alienBook.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        yield return new WaitForSeconds(2);
        camera.enabled = false;

        playerBook.enabled = true;
        playerBook.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

        stick.enabled = true;
        axe.enabled = true;
        sword.enabled = true;

        yield return new WaitForSeconds(0.98f);
        axe.enabled = false;
        sword.enabled = false;
        stick.enabled = false;

        inputAllowed = true;
    }

    private IEnumerator Clicked(string item)
    {
        clicked = true;
        if (item == "stick")
        {
            Destroy(axe.gameObject);
            Destroy(sword.gameObject);
            stick.enabled = true;
            yield return new WaitForSeconds(2);
        }

        if (item == "axe")
        {
            Destroy(sword.gameObject);
            Destroy(stick.gameObject);
            axe.enabled = true;
            axe.Play("StickThrow");
            yield return new WaitForSeconds(2);
        }

        if (item == "sword")
        {
            Destroy(axe.gameObject);
            Destroy(stick.gameObject);
            sword.enabled = true;
            sword.Play("StickThrow");
            yield return new WaitForSeconds(2);
        }


        yield return new WaitForSeconds(3.5f);
        alien.Play("AlienCrash");

        yield return new WaitForSeconds(1f);
        Destroy(alien.gameObject);
        Destroy(alienBook.gameObject);
        if (item == "sword")
        {
            Destroy(sword.gameObject);
        }

        if (item == "axe")
        {
            Destroy(axe.gameObject);
        }

        if (item == "stick")
        {
            Destroy(stick.gameObject);
        }
        Destroy(playerBook.gameObject);
    }
}
