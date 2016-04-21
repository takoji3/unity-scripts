using UnityEngine;
using System.Collections;

public class Shaker : MonoBehaviour
{
    [SerializeField]
    float Duration;

    [SerializeField]
    Size Magnitude;

    [System.SerializableAttribute]
    struct Size
    {
        public float X;
        public float Y;
        public float Z;
    }

    GameObject obj;

    public void Shake()
    {
        StartCoroutine(Execute());
    }

    IEnumerator Execute()
    {
        float passed = 0f;
        Vector3 org = this.obj.transform.position;

        while (passed <= this.Duration)
        {
            passed += Time.deltaTime;

            Vector3 d = new Vector3(
                Random.value * this.Magnitude.X - this.Magnitude.X / 2,
                Random.value * this.Magnitude.Y - this.Magnitude.Y / 2,
                Random.value * this.Magnitude.Z - this.Magnitude.Z / 2
            );

            this.obj.transform.position = org + d;
            yield return null;
        }

        this.obj.transform.position = org;
    }

    void Awake()
    {
        this.obj = this.transform.gameObject;
    }
}