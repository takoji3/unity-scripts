## Synopsis

Just my convenience unity script collection. 

## Code Example

### NumberSprites

Display value with sprite images.

![unityscript-ns.gif](https://qiita-image-store.s3.amazonaws.com/0/15618/380d4a98-c235-dd16-00bf-621555d419e0.gif "unityscript-ns.gif")

```c#
// increase or decrease
this.Numbers.Value += Random.Range(10, 20);
```

### Shaker

Shake the GameObject.

![unityscript-sh.gif](https://qiita-image-store.s3.amazonaws.com/0/15618/2ee93c79-32e6-403c-c3cb-d6ce1942e060.gif "unityscript-sh.gif")

```c#
// Canonfigure on Editor.
this.ShakeObject.Shake();
```

### Sound

Dynamically load and play audio source sample.

```c#
// play by AudioSource#Play
Sound.Instance.PlayBGM("sample-bgm");
Sound.Instance.FadeOutBGM(5f, () => Debug.Log("Completely fade out"));

// play by AudioSource#PlayOneShot
Sound.Instance.PlaySE("sample-se");
```

## Motivation

For more convenient unity development :)

## License

[MIT](https://github.com/takoji3/unity-scripts/blob/master/LICENSE)