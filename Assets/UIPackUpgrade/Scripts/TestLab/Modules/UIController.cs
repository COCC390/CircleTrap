/*
 * Author: DevDaoSi
 * @2024
 */
using Konzit.Core.Adapter;
using Konzit.Core.NullObject;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

namespace Konzit.UI
{
    public class UIController : IUIController
    {
        internal IGenericAdapter<IObjectResolver> adapter;
        private Dictionary<string, IPopup> _popupDict = new Dictionary<string, IPopup>();
        private UIControllerView _view;

        #region Constructor
        public UIController(UIControllerView view, IGenericAdapter<IObjectResolver> adapter)
        {
            this.adapter = adapter;
            _view = view;
        }
        #endregion

        #region Interface implement
        public void OpenPopupByName(string popupName)
        {
            if (!_popupDict.ContainsKey(popupName))
            {
                // create popup by prefab in prefab container
                // if not have any popup prefab has name same with popupName parameter -> null object dp
                // if have, create new popup, and add it into dictionary to call after, show that popup
                // when create popup

                var popup = _view.PopupPrefabContainer.Where(p => p.gameObject.name == popupName).FirstOrDefault();

                KNullHandler.Operation(popup, () =>
                {
                    CreatePopup(popup, popupName);
                });
            }
            else
            {
                var popup = (BasePopup) _popupDict[popupName];
                popup.PopupInitialize(() => popup.gameObject.SetActive(true));
            }
        }

        public void OpenPopupByName<T>(string popupName, T param, Action callback = null)
        {
            if (!_popupDict.ContainsKey(popupName))
            {
                // create popup by prefab in prefab container
                // if not have any popup prefab has name same with popupName parameter -> null object dp
                // if have, create new popup, and add it into dictionary to call after, show that popup
                // when create popup

                var popup = _view.PopupPrefabContainer.Where(p => p.gameObject.name == popupName).FirstOrDefault();

                KNullHandler.Operation(popup, () =>
                {
                    CreatePopup(popup, popupName, param);
                });
            }
            else
            {
                var popup = (BasePopup)_popupDict[popupName];
                popup.PopupInitialize(() => popup.gameObject.SetActive(true), param);
            }
        }

        private void CreatePopup<T>(GameObject popup, string popupName, T param)
        {
            var initPopup = GameObject.Instantiate(popup, _view.PopupContainer).GetComponent<BasePopup>();
            initPopup.SetPopupManager(this);
            initPopup.gameObject.SetActive(false);
            initPopup.PopupInitialize(() => initPopup.gameObject.SetActive(true), param);
            _popupDict.Add(popupName, initPopup);
        }

        private void CreatePopup(GameObject popup, string popupName)
        {
            var initPopup = GameObject.Instantiate(popup, _view.PopupContainer).GetComponent<BasePopup>();
            initPopup.SetPopupManager(this);
            initPopup.gameObject.SetActive(false);
            initPopup.PopupInitialize(() => initPopup.gameObject.SetActive(true));
            _popupDict.Add(popupName, initPopup);
        }

        /*
         * Function under this handle disappear of popups
         * Hide popup handle hide but not dispose the popup, using this when need to use the popup after
         * Close popup handle dispose the popup, using this when no need to use popup anymore
         */
        public void HidePopupByName(string popupName, Action callback = null)
        {
            if(!_popupDict.ContainsKey(popupName))
            {
                Debug.LogWarning($"<color=red>Object not contain on Dictionary: </color> {popupName}");
                return;
            }

            var popup = (BasePopup) _popupDict[popupName];
            popup.PopupHide(() => popup.gameObject.SetActive(false));

            callback?.Invoke();
        }

        public void ClosePopup(string popupName, Action callback = null)
        {
            Debug.Log("Popup disappear and destroy");
            if (!_popupDict.ContainsKey(popupName))
            {
                Debug.LogWarning($"<color=red>Object not contain on Dictionary: </color> {popupName}");
                return;
            }

            var popup = (BasePopup)_popupDict[popupName];
            popup.PopupClose(() => DestroyPopup(popup));
        }

        private void DestroyPopup(IPopup popup)
        {
            var popupObj = (BasePopup)popup;
            GameObject.Destroy(popupObj.gameObject);
        }
        #endregion
    }

}
