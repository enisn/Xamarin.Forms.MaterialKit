using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Plugin.MaterialKit.Shared.Abstraction
{
    public interface IBannerContent
    {
        string Icon { get; set; }
        string Text { get; set; }
        string Cancel { get; set; }
        string OK { get; set; }
        ICommand Command { get; set; }
        object CommandParameter { get; set; }
    }
}
