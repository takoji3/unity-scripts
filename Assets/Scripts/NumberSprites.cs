using UnityEngine;

public class NumberSprites : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer[] Renderers;

    [SerializeField]
    OrderType Order;
    
    [SerializeField]
    Sprite[] SpriteImages = new Sprite[10];

    enum OrderType
    {
        Increase,
        Decrease
    }

    public int Value { get; set; }

    int displayValue = 0;

    System.Action update;

    System.Action Increase
    {
        get
        {
            return () =>
            {
                if (this.Value > this.displayValue) this.UpdateDisplayValue(++this.displayValue);
            };
        }
    }

    System.Action Decrease
    {
        get
        {
            return () =>
            {
                if (this.Value < this.displayValue) this.UpdateDisplayValue(--this.displayValue);
            };
        }
    }

    public void Reset(int value)
    {
        this.displayValue = value;
        this.Value = value;
        this.UpdateDisplayValue(value);
    }

    void Awake()
    {
        this.update = this.Order == OrderType.Increase ? this.Increase : this.Decrease;
    }

    // Update is called once per frame
    void Update ()
    {
        this.update();
    }

    void UpdateDisplayValue(int value)
    {
        int index = 0;
        int last = this.Renderers.Length - 1;

        while (index <= last)
        {
            int num = value / (int)Mathf.Pow(10, last - index) % 10;
            this.Renderers[index++].sprite = this.SpriteImages[num];
        }
    }
    
    Sprite SpriteImage(int num)
    {
        return this.SpriteImages[num];
    }
}