using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControls : MonoBehaviour {

    Vector3 pos;
    Quaternion rotate = Quaternion.identity;
    Rigidbody2D rig;

    public int speed;
    int x = -90;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        rig = GetComponent<Rigidbody2D>();

        rotate.eulerAngles = new Vector3(0, 0, x);
        rig.velocity = transform.up * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            x -= 90;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            x += 90;
        }

        transform.rotation = rotate;
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "wall")
        {
            SceneManager.LoadScene("gameover");
        }
        if (otherCollider.tag == "win")
        {
            SceneManager.LoadScene("nextlevel");
        }
    }

}
