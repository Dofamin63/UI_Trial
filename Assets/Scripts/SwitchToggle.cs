using System;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using Toggle = UnityEngine.UI.Toggle;
using DG.Tweening;

public class SwitchToggle : MonoBehaviour
{
   [SerializeField] private RectTransform uiRectTransform;
   [SerializeField] private Color backgroundActiveColor;
   [SerializeField] private Color handleActiveColor;
   [SerializeField] private float speedColor;
   [SerializeField] private float speedHandle;
   private Color _backgroundDefaultColor, _handleDefaultColor;
   private Image _backgroundImage, _handleImage;
   private Toggle _toggle;
   private Vector2 _handlePosition;
   public Action<bool> switchToggle;

   private void Start()
   {
      _toggle = GetComponent<Toggle>();
      _handlePosition = uiRectTransform.anchoredPosition;
      _backgroundImage = uiRectTransform.parent.GetComponent<Image>();
      _handleImage = uiRectTransform.GetComponent<Image>();
      _backgroundDefaultColor = _backgroundImage.color;
      _handleDefaultColor = _backgroundImage.color;
      _toggle.onValueChanged.AddListener(OnSwitch);
      if (_toggle.isOn)
      {
         uiRectTransform.anchoredPosition = _handlePosition * -1;
         _backgroundImage.color = backgroundActiveColor;
         _handleImage.color = handleActiveColor;
      }
   }

   private void OnSwitch(bool on)
   {
      uiRectTransform.DOAnchorPos(on ? _handlePosition * -1 : _handlePosition, speedHandle).SetEase(Ease.InOutBack);
      _backgroundImage.DOColor(on ? backgroundActiveColor : _backgroundDefaultColor, speedColor);
      _handleImage.DOColor(on ? handleActiveColor : _handleDefaultColor, speedColor);
      switchToggle?.Invoke(on);
   }
   private void OnDestroy()
   {
      _toggle.onValueChanged.RemoveListener(OnSwitch);
   }
}
