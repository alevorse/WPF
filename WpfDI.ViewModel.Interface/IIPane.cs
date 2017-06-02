using System;

namespace WpfDI.ViewModel.Interface
{
    public interface IIPane
    {
        Action<IIPane> RemovePane { get; set; }
    }
}
