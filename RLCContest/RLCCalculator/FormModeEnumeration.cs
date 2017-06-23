#region Using

using System.ComponentModel;

#endregion

namespace RLCCalculator
{
    public enum FormOpenMode
    {
        [Description("Редактирование")]
        Edit = 0,
        [Description("Создание")]
        Create = 1,
        [Description("Live редактирование")]
        LiveEdit = 3
    }
}
