using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace InputSaver
{
    /// <summary>
    /// This TabControl ensures that it's tab items fill the awailable space for themeselves while giving them a uniform width
    /// </summary>
    class TabControl_AutoTabSize : TabControl
    {
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
           
            ChangeTabSize();
        }

        public void ChangeTabSize() 
        {
            foreach (TabItem tab in this.Items)
            {
                double newWidth = (this.ActualWidth / this.Items.Count) - 1.5;
                if (newWidth < 0) newWidth = 0;
                tab.Width = newWidth;
                Debug.WriteLine("actual: " + this.ActualWidth);
            }
        }
    }
}
