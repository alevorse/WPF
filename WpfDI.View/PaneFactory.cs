using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace WpfDI.View
{
    public class PaneFactory : DockingPanesFactory
    {
        protected override RadPane CreatePaneForItem(RadDocking radDocking, object item)
        {
            return new RadDocumentPane { Content = ViewMapper.CreateView(item), Header = item.GetType().Name };
        }

        protected override RadPane GetPaneFromItem(RadDocking docking, object item)
        {
            return docking.Panes.FirstOrDefault(pane => (pane.Content as FrameworkElement)?.DataContext == item);
        }
        
        protected override void RemovePane(RadPane pane)
        {
            pane.RemoveFromParent();
        }
    }
}