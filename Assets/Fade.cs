/*
 The MIT License (MIT)

Copyright (c) 2013 yamamura tatsuhiko

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using DG.Tweening;

public class Fade : MonoBehaviour
{
	IFade fade;
	float cutoutRange;
	bool isfading = false;


	void Awake ()
	{
		Init ();
		fade.Range = cutoutRange;
	}

	

	void Init ()
	{
		fade = GetComponent<IFade> ();
	}

	void OnValidate ()
	{
		Init ();
		fade.Range = cutoutRange;
	}

	IEnumerator FadeoutCoroutine (float time, System.Action action)
	{
		isfading = true;
		DOTween.To(
			() => fade.Range,
			cutoutRange => fade.Range = cutoutRange,
			0f,
			1f
			).OnComplete(() => isfading = false);

        while (isfading) { yield return null; }
		cutoutRange = 0;
		fade.Range = cutoutRange;
		if (action != null)
		{
			action();
		}
	}

	IEnumerator FadeinCoroutine (float time, System.Action action)
	{
		isfading = true;
		DOTween.To(
			() => fade.Range,
			cutoutRange => fade.Range = cutoutRange,
			1f,
				1f
		).OnComplete(() => isfading = false);

        while (isfading) { yield return null; }
		cutoutRange = 1;
		fade.Range = cutoutRange;

		if(action != null)
        {
			action();
        }
	}

	public Coroutine FadeOut(float time, System.Action action = null)
	{
		StopAllCoroutines ();
		return StartCoroutine (FadeoutCoroutine (time, action));
	}



	public Coroutine FadeIn(float time, System.Action action = null)
	{
		StopAllCoroutines ();
		return StartCoroutine (FadeinCoroutine (time, action));
	}

}