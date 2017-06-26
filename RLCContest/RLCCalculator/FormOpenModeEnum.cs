#region Using

using System.ComponentModel;

#endregion

namespace RLCCalculator
{

    /// <summary>
    /// Тип открытия формы.
    /// </summary>
    public enum FormOpenModeEnum
    {
        /// <summary>
        /// Редактирование.
        /// </summary>
        [Description("Редактирование")]
        Edit = 0,
        /// <summary>
        /// Создание нового элемента.
        /// </summary>
        [Description("Создание")]
        Create = 1,
        /// <summary>
        /// Редактирование элемента без блокировани других форм.
        /// </summary>
        [Description("Live редактирование")]
        LiveEdit = 3
    }
}
