using System;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Menu : MonoBehaviour
{
	public virtual event Action eventHide;

	[SerializeField] private bool showCursor = true;
	[SerializeField] private CanvasGroup canvasGroup;
	[SerializeField] protected float _fadeTime = 0.2f;
	[SerializeField] protected bool _lerpOnPause = false;

	public virtual void Show()
    {
		StopAllCoroutines();

		canvasGroup.alpha = 0f;
		gameObject.SetActive(true);
		if (showCursor) UnlockCursor();
		if ((Time.timeScale <= 0f && _lerpOnPause == true) || Time.timeScale > 0f)
		{
			this.LerpCoroutine(time: _fadeTime,
				               from: canvasGroup.alpha,
				               to: 1f,
				               action: a => canvasGroup.alpha = a,
				               settings: new CoroutineTemplate.Settings(lerpOnPause: _lerpOnPause)
			                   );
		}
		else
		{
			canvasGroup.alpha = 1f;
		}
	}

    public virtual void Hide()
    {
        StopAllCoroutines();

		if (gameObject.activeSelf == false) return;
		
		canvasGroup.alpha = 1f;

		if ((Time.timeScale <= 0f && _lerpOnPause == true) || Time.timeScale > 0f)
		{
			this.LerpCoroutine(time: _fadeTime, 
				               from: canvasGroup.alpha,
				               to: 0f,
				               action: a => canvasGroup.alpha = a,
				               onEnd: () => DisableGameObject(),
				               settings: new CoroutineTemplate.Settings(lerpOnPause: _lerpOnPause)
			                   );
		}
		else
		{
			DisableGameObject();
		}

	}

	private void DisableGameObject()
    {
		canvasGroup.alpha = 0f;
		LockCursor();
		eventHide?.Invoke();
		gameObject.SetActive(false);
	}

    protected virtual void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

	protected virtual void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}