using SocialWeb.DAL.Entities;
    
namespace SocialWeb.DAL.Repositories
{
    /// <summary>
    /// Репозиторий сообщений
    /// </summary>
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public int Create(MessageEntity messageEntity)
        {
            return Execute(@"insert into messages(content, sender_id, recipient_id)
                            values(:content,:sender_id,:recipient_id)", messageEntity);
        }

        public int DeleteById(int messageId)
        {
            return Execute("delete from messages where id = :id", new { id = messageId });
        }

        public IEnumerable<MessageEntity> FindByRecipientId(int recipientId)
        {
            return Query<MessageEntity>("select * from messages where recipient_id = :recipient_id",
                                        new { recipient_id = recipientId });
        }

        public IEnumerable<MessageEntity> FindBySenderId(int senderId)
        {
            return Query<MessageEntity>("select * from messages where sender_id = :sender_id",
                                        new { sender_id = senderId });
        }
    }

    /// <summary>
    /// Интерфейс репозитория сообщений
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>
        /// Создание записи в базе данных.
        /// </summary>
        int Create(MessageEntity messageEntity);
        /// <summary>
        /// Поиск всех записей по ID отправителя.
        /// </summary>
        IEnumerable<MessageEntity> FindBySenderId(int senderId);
        /// <summary>
        /// Поиск всех записей по ID получателя.
        /// </summary>
        IEnumerable<MessageEntity> FindByRecipientId(int recipientId);
        /// <summary>
        /// Удаление записи из базы данных по ID записи.
        /// </summary>
        int DeleteById(int messageId);
    }
}
