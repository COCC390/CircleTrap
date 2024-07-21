/*
 * Author: DevDaoSi
 * @2024
 */
using UnityEngine;
using System;
using System.ComponentModel;

namespace Konzit.UI
{
    public class BasePopup : MonoBehaviour, IPopup
    {
        [Header("Function Check")]
        [Description("Check some boolean variable under to use function or use build in animation (animation will be update in another version of package)")]
        [SerializeField] private bool _alwaysOnTop = false;


        // Non edit on editor variable
        protected IUIController _manager;
        protected object _parameter;

        internal IUIController SetPopupManager (IUIController popupManager) => _manager = popupManager;
        //Show template
        internal void PopupInitialize(Action popupActive, object param = null)
        {
            if(_alwaysOnTop) this.transform.SetAsLastSibling();

            OnShow();

            if(param != null) 
                _parameter = param;

            OnShowing();
            popupActive?.Invoke();
            OnShown();
        }

        // Hide template
        internal void PopupHide(Action popupHide)
        {
            OnHide();
            OnHiding();
            popupHide?.Invoke();
            OnHidden();

            if(_parameter != null) _parameter = null;
        }

        // Close template
        internal void PopupClose(Action popupClose)
        {
            OnClose();
            OnClosing();
            OnClosed();

            popupClose?.Invoke();
        }


        #region Popup template implementation
        public virtual void OnShow() { }

        public virtual void OnShowing() { }

        public virtual void OnShown() { }

        public virtual void OnHide() { }

        public virtual void OnHiding() { }

        public virtual void OnHidden() { }

        public virtual void OnClose() { }
        public virtual void OnClosing() { }
        public virtual void OnClosed() { }
        #endregion
    }
}
