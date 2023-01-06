using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public Credits _003C_003E4__this;

		public GameObject currentPage;

		internal void _003CNextPage_003Eb__0()
		{
			_003C_003E4__this.canChangePage = true;
			currentPage.SetActive(false);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public Credits _003C_003E4__this;

		public GameObject currentPage;

		internal void _003CPreviousPage_003Eb__0()
		{
			_003C_003E4__this.canChangePage = true;
			currentPage.SetActive(false);
		}
	}

	public string tagName = "CreditsBox";

	private bool canChangePage = true;

	private int page;

	public GameObject[] pages;

	public AudioClip scrollSound;

	public float distance = 5000f;

	public float transitionTime = 0.66f;

	public GameObject nextButton;

	public GameObject previousButton;

	public ButtonGroup buttonGroup;

	private void Start()
	{
		for (int i = 1; i < pages.Length; i++)
		{
			pages[i].SetActive(false);
		}
		updatePage();
	}

	public void NextPage()
	{
		_003C_003Ec__DisplayClass11_0 _003C_003Ec__DisplayClass11_ = new _003C_003Ec__DisplayClass11_0();
		_003C_003Ec__DisplayClass11_._003C_003E4__this = this;
		if (canChangePage && page != pages.Length - 1)
		{
			canChangePage = false;
			_003C_003Ec__DisplayClass11_.currentPage = pages[page];
			RectTransform component = pages[page + 1].GetComponent<RectTransform>();
			component.gameObject.SetActive(true);
			component.anchoredPosition = new Vector2(distance, component.anchoredPosition.y);
			_003C_003Ec__DisplayClass11_.currentPage.GetComponent<RectTransform>().DOAnchorPosX(0f - distance, transitionTime).SetEase(Ease.OutExpo);
			component.DOAnchorPosX(0f, transitionTime).SetEase(Ease.OutExpo).OnComplete(_003C_003Ec__DisplayClass11_._003CNextPage_003Eb__0);
			page++;
			updatePage();
			Camera.main.GetComponent<AudioSource>().PlayOneShot(scrollSound, 0.5f);
		}
	}

	public void PreviousPage()
	{
		_003C_003Ec__DisplayClass12_0 _003C_003Ec__DisplayClass12_ = new _003C_003Ec__DisplayClass12_0();
		_003C_003Ec__DisplayClass12_._003C_003E4__this = this;
		if (canChangePage && page != 0)
		{
			canChangePage = false;
			_003C_003Ec__DisplayClass12_.currentPage = pages[page];
			RectTransform component = pages[page - 1].GetComponent<RectTransform>();
			component.gameObject.SetActive(true);
			component.anchoredPosition = new Vector2(0f - distance, component.anchoredPosition.y);
			pages[page].GetComponent<RectTransform>().DOAnchorPosX(distance, transitionTime).SetEase(Ease.OutExpo);
			component.DOAnchorPosX(0f, transitionTime).SetEase(Ease.OutExpo).OnComplete(_003C_003Ec__DisplayClass12_._003CPreviousPage_003Eb__0);
			page--;
			updatePage();
			Camera.main.GetComponent<AudioSource>().PlayOneShot(scrollSound, 0.5f);
		}
	}

	private void updatePage()
	{
		nextButton.SetActive(page < pages.Length - 1);
		previousButton.SetActive(page > 0);
		if (!nextButton.activeInHierarchy)
		{
			buttonGroup.silentSelect(previousButton.GetComponent<Button>());
		}
		if (!previousButton.activeInHierarchy)
		{
			buttonGroup.silentSelect(nextButton.GetComponent<Button>());
		}
	}
}
