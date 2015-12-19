using System;

namespace Pizza.Net.Screens.Windows
{
    abstract class CloseableViewModel : ChangingPagesBaseViewModel
    {
        public event EventHandler ClosingRequest;

        protected void OnClosingRequest()
        {
            if (this.ClosingRequest != null)
            {
                this.ClosingRequest(this, EventArgs.Empty);
            }
        }
    }
}