using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera camera;
    public Transform DebugTouchPosition;
    public Transform bulletSpawnPoint;
    [Range(0.1f, 2f)]
    public float fireRate = 1;
    public GameObject bullet;
    public int maxTotalBullets = 100;

    private List<GameObject> bullets;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        bullets = new List<GameObject>();

        for (int i = 0; i < maxTotalBullets; i++) {
            GameObject newBullet = Instantiate(bullet, Vector3.back * 100, Quaternion.identity);
            newBullet.SetActive(false);
            newBullet.GetComponent<Bullet>().SetGenerator(this.gameObject);
            bullets.Add(newBullet);
        }

        StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {

                float depth = Vector3.Distance(transform.position, camera.transform.position);

                // get the touch position from the screen touch to world point
                Vector3 touchedPos = camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, depth));
                DebugTouchPosition.position = touchedPos;
                touchedPos.y = transform.position.y;
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * 10);
            }
        }
    }

    void Shoot() {
        if (bullets.Count > 0) {
            GameObject bullet = bullets[bullets.Count - 1];
            bullets.Remove(bullet);
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.SetActive(true);
        }
    }

    public void RemoveBullet(GameObject bullet) {
        bullet.transform.position = Vector3.zero;
        bullet.SetActive(false);
        bullets.Add(bullet);
    }

    IEnumerator Shooting()
    {
        for (; ; )
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }
}
