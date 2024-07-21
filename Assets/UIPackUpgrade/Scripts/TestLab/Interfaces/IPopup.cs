
namespace Konzit.UI
{
    public interface IPopup
    {
        void OnShow();
        void OnShowing();
        void OnShown();

        void OnHide();
        void OnHiding();
        void OnHidden();

        void OnClose();
        void OnClosing();
        void OnClosed();
    }

}
