namespace SocialWeb.BLL.Interfaces
{
    /// <summary>
    /// Интерфейс клонирования объектов
    /// </summary>
    public interface ICloneable<T>
    {
        /// <summary>
        /// Клонирование объекта
        /// </summary>
        T Clone();
    }
}
